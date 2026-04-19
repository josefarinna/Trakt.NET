namespace TraktNET
{
    /// <summary>A collection of social IDs for various web services for a Trakt movie.</summary>
    public record class TraktMovieSocialIDs
    {
        /// <summary>The Twitter ID of a movie.</summary>
        public string? Twitter { get; set; }

        /// <summary>The Facebook ID of a movie.</summary>
        public string? Facebook { get; set; }

        /// <summary>The Instagram ID of a movie.</summary>
        public string? Instagram { get; set; }

        /// <summary>The Wikipedia link of a movie.</summary>
        public string? Wikipedia { get; set; }
    }
}
