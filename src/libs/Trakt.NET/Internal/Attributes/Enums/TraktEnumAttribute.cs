namespace TraktNET
{
    /// <summary>Provides extension methods and a Json converter for an enum.</summary>
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktEnumAttribute() : Attribute
    {
        public string? QueryName { get; set; }

        public bool HasPathSupport { get; set; }

        public bool HasQuerySupport { get; set; }
    }
}
