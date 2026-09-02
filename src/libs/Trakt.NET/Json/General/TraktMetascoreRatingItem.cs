namespace TraktNET
{
    /// <summary>Represents a Metascore rating item with rating value and link.</summary>
    public record class TraktMetascoreRatingItem
    {
        /// <summary>Gets or sets the Metascore rating value.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the external link to the Metascore review.</summary>
        public string? Link { get; set; }
    }
}
