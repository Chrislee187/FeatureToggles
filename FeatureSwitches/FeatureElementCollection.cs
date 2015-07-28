using System;
using System.Configuration;

namespace FeatureSwitches
{
    public class FeatureElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new FeatureElement();
        protected override object GetElementKey(ConfigurationElement element) => ((FeatureElement)element).name;

        public FeatureElement this[int index] => base.BaseGet(index) as FeatureElement;
        public new FeatureElement this[string key] => base.BaseGet(key) as FeatureElement;
//
        protected override string ElementName => "feature";
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

    }
}