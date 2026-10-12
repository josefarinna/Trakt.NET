namespace TraktNET
{
    /// <summary>Information about a converted smart list.</summary>
    public record class TraktSmartListDraftConverted
    {
        /// <summary>The Trakt ID of the smart list.</summary>
        public int? SmartListId { get; set; }

        /// <summary>The UTC datetime when the list was converted.</summary>
        public DateTime? ConvertedAt { get; set; }
    }
}
