namespace TraktNET
{
    /// <summary>A collection containing information about an updated list.</summary>
    public record class TraktPostResponseListData
    {
        /// <summary>Gets or sets the UTC datetime when a list was updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the new item count of a list.</summary>
        public uint? ItemCount { get; set; }
    }
}
