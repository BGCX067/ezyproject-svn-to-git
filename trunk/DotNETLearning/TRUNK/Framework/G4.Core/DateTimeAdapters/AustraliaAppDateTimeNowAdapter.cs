namespace G4.Core.DateTimeAdapters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Config;
    using G4.Core.Infrastructure;

    public class AustraliaAppDateTimeNowAdapter : IDateTimeNowAdapter
    {
        /// <summary>
        /// TimeZone dictionary
        /// </summary>
        static readonly Dictionary<string, TimeZoneInfo> Zones = TimeZoneInfo.GetSystemTimeZones().ToDictionary(z => z.Id);

        public DateTime DateTimeNow()
        {
            return ZoneNow(AppZone);
        }

        /// <summary>
        /// Get the specified zone by state
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        internal static TimeZoneInfo StateZone(string state)
        {
            switch (state.ToLower())
            {
                case "wa":
                case "western australia":
                    return Zones["W. Australia Standard Time"];
                case "nt":
                case "northern territory":
                    return Zones["AUS Central Standard Time"];
                case "queensland":
                case "qld":
                    return Zones["E. Australia Standard Time"];
                case "tas":
                case "tasmania":
                    return Zones["Tasmania Standard Time"];
                case "sa":
                case "south australia":
                    return Zones["Cen. Australia Standard Time"];
                case "nsw":
                case "new south wales":
                case "act":
                case "australian capital territory":
                case "vic":
                case "victoria":
                    return Zones["AUS Eastern Standard Time"];
                case "nz":
                case "new zealand":
                    return Zones["New Zealand Standard Time"];
                default:
                    throw new NotSupportedException("Invalid State");
            }
        }

        /// <summary>
        /// Gets the app zone.
        /// </summary>
        internal static TimeZoneInfo AppZone
        {
            get
            {
                return StateZone(Setting.Get("AppState", "NSW"));
            }
        }

        /// <summary>
        /// Zones the now.
        /// </summary>
        /// <param name="zone">The zone.</param>
        /// <returns></returns>
        internal static DateTime ZoneNow(TimeZoneInfo zone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(), zone);
        }
    }
}