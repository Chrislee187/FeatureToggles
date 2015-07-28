using System.Configuration;

namespace FeatureSwitches
{
    public class FeatureElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string name
        {
            get
            {
                return this["name"].ToString();
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("activated", IsRequired = true)]
        public bool activated
        {
            get
            {
                return (bool)this["activated"];
            }
            set
            {
                this["activated"] = value;
            }
        }
    }
}