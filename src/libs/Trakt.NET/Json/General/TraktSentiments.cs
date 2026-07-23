namespace TraktNET
{
    /// <summary>Represents sentiment counts for comments and reactions attached to a movie or show.</summary>
    public record class TraktSentiments
    {
        /// <summary>Gets or sets the list of good sentiments.</summary>
        public List<TraktSentimentItem>? Good { get; set; }

        /// <summary>Gets or sets the list of bad sentiments.</summary>
        public List<TraktSentimentItem>? Bad { get; set; }

        /// <summary>Gets or sets the UTC datetime when sentiments were analyzed.</summary>
        public DateTime? AnalyzedAt { get; set; }

        /// <summary>Gets or sets the total comment count.</summary>
        public uint? CommentCount { get; set; }
    }
}
