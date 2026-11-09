namespace TraktNET
{
    /// <summary>Represents the top rated titles in a review period.</summary>
    public record class TraktUserReviewTopRated
    {
        /// <summary>Gets or sets the top rated shows.</summary>
        public List<TraktUserReviewTopRatedShow>? Shows { get; set; }

        /// <summary>Gets or sets the top rated movies.</summary>
        public List<TraktUserReviewTopRatedMovie>? Movies { get; set; }
    }
}
