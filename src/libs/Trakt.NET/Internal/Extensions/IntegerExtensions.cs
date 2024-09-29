using System.Globalization;

namespace TraktNET
{
    internal static class IntegerExtensions
    {
        internal static string ToInvariantCultureString(this uint value) => value.ToString(CultureInfo.InvariantCulture);

        internal static string ToInvariantCultureString(this uint value, string format) => value.ToString(format, CultureInfo.InvariantCulture);
    }
}
