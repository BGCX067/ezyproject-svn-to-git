using System;
using System.Collections.Generic;
using System.IO;

namespace Smartmail.Toolkit.Extensions
{
    public static class StreamReaderEnumerable
    {
        public static IEnumerable<String> Lines(this StreamReader source)
        {
            String line;

            if (source == null)
                throw new ArgumentNullException("source");

            while ((line = source.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
