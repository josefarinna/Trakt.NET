namespace TraktNET
{
    /// <summary>A scrobble post for a Trakt episode.</summary>
    public record class TraktEpisodeScrobblePost : TraktScrobblePost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the scrobble post.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the scrobble post.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Episode == null)
                throw new TraktPostValidationException(nameof(Episode), "episode must not be null");

            if (Show == null)
            {
                if (Episode.IDs == null)
                    throw new TraktPostValidationException($"{nameof(Episode)}.IDs", "episode ids must not be null");

                if (!Episode.IDs.HasAnyID)
                    throw new TraktPostValidationException($"{nameof(Episode)}.IDs", "episode ids have no valid id");
            }
            else
            {
                if (Show.IDs == null)
                    throw new TraktPostValidationException($"{nameof(Show)}.IDs", "show ids must not be null");

                if (!Show.IDs.HasAnyID)
                    throw new TraktPostValidationException($"{nameof(Show)}.IDs", "show ids have no valid id");

                if (Episode.Number < 1)
                    throw new TraktPostValidationException($"{nameof(Episode)}.Number", "episode number must be valid, if episode ids not valid or empty");
            }
        }
    }
}
