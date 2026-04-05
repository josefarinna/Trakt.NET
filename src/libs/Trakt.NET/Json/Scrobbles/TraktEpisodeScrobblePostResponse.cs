namespace TraktNET
{
    /// <summary>Represents an episode scrobble response.</summary>
    public record class TraktEpisodeScrobblePostResponse : TraktScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was scrobbled.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was scrobbled.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
