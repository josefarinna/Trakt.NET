namespace TraktNET
{
    /// <summary>A checkin error response.</summary>
    public record class TraktCheckinErrorResponse
    {
        /// <summary>The UTC datetime, when the current checkin expires.</summary>
        public DateTime? ExpiresAt { get; set; }
    }
}
