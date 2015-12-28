namespace G4.Web.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.IO;
    using G4.Core.Extensions;

    public static class HttpResponseExtensions
    {      
        /// <summary>
        /// Write response to a csv file.
        /// </summary>
        /// <param name="response">The http response.</param>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="fileDownloadName">Name of the file download.</param>
        public static void Csv(this HttpResponse response, byte[] fileContents, string fileDownloadName)
        {
            WriteSpecificFile(response, fileContents, fileDownloadName,G4.Core.Util.MIMEUtil.ContentTypeFromExtension(".csv"));
        }

        /// <summary>
        /// Write response to a pdf file.
        /// </summary>
        /// <param name="response">The http response.</param>
        /// <param name="fileContents">The file contents</param>
        /// <param name="fileDownloadName">Name of the file to be downloaded.</param>
        public static void Pdf(this HttpResponse response, byte[] fileContents, string fileDownloadName)
        {
            WriteSpecificFile(response, fileContents, fileDownloadName, G4.Core.Util.MIMEUtil.ContentTypeFromExtension(".pdf"));
        }

        private static void WriteSpecificFile(HttpResponse response, byte[] fileContents, string fileDownloadName, string mimeType)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(mimeType))            
#elif NET35
            if (string.IsNullOrEmpty(mimeType) || string.IsNullOrEmpty(mimeType.Trim()))
#endif
            throw new ArgumentNullException("mimeType");

            fileDownloadName = MergeFileNameWithExt(fileDownloadName,mimeType);
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileDownloadName + "\"");
            response.ContentType = mimeType;
            response.OutputStream.Write(fileContents, 0, fileContents.Length);
            response.End();
        }

        /// <summary>
        /// Merges the file name with extension.
        /// </summary>
        /// <param name="fileDownloadName">Name of the file download.</param>
        /// <param name="ext">The ext.</param>
        /// <returns></returns>
        private static string MergeFileNameWithExt(string fileDownloadName, string ext)
        {
            if (string.IsNullOrEmpty(fileDownloadName))
                throw new ArgumentNullException("fileDownloadName", WebResource.File_Download_Name_missing);

            string extension = Path.GetExtension(fileDownloadName);

#if NET40            
            if (string.IsNullOrWhiteSpace(extension) || extension.ToLower() != ext)
#elif NET35
            if (extension.IsNullOrWhiteSpace() || extension.ToLower() != ext)
#endif
                fileDownloadName = fileDownloadName + ext;

            return fileDownloadName;
        }
    }
}
