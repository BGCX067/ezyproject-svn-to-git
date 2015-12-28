namespace G4.Core.Config
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Allows data to be persisted using a config file.
    /// Not supported under medium trust.
    /// </summary>
    public class Persist
    {
        private Configuration _config = null;

        /// <summary>
        /// Get a property value.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="defaultValue">The value returned if the property does not exist.</param>
        /// <returns>The value</returns>
        public static string Get(string key, string defaultValue)
        {
            return new Persist().GetValue(key, defaultValue);
        }

        /// <summary>
        /// Get a property as a boolean.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="defaultValue">The value returned if the property does not exist.</param>
        /// <returns>The value</returns>
        public static bool GetAsBool(string key, bool defaultValue)
        {
            return bool.Parse(new Persist().GetValue(key, defaultValue.ToString()));
        }

        /// <summary>
        /// Get a property value as a int.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="defaultValue">The value returned if the property does not exist.</param>
        /// <returns>The value</returns>
        public static int GetAsInt(string key, int defaultValue)
        {
            return int.Parse(new Persist().GetValue(key, defaultValue.ToString()));
        }

        /// <summary>
        /// Get a property value as a datetime.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="defaultValue">The value returned if the property does not exist.</param>
        /// <returns>The value</returns>
        public static DateTime GetAsDateTime(string key, DateTime defaultValue)
        {
            return DateTime.Parse(new Persist().GetValue(key, defaultValue.ToString()));
        }

        /// <summary>
        /// Set a property value.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="value">The value.</param>
        public static void Set(string key, object value)
        {
            new Persist().SetValue(key, value.ToString());
        }

        public Persist()
            : this("/App_Data/Working/Persist/Data.xml")
        {
        }

        public Persist(string fileName)
        {
            ExeConfigurationFileMap fm = new ExeConfigurationFileMap();
            fm.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + fileName.TrimStart(new char[] { '~', '/' });
            _config = ConfigurationManager.OpenMappedExeConfiguration(fm, ConfigurationUserLevel.None);
        }

        public string GetValue(string key, string defaultValue)
        {
            return (_config.AppSettings.Settings[key] != null) ? _config.AppSettings.Settings[key].Value : defaultValue;
        }

        public void SetValue(string key, string value)
        {
            if (_config.AppSettings.Settings[key] == null)
            {
                // new value
                _config.AppSettings.Settings.Add(key, value);
                _config.Save();
            }
            {
                // existing
                if (!_config.AppSettings.Settings[key].Value.Equals(value))
                {
                    _config.AppSettings.Settings[key].Value = value.ToString();
                    _config.Save();
                }
            }
        }
    }
}