namespace TraktNET
{
    /// <summary>A Trakt recommended show.</summary>
    public record class TraktRecommendedShow : TraktShow
    {
        /// <summary>Gets or sets the list of users who favorited this show. See also <seealso cref="TraktFavoritedBy" />.</summary>
        public List<TraktFavoritedBy>? FavoritedBy { get; set; }
    }
}
