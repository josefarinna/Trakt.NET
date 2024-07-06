namespace TraktNET
{
    /// <summary>Determines the type of an object in an history item or in a watchlist item, .</summary>
    [TraktEnum]
    public enum TraktSyncItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The history or watchlist item contains a movie.</summary>
        [TraktEnumMember("movie", UriValue = "movies")]
        Movie,

        /// <summary>The history or watchlist item contains a show.</summary>
        [TraktEnumMember("show", UriValue = "shows")]
        Show,

        /// <summary>The history or watchlist item contains a season.</summary>
        [TraktEnumMember("season", UriValue = "seasons")]
        Season,

        /// <summary>The history or watchlist item contains an episode.</summary>
        [TraktEnumMember("episode", UriValue = "episodes")]
        Episode
    }
}
