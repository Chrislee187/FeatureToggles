using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace FeatureToggles
{
    public static class Features
    {
        static Features()
        {
            var toggles = ConfigurationManager.GetSection("features") as FeaturesConfigurationSection;

            // Set 'true' toggles from the features 'names' attribute
            toggles.Names.Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList().ForEach(f => AppContext.SetSwitch(f.Trim(), true));

            // Set specific boolean values from the individual feature elements

            foreach (FeatureElement feature in toggles.Features)
            {
                AppContext.SetSwitch(feature.name, feature.activated);
            }
        }

        public static bool State(string toggleName)
        {
            bool b;
            return AppContext.TryGetSwitch(toggleName, out b) && b;
        }
    }
}