namespace TraktNET
{
    /// <summary>Determines the comment type.</summary>
    [TraktEnum]
    public enum TraktCommentType
    {
        /// <summary>An invalid comment type.</summary>
        Unspecified,

        /// <summary>The comment type for reviews.</summary>
        [TraktEnumMember(JsonValue = "reviews")]
        Review,

        /// <summary>The comment type for shouts.</summary>
        [TraktEnumMember(JsonValue = "shouts")]
        Shout,

        /// <summary>The comment type for both reviews and shouts.</summary>
        All
    }
}
