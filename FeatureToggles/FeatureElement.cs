using System.Configuration;

namespace FeatureToggles
{
    public class FeatureElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
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
        public bool Activated
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