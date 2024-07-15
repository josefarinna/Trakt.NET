using System.Globalization;

namespace TraktNET
{
    internal static class DateTimeExtensions
    {
        private const string TraktLongDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        internal static string ToTraktLongDateTimeString(this DateTime value)
            => value.ToUniversalTime().ToString(TraktLongDateTimeFormat, CultureInfo.InvariantCulture);
    }
}
