namespace G4.Core.DateTimeAdapters
{
    using System;
    using G4.Core.Infrastructure;

    /// <summary>
    /// IDateTimeNowAdapter implementation that provides the system's actual DateTime.Now value.
    /// </summary>
    public class SystemDateTimeNowAdapter : IDateTimeNowAdapter
    {
        public DateTime DateTimeNow()
        {
            return DateTime.Now;
        }
    }
}