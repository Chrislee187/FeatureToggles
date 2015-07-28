using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace FeatureToggles
{
    public static class Features
    {
        private static readonly IList<string> SwitchNames = new List<string>();
        private static readonly bool AllowOverrides;
        private static readonly bool HasFeatures;
        static Features()
        {
            var features = ConfigurationManager.GetSection("features") as FeaturesConfigurationSection;

            HasFeatures = (features != null);
            if (!HasFeatures) return;

            AllowOverrides = features.AllowOverrides;

            SetTogglesFromNameAttribute(features);
            SetTogglesFromFeatureElements(features);
        }

        public static bool State(string toggleName)
        {
            if (!HasFeatures) return false;

            bool b;
            return AppContext.TryGetSwitch(toggleName, out b) && b;
        }

        public static IReadOnlyDictionary<string, bool> List()
        {
            return HasFeatures ? SwitchNames.ToDictionary(k => k, State) : new Dictionary<string, bool>();
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
                if (AllowOverrides) SwitchNames.Add(switchName);
                else throw new ConfigurationErrorsException($"Duplicate feature [{switchName}] found in configuration, fix or use allow-overrides to disable this error.");
            }
        }
    }
}