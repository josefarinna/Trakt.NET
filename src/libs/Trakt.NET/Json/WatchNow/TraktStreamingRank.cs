namespace TraktNET
{
    /// <summary>Represents the streaming rank details for a media item.</summary>
    public record class TraktStreamingRank
    {
        /// <summary>Gets or sets the current streaming rank.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the delta / change in ranking.</summary>
        public int? Delta { get; set; }

        /// <summary>Gets or sets the link to the ranking details.</summary>
        public string? Link { get; set; }
    }
}
