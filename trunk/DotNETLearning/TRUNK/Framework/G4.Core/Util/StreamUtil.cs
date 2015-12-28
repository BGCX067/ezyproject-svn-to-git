namespace G4.Core.Util
{
    using System.IO;

    public class StreamUtil
    {
        /// <summary>
        /// Copies from one Stream to another.
        /// </summary>
        /// <param name="from">The Stream to copy from.</param>
        /// <param name="to">The Stream to copy to.</param>
        public static void StreamCopy(Stream from, Stream to)
        {
            if (from == to)
            {
                return;
            }

            var buffer = new byte[4096];

            from.Seek(0, SeekOrigin.Begin);

            while (true)
            {
                var done = from.Read(buffer, 0, 4096);

                if (done <= 0)
                {
                    return;
                }

                to.Write(buffer, 0, done);
            }
        }
    }
}