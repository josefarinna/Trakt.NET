namespace TraktNET
{
    /// <summary>Determines the id type, for which should be searched in an id lookup request.</summary>
    [TraktEnum]
    public enum TraktSearchIdType
    {
        /// <summary>An invalid id type.</summary>
        Unspecified,

        /// <summary>Search for Trakt ids.</summary>
        Trakt,

        /// <summary>Search for ImDB ids.</summary>
        [TraktEnumMember(JsonValue = "imdb", DisplayName = "Internet Movie Database")]
        ImDB,

        /// <summary>Search for TmDB ids.</summary>
        [TraktEnumMember(JsonValue = "tmdb", DisplayName = "The Movie Database")]
        TmDB,

        /// <summary>Search for TvDB ids.</summary>
        [TraktEnumMember(JsonValue = "tvdb", DisplayName = "TheTVDB")]
        TvDB,

        /// <summary>Search for TVRage ids.</summary>
        [TraktEnumMember(JsonValue = "tvrage", DisplayName = "TVRage")]
        TVRage
    }
}
