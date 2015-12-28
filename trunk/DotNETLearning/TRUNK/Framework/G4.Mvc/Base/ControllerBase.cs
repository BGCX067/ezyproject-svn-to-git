namespace G4.Mvc.Base
{
    using System;
    using System.IO;
    using ActionResults;
    using System.Web.Mvc;

    public class ControllerBase : Controller
    {
        /// <summary>
        /// CSV action result, when fileDownloadName extension is empty or not csv, it will automatically append .csv after file name
        /// </summary>        
        /// <param name="fileContents">The file contents.</param>
        /// <param name="fileDownloadName">Name of the file to download.</param>
        /// <returns></returns>        
        public CsvActionResult Csv(byte[] fileContents, string fileDownloadName)
        {
            string filename = MergeFileNameWithExt(fileDownloadName, ".csv");

            return new CsvActionResult(fileContents) { FileDownloadName = filename };
        }

        /// <summary>
        /// PDF action result, when fileDownloadName extension is empty or not csv, it will automatically append .csv after file name
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="fileDownloadName">Name of the file download.</param>
        /// <returns></returns>
        public PdfActionResult Pdf(byte[] fileContents, string fileDownloadName)
        {
            string filename = MergeFileNameWithExt(fileDownloadName, ".pdf");

            return new PdfActionResult(fileContents) { FileDownloadName = filename };
        }

        /// <summary>
        /// Merges the file name with extension.
        /// </summary>
        /// <param name="fileDownloadName">Name of the file download.</param>
        /// <param name="ext">The ext.</param>
        /// <returns></returns>
        private string MergeFileNameWithExt(string fileDownloadName,string ext)
        {
            if (string.IsNullOrEmpty(fileDownloadName))
                throw new ArgumentNullException("fileDownloadName", MvcResource.File_Download_Name_missing);

            string extension = Path.GetExtension(fileDownloadName);

            if (string.IsNullOrWhiteSpace(extension) || extension.ToLower() != ext)
                fileDownloadName = fileDownloadName + ext;

            return fileDownloadName;
        }
    }
}
