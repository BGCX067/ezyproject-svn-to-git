namespace G4Framework.Util
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ConverterUtil
    {
        public static T GetTFromString<T>(string myString)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(myString);
        }
    }
}
