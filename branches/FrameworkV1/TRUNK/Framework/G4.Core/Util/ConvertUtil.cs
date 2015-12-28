namespace G4.Core.Util
{
    public class ConverterUtil
    {
        public static T GetTFromString<T>(string myString)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(myString);
        }
    }
}