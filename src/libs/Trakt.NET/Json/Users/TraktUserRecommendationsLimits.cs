namespace TraktNET
{
    /// <summary>A collection of Trakt user recommendations limits.</summary>
    public record class TraktUserRecommendationsLimits
    {
        /// <summary>Gets or sets the number maximum recommendations item count.</summary>
        public uint? ItemCount { get; set; }
    }
}
