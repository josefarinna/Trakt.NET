namespace TraktNET
{
    /// <summary>An episode comment post.</summary>
    public record class TraktEpisodeCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the episode comment post.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Episode == null)
                throw new TraktPostValidationException(nameof(Episode), "Episode must not be null");

            if (Episode.IDs == null)
                throw new TraktPostValidationException(nameof(Episode.IDs), "episode ids must not be null");

            if (!Episode.IDs.HasAnyID)
                throw new TraktPostValidationException("episode ids have no valid id", nameof(Episode.IDs));
        }
    }
}
