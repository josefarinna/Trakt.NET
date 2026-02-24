namespace TraktNET
{
    /// <summary>
    /// A Trakt post for resetting the watched progress of a show, containing an optional reset_at UTC date to have it
    /// calculate progress from that specific date onwards.
    /// </summary>
    public record class TraktShowResetWatchedProgress
    {
        /// <summary>An optional reset_at UTC date to have it calculate progress from that specific date onwards.</summary>
        public DateTime? ResetAt { get; set; }
    }
}
