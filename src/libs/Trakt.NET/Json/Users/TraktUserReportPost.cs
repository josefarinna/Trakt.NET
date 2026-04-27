namespace TraktNET
{
    /// <summary>
    /// An reason to report an user.
    /// </summary>
    public record class TraktUserReportPost
    {
        /// <summary>The reason for the user's report.</summary>
        public TraktReason? Reason { get; set; }

        /// <summary>An optional message providing additional context for the report.</summary>
        public string? Message { get; set; }

        public void Validate()
        {
            if (Reason == null)
                throw new TraktPostValidationException("no reason set");
            if (Reason == TraktReason.Other && string.IsNullOrEmpty(Message))
                throw new TraktPostValidationException("no message set for 'Other' reason");
        }
    }
}
