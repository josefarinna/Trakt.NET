namespace TraktNET
{
    /// <summary>A collection of Trakt user list limits.</summary>
    public record class TraktUserListLimits
    {
        /// <summary>Gets or sets the number maximum lists.</summary>
        public uint? Count { get; set; }

        /// <summary>Gets or sets the number maximum list's item count.</summary>
        public uint? ItemCount { get; set; }
    }
}
