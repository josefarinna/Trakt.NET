namespace TraktNET
{
    /// <summary>Represents a summary of the owner's lists that are ready to become smart lists.</summary>
    public record class TraktSmartListDraftsSummary
    {
        /// <summary>The count of lists that can be converted to smart lists.</summary>
        public uint? ConvertibleCount { get; set; }

        /// <summary>The best confidence score among the convertible lists, or <c>null</c> if none.</summary>
        public float? BestConfidence { get; set; }

        /// <summary>The top convertible lists by confidence.</summary>
        public IReadOnlyList<TraktSmartListDraftSummaryList>? Lists { get; set; }
    }
}
