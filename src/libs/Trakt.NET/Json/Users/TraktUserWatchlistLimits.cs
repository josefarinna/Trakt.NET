namespace TraktNET
{
    /// <summary>A collection of Trakt user watchlist limits.</summary>
    public record class TraktUserWatchlistLimits
    {
        /// <summary>Gets or sets the number maximum watchlist's item count.</summary>
        public uint? ItemCount { get; set; }
    }
}
