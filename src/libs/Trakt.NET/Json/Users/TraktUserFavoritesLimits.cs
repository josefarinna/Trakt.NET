namespace TraktNET
{
    /// <summary>A collection of Trakt user favorites limits.</summary>
    public record class TraktUserFavoritesLimits
    {
        /// <summary>Gets or sets the number maximum favorites item count.</summary>
        public uint? ItemCount { get; set; }
    }
}
