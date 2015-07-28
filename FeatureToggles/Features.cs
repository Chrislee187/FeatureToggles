using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace FeatureToggles
{
    public static class Features
    {
        private static readonly IList<string> SwitchNames = new List<string>();
        private static readonly bool _allowOverrides;
        private static readonly bool _hasFeatures;
        static Features()
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
                var switchName = feature.name.Trim();
                if(string.IsNullOrEmpty(switchName)) throw new ConfigurationErrorsException("feature elements must contain a unique name attribute.");

                RememberSwitchName(switchName);
                AppContext.SetSwitch(switchName, feature.activated);
            }
        }

        private static void RememberSwitchName(string switchName)
        {
            if (!SwitchNames.Contains(switchName))
            {
                if(_allowOverrides) SwitchNames.Add(switchName);
                else throw new ConfigurationErrorsException($"Duplicate name [{switchName}] found in features configuration, use allow-overrides to disable this error.");
            }
        }

        private static void SetTogglesFromNameAttribute(FeaturesConfigurationSection toggles)
        {
            toggles.Names.Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList().ForEach(f =>
            {
                var n = f.Trim();
                AppContext.SetSwitch(n, true);
                SwitchNames.Add(n);
            });
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
    }
}