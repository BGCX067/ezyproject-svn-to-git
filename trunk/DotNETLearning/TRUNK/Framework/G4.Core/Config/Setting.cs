namespace G4.Core.Config
{
    using System.Configuration;
    using System.Net.Configuration;

    public class Setting
    {
        /// <summary>
        /// Return a setting from the AppSettings section of the Web.config file.
        /// Searches for a setting with the machine name appended to the key first and then returns the base key value if this is not found
        /// </summary>
        /// <param name="key">AppSettings key name without machine name</param>
        /// <returns>Configuration setting</returns>
        public static string Get(string key) { return Get(key, null); }
        public static string Get(string key, object defaultValue)
        {
            string value = ConfigurationManager.AppSettings.Get(key + "." + System.Environment.MachineName.ToLower());
            if (value == null) value = ConfigurationManager.AppSettings.Get(key);
            if (value == null && defaultValue != null) value = defaultValue.ToString();
            return value;
        }

        /// <summary>
        /// Return a config section from the Web.config
        /// Searches for a section with the machine name appended to the key first and then returns the base key section if this is not found
        /// </summary>
        /// <param name="key">Config section key name without machine name, ie orchard/poller</param>
        /// <returns>Specific config section</returns>
        public static ConfigurationSection GetSection(string key)
        {
            ConfigurationSection section = (ConfigurationSection)(ConfigurationManager.GetSection(key + "." + System.Environment.MachineName.ToLower()));
            if (section == null) section = (ConfigurationSection)(ConfigurationManager.GetSection(key));
            return section;
        }

        /// <summary>
        /// Return the connection string settings for the site. Try the machine name, then the first one. Don't use SQL Express if there is one.
        /// </summary>
        /// <returns>ConnectionStringSettings object or null if we can't workout which one to use.</returns>
        public static ConnectionStringSettings ConnectionString
        {
            get
            {
                ConnectionStringSettings settings = null;

                // Try and get a connection string that matches the machine name.
                try
                {
                    settings = ConfigurationManager.ConnectionStrings[System.Environment.MachineName];
                }
                catch { }

                // If the above failed or returned nothing then get the first connection string that's not an SQLEXPRESS one.
                if (settings == null)
                {
                    foreach (ConnectionStringSettings tempSettings in ConfigurationManager.ConnectionStrings)
                    {
                        // Extra check put in to cater for MaximumASP local instance of connection strings
                        if (tempSettings.Name.ToUpper() == "LOCALMYSQLSERVER" || tempSettings.Name.ToUpper() == "LOCALSQLSERVER")
                            continue;

                        // Don't use an SQL express connection
                        if (!tempSettings.ConnectionString.ToUpper().Contains("SQLEXPRESS"))
                        {
                            settings = tempSettings;
                            break;
                        }
                    }
                }

                return settings;
            }
        }

        /// <summary>
        /// Return a SmtpConfiguration that at least points to the Orchard SMTP server.
        /// </summary>
        public static SmtpSection SmtpConfiguration
        {
            get
            {
                return (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            }
        }
    }
}