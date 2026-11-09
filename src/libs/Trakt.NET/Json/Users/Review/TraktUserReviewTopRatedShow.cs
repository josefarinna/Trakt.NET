namespace TraktNET
{
    /// <summary>Represents a top rated show in a review period.</summary>
    public record class TraktUserReviewTopRatedShow
    {
        /// <summary>Gets or sets the rating assigned to the show.</summary>
        public uint? Rating { get; set; }

        /// <summary>Gets or sets the show details. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }
    }
}
