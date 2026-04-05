namespace TraktNET
{
    /// <summary>A Trakt recommended movie.</summary>
    public record class TraktRecommendedMovie : TraktMovie
    {
        /// <summary>Gets or sets the list of users who favorited this movie. See also <seealso cref="TraktFavoritedBy" />.</summary>
        public List<TraktFavoritedBy>? FavoritedBy { get; set; }
    }
}
