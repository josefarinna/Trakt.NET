namespace TraktNET
{
    /// <summary>Determines the sort order for watchlists.</summary>
    [TraktEnum]
    public enum TraktWatchlistSortOrder
    {
        /// <summary>An invalid sort order.</summary>
        Unspecified,

        /// <summary>Watchlists will be sorted by rank.</summary>
        Rank,

        /// <summary>Watchlists will be sorted by recently added items first.</summary>
        Added,

        /// <summary>Watchlists will be sorted by recently released items first.</summary>
        Released,

        /// <summary>Watchlists will be sorted by title.</summary>
        Title
    }
}
