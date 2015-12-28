namespace G4.Core.Util
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;

    public static class FileUtil
    {
        private static readonly MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
        private static readonly Dictionary<string, Guid> FileHash = new Dictionary<string, Guid>();

        /// <summary>
        /// Returns a hash of the supplied file.
        /// </summary>
        /// <param name="file">file with full path </param>
        /// <returns>A Guid representing the hash of the file.</returns>
        public static Guid GetFileHash(string file)
        {
            Guid hash;            
            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    StreamUtil.StreamCopy(fs, ms);
                }

                hash = new Guid(Md5.ComputeHash(ms.ToArray()));
                Guid check;
                if (!FileHash.TryGetValue(file, out check))
                {
                    FileHash.Add(file, hash);
                }
                else if (check != hash)
                {
                    FileHash[file] = hash;
                }
            }

            return hash;
        }
    }
}