namespace G4.Core.Extensions
{
    public static class StringExtensions
    {
       /// <summary>
        /// Generate the value with double qoute around it, it's not standard, but good practice. http://www.ietf.org/rfc/rfc4180.txt        
        /// </summary>
        /// <typeparam name="T">base type of .net value</typeparam>
        /// <param name="item">extended value</param>
        /// <returns>CSV compatible value</returns>
        public static string ToCsvValue<T>(this T item)
        {
            if (item == null)
                return string.Empty;
            if (item is string)
            {
                return string.Format("\"{0}\"", item.ToString().Replace("\"", "\"\""));
            }
            double dummy;
            if (double.TryParse(item.ToString(), out dummy))
            {
                return string.Format("{0}", item);
            }
            return string.Format("\"{0}\"", item);
        }
#if NET35
        /// <summary>
        /// Port of .NET 4.0 IsNullOrWhiteSpace functionality
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>
        /// 	<c>true</c> if [is null or white space] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()));
        }
#endif
    }

}