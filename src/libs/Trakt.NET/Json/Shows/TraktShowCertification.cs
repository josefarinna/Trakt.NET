namespace TraktNET
{
    /// <summary>An Certification for a Trakt show.</summary>
    public record class TraktShowCertification
    {
        /// <summary>The title of the show certification.</summary>
        public string? Certification { get; set; }

        /// <summary>The two letter country code for the show certification.</summary>
        public string? Country { get; set; }
    }
}
