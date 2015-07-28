using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace FeatureSwitches
{
    public static class Switches
    {
        static Switches()
        {
            var switches = ConfigurationManager.GetSection("features") as FeaturesConfigurationSection;

            // Default switches
            switches.Names.Split(',').ToList().ForEach(f => AppContext.SetSwitch(f.Trim(), true));

            // Individual Switches

            foreach (FeatureElement feature in switches.Features)
            {
                AppContext.SetSwitch(feature.name, feature.activated);
            }
        }

        public static bool State(string switchName)
        {
            bool b;
            return AppContext.TryGetSwitch(switchName, out b) && b;
        }
    }
}