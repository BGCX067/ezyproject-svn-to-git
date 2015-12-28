namespace G4.Mvc.ActionResults
{    
    /// <summary>
    /// Csv action result
    /// </summary>
    public sealed class CsvActionResult : System.Web.Mvc.FileContentResult
    {
        public CsvActionResult(byte[] fileContents)
            : base(fileContents, "text/csv")
        {
        }
    }
}