namespace TraktNET
{
    /// <summary>Determines the type of an object in a comment.</summary>
    [TraktEnum]
    public enum TraktCommentObjectType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The comment contains a movie.</summary>
        [TraktEnumMember("movie", UriValue = "movies")]
        Movie,

        /// <summary>The comment contains a show.</summary>
        [TraktEnumMember("show", UriValue = "shows")]
        Show,

        /// <summary>The comment contains a season.</summary>
        [TraktEnumMember("season", UriValue = "seasons")]
        Season,

        /// <summary>The comment contains an episode.</summary>
        [TraktEnumMember("episode", UriValue = "episodes")]
        Episode,

        /// <summary>The comment contains a list.</summary>
        [TraktEnumMember("list", UriValue = "lists")]
        List,

        /// <summary>The comment contains a movie, show, season, list or an episode.</summary>
        All
    }
}
