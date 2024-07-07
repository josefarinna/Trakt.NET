namespace TraktNET
{
    /// <summary>Determines the type of an object in an history item or in a watchlist item, .</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSyncItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The history or watchlist item contains a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>The history or watchlist item contains a show.</summary>
        [TraktEnumMember(UriValue = "shows")]
        Show,

        /// <summary>The history or watchlist item contains a season.</summary>
        [TraktEnumMember(UriValue = "seasons")]
        Season,

        /// <summary>The history or watchlist item contains an episode.</summary>
        [TraktEnumMember(UriValue = "episodes")]
        Episode
    }
}
