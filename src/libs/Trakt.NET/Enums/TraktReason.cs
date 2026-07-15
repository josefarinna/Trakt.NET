namespace TraktNET
{
    /// <summary>Determines the report reason.</summary>
    [TraktEnum]
    public enum TraktReason
    {
        /// <summary>An unspecified report reason.</summary>
        Unspecified,

        /// <summary>A user is reported by spam.</summary>
        Spam,

        /// <summary>A user is reported for adult content in their profile.</summary>
        Adult,

        /// <summary>A user is reported for using not English language.</summary>
        Language,

        /// <summary>Other report reason.</summary>
        Other,

        /// <summary>Duplicate of another item on Trakt.</summary>
        Duplicate,

        /// <summary>Should be removed from Trakt.</summary>
        Remove,

        /// <summary>Request a full metadata refresh.</summary>
        [TraktEnumMember(JsonValue = "data_refresh")]
        DataRefresh,

        /// <summary>Metadata is wrong (title, overview, name, biography, etc).</summary>
        Metadata,

        /// <summary>Runtime is incorrect.</summary>
        Runtime,

        /// <summary>Should use TMDB as the datasource.</summary>
        [TraktEnumMember(JsonValue = "tmdb")]
        TMDB,

        /// <summary>Contains spoilers.</summary>
        Spoilers,

        /// <summary>Harassment or abusive behavior.</summary>
        Abusive,

        /// <summary>Bigotry, hate speech, or discrimination.</summary>
        Bigotry,

        /// <summary>Political attack.</summary>
        Political,

        /// <summary>Off topic.</summary>
        Offtopic,

        /// <summary>Support question.</summary>
        Support,

        /// <summary>Too short to be useful.</summary>
        [TraktEnumMember(JsonValue = "too_short")]
        TooShort
    }
}
