namespace TraktNET
{
    /// <summary>Represents a Trakt comment reaction summary.</summary>
    public record class TraktCommentReactionSummary
    {
        /// <summary>Gets or sets the total reaction count.</summary>
        public int? ReactionCount { get; set; }

        /// <summary>Gets or sets the total user count.</summary>
        public int? UserCount { get; set; }

        /// <summary>Gets or sets the distribution of reactions grouped by reaction type.</summary>
        public IReadOnlyDictionary<string, int>? Distribution { get; set; }
    }
}
