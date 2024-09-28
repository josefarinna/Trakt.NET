using System.Globalization;

namespace TraktNET
{
    internal static class FloatExtensions
    {
        internal static string ToInvariantCultureString(this float value) => value.ToString(CultureInfo.InvariantCulture);
    }
}
