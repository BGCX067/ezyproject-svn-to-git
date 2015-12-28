using System;
using System.Configuration;
using System.Reflection;

namespace G4.Core.Config
{
    /// <summary>
    /// A configuration element that includes a class and assembly property that is decided back to a Type
    /// </summary>
    public class ConfigClassElement : ConfigurationElement
    {
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected bool _typeDecoded = false;
        protected Type _objectType = null;

        [ConfigurationProperty("class", IsRequired = true)]
        public string Class
        {
            get { return (string)this["class"]; }
            set
            {
                this["class"] = value;
                _typeDecoded = false;
            }
        }

        [ConfigurationProperty("assembly", DefaultValue = "")]
        public string AssemblyName
        {
            get { return (string)this["assembly"]; }
            set
            {
                this["assembly"] = value;
                _typeDecoded = false;
            }
        }

        public Type ObjectType
        {
            get
            {
                if (!_typeDecoded)
                {
                    // Locate the type object for the named class
                    Type foundType = null;
                    if (AssemblyName != String.Empty)
                        foundType = Assembly.Load(AssemblyName).GetType(Class, false, true);
                    else
                        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                            if ((foundType = assembly.GetType(Class, false, true)) != null) break;

                    //if (foundType == null) log.Error("Unable to locate class " + Class);
                    if (foundType == null) throw new Exception(string.Format("Unable to locate class {0}", Class));
                    _objectType = foundType;
                    _typeDecoded = true;
                }
                return _objectType;
            }
        }
    }
}