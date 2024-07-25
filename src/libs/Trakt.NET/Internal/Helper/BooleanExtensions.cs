namespace TraktNET
{
    internal static class BooleanExtensions
    {
        internal static string ToLowerCase(this bool value) => value ? "true" : "false";
    }
}
