namespace TraktNET
{
    /// <summary>Determines the type of an object in an user like item.</summary>
    [TraktEnum]
    public enum TraktUserLikeType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The user like item contains a comment.</summary>
        [TraktEnumMember("comment", UriValue = "comments")]
        Comment,

        /// <summary>The user like item contains a list.</summary>
        [TraktEnumMember("list", UriValue = "lists")]
        List
    }
}
