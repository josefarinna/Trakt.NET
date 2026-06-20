namespace TraktNET
{
    /// <summary>A scrobble post for a Trakt movie.</summary>
    public record class TraktMovieScrobblePost : TraktScrobblePost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the scrobble post.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Movie == null)
                throw new TraktPostValidationException(nameof(Movie), "movie must not be null");

            if (Movie.IDs == null)
                throw new TraktPostValidationException($"{nameof(Movie)}.IDs", "movie ids must not be null");

            if (!Movie.IDs.HasAnyID)
                throw new TraktPostValidationException($"{nameof(Movie)}.IDs", "movie ids have no valid id");
        }
    }
}
