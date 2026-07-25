namespace TraktNET
{
    /// <summary>A Trakt social recommended movie.</summary>
    public record class TraktSocialMovieRecommendation : TraktMovie
    {
        /// <summary>Gets or sets the list of users who favorited this movie.</summary>
        public List<TraktUser>? FavoritedBy { get; set; }

        /// <summary>Gets or sets the list of users who recommended this movie.</summary>
        public List<TraktUser>? RecommendedBy { get; set; }
    }
}
