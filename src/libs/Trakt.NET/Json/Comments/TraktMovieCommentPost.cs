namespace TraktNET
{
    /// <summary>A movie comment post.</summary>
    public record class TraktMovieCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the movie comment post.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Movie == null)
                throw new TraktPostValidationException(nameof(Movie), "movie must not be null");

            if (Movie.IDs == null)
                throw new TraktPostValidationException(nameof(Movie.IDs), "movie ids must not be null");

            if (!Movie.IDs.HasAnyID)
                throw new TraktPostValidationException("movie ids have no valid id", nameof(Movie.IDs));
        }
    }
}
