namespace TraktNET
{
    /// <summary>A Trakt social recommended show.</summary>
    public record class TraktSocialShowRecommendation : TraktShow
    {
        /// <summary>Gets or sets the list of users who favorited this show.</summary>
        public List<TraktUser>? FavoritedBy { get; set; }

        /// <summary>Gets or sets the list of users who recommended this show.</summary>
        public List<TraktUser>? RecommendedBy { get; set; }
    }
}
