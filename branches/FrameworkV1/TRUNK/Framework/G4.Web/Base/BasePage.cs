using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using G4.Web.Extensions;
namespace G4.Web.Base
{
    public class BasePage : Page
    {
        /// <summary>
        /// Write response to csv file.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="fileDownloadName">Name of the file download.</param>
        public virtual void Csv(byte[] fileContents, string fileDownloadName)
        {
            this.Response.Csv(fileContents, fileDownloadName);
        }

        /// <summary>
        /// Write response to pdf file.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="fileDownloadName">Name of the file download.</param>
        public virtual void Pdf(byte[] fileContents, string fileDownloadName)
        {
            this.Response.Pdf(fileContents, fileDownloadName);
        }
    }
}
