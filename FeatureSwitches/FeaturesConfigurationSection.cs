using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureSwitches
{
    public class FeaturesConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("names", DefaultValue = "", IsRequired = false)]
        public string Names
        {
            get
            {
                return this["names"].ToString();
            }
            set
            {
                this["names"] = value;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
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
