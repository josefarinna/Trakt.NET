namespace TraktNET
{
    /// <summary>Represents a rating item with rating value, vote count, and link from an external provider.</summary>
    public record class TraktRatingItem
    {
        /// <summary>Gets or sets the rating value.</summary>
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for this rating.</summary>
        public uint? Votes { get; set; }

        /// <summary>Gets or sets the external link to the rating.</summary>
        public string? Link { get; set; }
    }
}
