namespace TraktNET
{
    /// <summary>Determines the list type.</summary>
    [TraktEnum]
    public enum TraktListType
    {
        /// <summary>An invalid list type.</summary>
        Unspecified,

        /// <summary>The list type for personal lists.</summary>
        Personal,

        /// <summary>The list type for official lists.</summary>
        Official,

        /// <summary>The list type for watchlists.</summary>
        [TraktEnumMember(JsonValue = "watchlists", DisplayName = "Watchlists")]
        Watchlist,

        /// <summary>The list type for recommendations.</summary>
        Recommendations,

        /// <summary>The list type for personal, official lists, watchlists and recommendations together.</summary>
        All
    }
}
