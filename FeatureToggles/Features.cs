using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace FeatureToggles
{
    /// <summary>
    /// Very simple Feature Toggles implementation using the AppContext class that comes with .NET 4.6 and greater. Expects a feature section in your app/web.config.
    /// </summary>
    public static class Features
    {
        private static readonly IList<string> SwitchNames = new List<string>();
        private static bool _allowOverrides;
        private static bool _hasFeatures;
        static Features()
        {
            ReadFeaturesFromConfig();
        }

        public static bool State(string toggleName)
        {
            if (!_hasFeatures) return false;

            bool b;
            return AppContext.TryGetSwitch(toggleName, out b) && b;
        }

        public static IReadOnlyDictionary<string, bool> List()
        {
            return _hasFeatures ? SwitchNames.ToDictionary(k => k, State) : new Dictionary<string, bool>();
        }

        public static void Reload()
        {
            ReadFeaturesFromConfig();
        }
        private static void ReadFeaturesFromConfig()
        {
            var features = ConfigurationManager.GetSection("features") as FeaturesConfigurationSection;

            _hasFeatures = (features != null);
            if (!_hasFeatures) return;

            _allowOverrides = features.AllowOverrides;

            SetTogglesFromNameAttribute(features);
            SetTogglesFromFeatureElements(features);
        }

        private static void SetTogglesFromFeatureElements(FeaturesConfigurationSection toggles)
        {
            foreach (FeatureElement feature in toggles.Features)
            {
                var switchName = feature.Name.Trim();
                if(string.IsNullOrEmpty(switchName)) throw new ConfigurationErrorsException("Feature elements must contain a name.");

                RememberSwitchName(switchName);
                AppContext.SetSwitch(switchName, feature.Activated);
            }
        }

        private static void SetTogglesFromNameAttribute(FeaturesConfigurationSection toggles)
        {
            toggles.Names.Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList().ForEach(f =>
            {
                var switchName = f.Trim();
                RememberSwitchName(switchName);
                AppContext.SetSwitch(switchName, true);
            });
        }


        private static void RememberSwitchName(string switchName)
        {
            if (!SwitchNames.Contains(switchName))
            {
                if (_allowOverrides) SwitchNames.Add(switchName);
                else throw new ConfigurationErrorsException($"Duplicate feature [{switchName}] found in configuration, fix or use allow-overrides to disable this error.");
            }
        }
    }
}