namespace G4.Mvc.Extensions
{
    using System;
    using System.Web;
    using Core.Util;

    public static class StaticContentExtensions
    {
        /// <summary>
        /// Appends the hash of the file as a querystring parameter to a supplied string.
        /// </summary>
        /// <param name="fname">The filename.</param>        
        /// <param name="request">The current HttpRequest </param>
        /// <returns>String with hash of the file appended.</returns>
        public static string AppendHash(this string fname, HttpRequestBase request)
        {
            var localPath = request.RequestContext.HttpContext.Server.MapPath(fname.Replace('/', '\\'));
            return String.Format(@"{0}?hash={1}", fname, FileUtil.GetFileHash(localPath));
        }
    }
}