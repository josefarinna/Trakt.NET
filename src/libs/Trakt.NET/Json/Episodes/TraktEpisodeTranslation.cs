namespace TraktNET
{
    /// <summary>A translation for a Trakt episode.</summary>
    public record class TraktEpisodeTranslation
    {
        /// <summary>The title of the translation.</summary>
        public string? Title { get; set; }

        /// <summary>The synopsis of the release.</summary>
        public string? Overview { get; set; }

        /// <summary>The two letter language code for the translation.</summary>
        public string? Language { get; set; }

        /// <summary>The two letter country code for the translation.</summary>
        public string? Country { get; set; }
    }
}
