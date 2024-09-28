namespace TraktNET
{
    /// <summary>A translation for a Trakt movie.</summary>
    public record class TraktMovieTranslation
    {
        /// <summary>The translated title of a movie.</summary>
        public string? Title { get; set; }

        /// <summary>The translated synopsis of a movie.</summary>
        public string? Overview { get; set; }

        /// <summary>The translated tagline of a movie.</summary>
        public string? Tagline { get; set; }

        /// <summary>The two character language code for the translation.</summary>
        public string? Language { get; set; }

        /// <summary>The two character country code for the translation.</summary>
        public string? Country { get; set; }
    }
}
