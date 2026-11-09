namespace TraktNET
{
    /// <summary>Represents the most watched titles in a review period.</summary>
    public record class TraktUserReviewMostWatched
    {
        /// <summary>Gets or sets the most watched shows.</summary>
        public List<TraktUserReviewMostWatchedShow>? Shows { get; set; }

        /// <summary>Gets or sets the most watched movies.</summary>
        public List<TraktUserReviewMostWatchedMovie>? Movies { get; set; }
    }
}
