using System.Configuration;

namespace FeatureToggles
{
    public class FeaturesConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("activate", DefaultValue = "", IsRequired = false)]
        public string Names
        {
            get
            {
                return this["activate"].ToString();
            }
            set
            {
                this["activate"] = value;
            }
        }

        [ConfigurationProperty("allow-overrides", DefaultValue = "false", IsRequired = false)]
        public bool AllowOverrides
        {
            get
            {
                return (bool) this["allow-overrides"];
            }
            set
            {
                this["allow-overrides"] = value;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true, IsRequired = false)]
        public FeatureElementCollection Features
        {
            get
            {
                return (FeatureElementCollection)this[""];
            }
            set
            {
                this[""] = value;
            }
        }

    }
}
