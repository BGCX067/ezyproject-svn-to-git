namespace G4.Mvc.ActionResults
{
    /// <summary>
    /// Pdf action result
    /// </summary>
    public  sealed class PdfActionResult : System.Web.Mvc.FileContentResult
    {
        /// <summary>
        /// Constructor, which accept byte array 
        /// </summary>
        /// <param name="fileContents"></param>
        public PdfActionResult(byte[] fileContents)
            : base(fileContents, "application/pdf")
        {

        }
    }
}