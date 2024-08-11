namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a checkin is already in progress.</summary>
    public sealed partial class TraktApiCheckinException : TraktApiException
    {
        /// <summary>The UTC datetime, when the current checkin expires and a new checkin can be requested.</summary>
        public DateTime? ExpiresAt { get; }
    }
}
