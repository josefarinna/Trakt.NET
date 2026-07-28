namespace TraktNET
{
    /// <summary>Contains information about a Trakt show watched progress item in sync.</summary>
    public record class TraktSyncProgressWatchedItem
    {
        /// <summary>
        /// Gets or sets the show.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the watched progress of the show.
        /// See also <seealso cref="TraktShowWatchedProgress" />.
        /// </summary>
        public TraktShowWatchedProgress? Progress { get; set; }
    }
}
