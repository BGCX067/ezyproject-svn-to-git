namespace G4.Core.Config
{
    using System;
    using System.Configuration;
    public class ConfigProperty : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public String Name
        {
            get { return (String)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get { return (String)this["value"]; }
            set { this["value"] = value; }
        }
    }
}