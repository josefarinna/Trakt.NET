namespace TraktNET
{
    /// <summary>Determines the type of an object in a rating item.</summary>
    [TraktEnum]
    public enum TraktRatingsItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The rating item contains a movie.</summary>
        [TraktEnumMember("movie", UriValue = "movies")]
        Movie,

        /// <summary>The ratingv item contains a show.</summary>
        [TraktEnumMember("show", UriValue = "shows")]
        Show,

        /// <summary>The rating item contains a season.</summary>
        [TraktEnumMember("season", UriValue = "seasons")]
        Season,

        /// <summary>The rating item contains an episode.</summary>
        [TraktEnumMember("episode", UriValue = "episodes")]
        Episode,

        /// <summary>The rating item contains a movie, show, season or an episode.</summary>
        All
    }
}
