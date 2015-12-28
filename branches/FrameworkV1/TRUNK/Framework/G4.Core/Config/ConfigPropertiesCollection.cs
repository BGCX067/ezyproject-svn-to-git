namespace G4.Core.Config
{
    using System.Configuration;

    public class ConfigPropertiesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigProperty();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigProperty)element).Name;
        }

        public void Add(ConfigProperty element)
        {
            this.BaseAdd(element);
        }

        public void Remove(string key)
        {
            this.BaseRemove(key);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        public ConfigProperty this[int index]
        {
            get
            {
                return (ConfigProperty)this.BaseGet(index);
            }
        }
    }
}