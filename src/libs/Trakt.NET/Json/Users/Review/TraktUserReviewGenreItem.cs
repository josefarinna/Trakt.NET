namespace TraktNET
{
    /// <summary>Represents a genre and its watched title count in a review period.</summary>
    public record class TraktUserReviewGenreItem
    {
        /// <summary>Gets or sets the genre slug.</summary>
        public string? Slug { get; set; }

        /// <summary>Gets or sets the genre name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the number of watched titles with this genre.</summary>
        public uint? Count { get; set; }
    }
}
