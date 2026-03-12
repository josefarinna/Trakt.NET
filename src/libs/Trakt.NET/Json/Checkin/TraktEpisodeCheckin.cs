namespace TraktNET
{
    /// <summary>A checkin for a Trakt episode.</summary>
    public record class TraktEpisodeCheckin : TraktCheckin
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the checkin.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public required TraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the checkin.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
