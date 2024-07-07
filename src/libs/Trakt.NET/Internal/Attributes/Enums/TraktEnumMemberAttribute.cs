namespace TraktNET
{
    /// <summary>Can be used to provide a custom Json value, URI value and / or display name for an enum member.</summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktEnumMemberAttribute() : Attribute
    {
        /// <summary>A custom Json value for an enum member.</summary>
        public string? JsonValue { get; set; }

        /// <summary>A custom URI value for an enum member.</summary>
        public string? UriValue { get; set; }

        /// <summary>A custom display name for an enum member.</summary>
        public string? DisplayName { get; set; }
    }
}
