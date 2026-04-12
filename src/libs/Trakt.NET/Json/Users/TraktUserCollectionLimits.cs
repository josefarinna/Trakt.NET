namespace TraktNET
{
    /// <summary>A collection of Trakt user collection limits.</summary>
    public record class TraktUserCollectionLimits
    {
        /// <summary>Gets or sets the number of collection items.</summary>
        public uint? ItemCount { get; set; }
    }
}
