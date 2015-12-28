namespace G4.Core.DateTimeAdapters
{
    using System;
    using G4.Core.Infrastructure;    

    /// <summary>
    /// IDateTimeNowAdapter implementation that provides configurable DateTime.Now value for use in unit testing.
    /// </summary>
    public class TestDateTimeNowAdapter : IDateTimeNowAdapter
    {
        private readonly DateTime _dateTimeNowValue;

        public TestDateTimeNowAdapter(DateTime dateTimeNowValue)
        {
            this._dateTimeNowValue = dateTimeNowValue;
        }

        public DateTime DateTimeNow()
        {
            return this._dateTimeNowValue;
        }
    }
}