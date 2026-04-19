namespace TraktNET
{
    /// <summary>A collection of social IDs for various web services for a Trakt show.</summary>
    public record class TraktShowSocialIDs
    {
        /// <summary>The Twitter ID of a show.</summary>
        public string? Twitter { get; set; }

        /// <summary>The Facebook ID of a show.</summary>
        public string? Facebook { get; set; }

        /// <summary>The Instagram ID of a show.</summary>
        public string? Instagram { get; set; }

        /// <summary>The Wikipedia link of a show.</summary>
        public string? Wikipedia { get; set; }
    }
}
