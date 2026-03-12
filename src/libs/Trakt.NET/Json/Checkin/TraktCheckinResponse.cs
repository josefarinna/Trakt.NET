namespace TraktNET
{
    public record class TraktCheckinResponse
    {
        /// <summary>Gets or sets the history id for the checkin response.</summary>
        public ulong Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the checked in movie or episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the checkin response.
        /// See also <seealso cref="TraktConnections" />.
        /// </summary>
        public TraktConnections? Sharing { get; set; }
    }
}
