using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G4.Core.Infrastructure
{
    /// <summary>
    /// Singleton class that provides access to all "singletons" stored by <see cref="Singleton{T}"/>.
    /// </summary>
    public class Singleton
    {
        static Singleton()
        {
            singletonDictionary = new Dictionary<Type, object>();
        }        

        static Dictionary<Type, object> singletonDictionary;

        /// <summary>
        /// Dictionary of type to singleton instances.
        /// </summary>
        public static Dictionary<Type, object> SingletonDictionary
        {
            get { return singletonDictionary; }

        }        
    }
#if NET35
    /// <summary>
    /// A statically compiled "singleton" used to store objects throughout the 
    /// lifetime of the app domain. Not so much singleton in the pattern's 
    /// sense of the word as a standardized way to store single instances.
    /// </summary>
    /// <typeparam name="T">The type of object to store.</typeparam>
    /// <remarks>Access to the instance is not synchrnoized.</remarks>
    public class Singleton<T> : Singleton
    {

        /// <summary>
        /// The singleton field for the specified type T.
        /// </summary>
        static T instance;

        Singleton() { }

        /// <summary>The singleton instance for the specified type T. Only one instance (at the time) of this object for each type of T.</summary>
        public static T Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
                SingletonDictionary[typeof(T)] = value;
            }
        }
    }
#elif NET40
    public class Singleton<T> where T: class, new()
    {
        static Singleton() { }
        Singleton() { }
        static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance
        {
            get { return instance.Value; }
        } 
    }
#endif

}
