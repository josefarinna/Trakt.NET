namespace TraktNET
{
    /// <summary>Determines the type of an object in a comment.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktCommentObjectType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The comment contains a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>The comment contains a show.</summary>
        [TraktEnumMember(UriValue = "shows")]
        Show,

        /// <summary>The comment contains a season.</summary>
        [TraktEnumMember(UriValue = "seasons")]
        Season,

        /// <summary>The comment contains an episode.</summary>
        [TraktEnumMember(UriValue = "episodes")]
        Episode,

        /// <summary>The comment contains a list.</summary>
        [TraktEnumMember(UriValue = "lists")]
        List,

        /// <summary>The comment contains a movie, show, season, list or an episode.</summary>
        All
    }
}
