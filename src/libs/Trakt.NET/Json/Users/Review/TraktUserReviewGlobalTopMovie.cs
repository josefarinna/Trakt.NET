namespace TraktNET
{
    /// <summary>Represents a globally most played movie on Trakt in an all-time review.</summary>
    public record class TraktUserReviewGlobalTopMovie
    {
        /// <summary>Gets or sets the global watchers count.</summary>
        public uint? Watchers { get; set; }

        /// <summary>Gets or sets whether this user watched the movie.</summary>
        public bool? Watched { get; set; }

        /// <summary>Gets or sets the movie details. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }
    }
}
