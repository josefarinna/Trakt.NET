namespace TraktNET
{
    /// <summary>A collection of social IDs for various web services for a Trakt person.</summary>
    public record class TraktPersonSocialIds
    {
        /// <summary>The Twitter ID of a person.</summary>
        public string? Twitter { get; set; }

        /// <summary>The Facebook ID of a person.</summary>
        public string? Facebook { get; set; }

        /// <summary>The Instagram ID of a person.</summary>
        public string? Instagram { get; set; }

        /// <summary>The Wikipedia link of a person.</summary>
        public string? Wikipedia { get; set; }
    }
}
