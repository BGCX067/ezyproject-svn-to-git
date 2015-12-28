namespace G4.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Config;

    public class DateTimeUtili
    {
        /// <summary>
        /// TimeZone dictionary
        /// </summary>
        static readonly Dictionary<string, TimeZoneInfo> Zones = TimeZoneInfo.GetSystemTimeZones().ToDictionary(z => z.Id);

        /// <summary>
        /// Gets the current system time zone.
        /// </summary>
        public static TimeZoneInfo SystemZone
        {
            get
            {
                return TimeZoneInfo.Local;
            }
        }

        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        /// <returns></returns>
        public static DateTime SystemNow
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Get the specified zone by state
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public static TimeZoneInfo StateZone(string state)
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
        /// Gets a DateTime object that is set to the current date and time by state 
        /// </summary>
        /// <param name="state">The australia state.</param>
        /// <remarks>
        ///     Valid states value will be "NSW","ACT","VIC","NT","WA","SA","TAS","QLD","NZ"
        /// </remarks>
        /// <returns></returns>
        public static DateTime StateNow(string state)
        {
            return ZoneNow(StateZone(state));
        }

        /// <summary>
        /// Gets the app zone.
        /// </summary>
        public static TimeZoneInfo AppZone
        {
            get
            {
                return StateZone(Setting.Get("AppState", "NSW"));
            }
        }

        /// <summary>
        /// Gets a DateTime object that is set to the current date and time by specified state. 
        /// By default, it will return the NSW date and time, howerver you can change the state
        /// in config file, add "AppState" key name under appSetting with proper value, e.g. WA
        /// </summary>
        /// <remarks>
        ///     Valid states value will be "NSW","ACT","VIC","NT","WA","SA","TAS","QLD","NZ"
        /// </remarks>        
        /// <returns></returns>
        public static DateTime AppNow
        {
            get
            {
                return ZoneNow(AppZone);
            }
        }

        /// <summary>
        /// Zones the now.
        /// </summary>
        /// <param name="zone">The zone.</param>
        /// <returns></returns>
        public static DateTime ZoneNow(TimeZoneInfo zone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(SystemNow.ToUniversalTime(), zone);
        }
    }
}