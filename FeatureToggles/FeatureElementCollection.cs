using System.Configuration;

namespace FeatureToggles
{
    public class FeatureElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new FeatureElement();
        protected override object GetElementKey(ConfigurationElement element) => ((FeatureElement)element).Name;

        public FeatureElement this[int index] => BaseGet(index) as FeatureElement;
        public new FeatureElement this[string key] => BaseGet(key) as FeatureElement;

        protected override string ElementName => "feature";
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

    }
}