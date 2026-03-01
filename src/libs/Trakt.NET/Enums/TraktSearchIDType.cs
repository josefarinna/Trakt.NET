namespace TraktNET
{
    /// <summary>Determines the id type, for which should be searched in an id lookup request.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSearchIDType
    {
        /// <summary>An invalid id type.</summary>
        Unspecified,

        /// <summary>Search for Trakt IDs.</summary>
        Trakt,

        /// <summary>Search for ImDB IDs.</summary>
        [TraktEnumMember(JsonValue = "imdb", DisplayName = "Internet Movie Database")]
        ImDB,

        /// <summary>Search for TmDB IDs.</summary>
        [TraktEnumMember(JsonValue = "tmdb", DisplayName = "The Movie Database")]
        TmDB,

        /// <summary>Search for TvDB IDs.</summary>
        [TraktEnumMember(JsonValue = "tvdb", DisplayName = "TheTVDB")]
        TvDB,

        /// <summary>Search for TVRage IDs.</summary>
        [TraktEnumMember(JsonValue = "tvrage", DisplayName = "TVRage")]
        TVRage
    }
}
