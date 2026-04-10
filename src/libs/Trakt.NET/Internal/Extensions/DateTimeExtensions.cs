using System.Globalization;

namespace TraktNET
{
    internal static class DateTimeExtensions
    {
        private const string TraktLongDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        internal static string ToTraktLongDateTimeString(this DateTime value)
            => value.ToUniversalTime().ToString(TraktLongDateTimeFormat, CultureInfo.InvariantCulture);

        internal static string ToTraktCacheEfficientLongDateTimeString(this DateTime value)
        {
            DateTime dateTime = value.ToUniversalTime();
            return $"{dateTime.Year}-{dateTime.Month:00}-{dateTime.Day:00}T{dateTime.Hour:00}:00:00Z";
        }

#if NET7_0_OR_GREATER
        internal static int YearsBetween(this DateOnly? value, DateOnly? otherDate)
            => value.GetValueOrDefault().YearsBetween(otherDate.GetValueOrDefault());

        public static int YearsBetween(this DateOnly value, DateOnly otherDate)
        {
            int age = Math.Abs(otherDate.Year - value.Year);       

            if (otherDate < value.AddYears(age))
                age--;
            return age;
        }            
#else
        internal static int YearsBetween(this DateTime? value, DateTime? otherDate)
            => value.GetValueOrDefault().YearsBetween(otherDate.GetValueOrDefault());

        public static int YearsBetween(this DateTime value, DateTime otherDate)
        {
            int age = Math.Abs(otherDate.Year - value.Year);

            if (otherDate < value.AddYears(age))
                age--;
            return age;
        }
#endif
    }
}
