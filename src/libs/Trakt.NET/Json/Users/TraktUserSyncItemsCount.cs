namespace TraktNET
{
    /// <summary>Represents added counts per section in a data sync.</summary>
    public record class TraktUserSyncItemsCount
    {
        /// <summary>Gets or sets history counts.</summary>
        public TraktUserSyncCountGroup? History { get; set; }

        /// <summary>Gets or sets library counts.</summary>
        public TraktUserSyncCountGroup? Library { get; set; }

        /// <summary>Gets or sets ratings counts.</summary>
        public TraktUserSyncCountGroup? Ratings { get; set; }

        /// <summary>Gets or sets watchlist counts.</summary>
        public TraktUserSyncCountGroup? Watchlist { get; set; }
    }
}
