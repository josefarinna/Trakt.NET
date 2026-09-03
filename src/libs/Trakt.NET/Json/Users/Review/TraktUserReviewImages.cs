namespace TraktNET
{
    /// <summary>Represents images associated with a user's review period.</summary>
    public record class TraktUserReviewImages
    {
        /// <summary>Gets or sets the cover image URL.</summary>
        public string? Cover { get; set; }

        /// <summary>Gets or sets the story image URL.</summary>
        public string? Story { get; set; }
    }
}
