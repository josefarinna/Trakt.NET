namespace TraktNET
{
    /// <summary>
    /// Provides extension methods and a Json converter for an enum.
    /// <para />
    /// Generates Json values for each enum member in lower snake case format
    /// and display names for each enum member value splitted by space for each capital letter.
    /// <para />
    /// Default values can be overridden by using <see cref="TraktEnumMemberAttribute" /> on an enum member.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktEnumAttribute() : Attribute
    {
        /// <summary>A custom separator for JSON values. Default is '_'.</summary>
        public string? JsonSeparator { get; set; }

        /// <summary>The name for an URI query value which will be used when <see cref="HasQuerySupport" /> is enabled.</summary>
        public string? QueryName { get; set; }

        /// <summary>Enables or disables generating extension methods for providing URI path values.</summary>
        public bool HasPathSupport { get; set; }

        /// <summary>Enables or disables generating extension methods for providing URI query values.</summary>
        public bool HasQuerySupport { get; set; }
    }
}
