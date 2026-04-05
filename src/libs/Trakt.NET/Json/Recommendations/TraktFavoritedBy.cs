namespace TraktNET
{
    /// <summary>A Trakt favorited by entry.</summary>
    public record class TraktFavoritedBy
    {
        /// <summary>A Trakt user who favorited the movie or show. See also <seealso cref="TraktUser" />.</summary>
        public TraktUser? User { get; set; }

        /// <summary>Gets or sets the notes of the user who favorited this.</summary>
        public string? Notes { get; set; }
    }
}
