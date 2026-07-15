namespace TraktNET
{
    /// <summary>
    /// A post body for reporting a media item, person, list, comment, or user.
    /// </summary>
    public record class TraktReportPost
    {
        /// <summary>The reason for the report. See also <seealso cref="TraktReason" />.</summary>
        public TraktReason? Reason { get; set; }

        /// <summary>An optional message providing additional context for the report.</summary>
        public string? Message { get; set; }

        /// <summary>Validates the report post data.</summary>
        public void Validate()
        {
            if (Reason == null || Reason == TraktReason.Unspecified)
                throw new TraktPostValidationException("no reason set");
            if (Reason == TraktReason.Other && string.IsNullOrEmpty(Message))
                throw new TraktPostValidationException("no message set for 'Other' reason");
        }
    }
}
