namespace TraktNET
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktRequestQuery(string? queryName = null) : Attribute
    {
        public string? QueryName { get; } = queryName;
    }
}
