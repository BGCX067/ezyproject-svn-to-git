namespace G4.Core.Infrastructure
{
    using System;

    /// <summary>
    /// Defines a service for providing the DateTime.Now value. This can be used in testing scenarios to provide a 
    /// testable DateTime.Now value configurable from unit test setup methods.
    /// </summary>
    public interface IDateTimeNowAdapter
    {
        DateTime DateTimeNow();
    }
}