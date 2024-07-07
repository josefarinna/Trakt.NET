namespace TraktNET
{
    /// <summary>Determines the type of an object in a rating item.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktRatingsItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The rating item contains a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>The ratingv item contains a show.</summary>
        [TraktEnumMember(UriValue = "shows")]
        Show,

        /// <summary>The rating item contains a season.</summary>
        [TraktEnumMember(UriValue = "seasons")]
        Season,

        /// <summary>The rating item contains an episode.</summary>
        [TraktEnumMember(UriValue = "episodes")]
        Episode,

        /// <summary>The rating item contains a movie, show, season or an episode.</summary>
        All
    }
}
