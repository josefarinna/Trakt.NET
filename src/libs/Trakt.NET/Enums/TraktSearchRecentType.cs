namespace TraktNET
{
    /// <summary>Determines the search recent type.</summary>
    [TraktEnum]
    public enum TraktSearchRecentType
    {
        /// <summary>An invalid type.</summary>
        Unspecified,

        /// <summary>The search recent type is movies.</summary>
        [TraktEnumMember(JsonValue = "movies", DisplayName = "Movies")]
        Movie,

        /// <summary>The search recent type is shows.</summary>
        [TraktEnumMember(JsonValue = "shows", DisplayName = "Shows")]
        Show,

        /// <summary>The search recent type is people.</summary>
        [TraktEnumMember(JsonValue = "people", DisplayName = "People")]
        Person,

        /// <summary>The search recent type is lists.</summary>
        [TraktEnumMember(JsonValue = "lists", DisplayName = "Lists")]
        List
    }
}
