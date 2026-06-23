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

        /// <summary>Gets the culture name of the translation.</summary>
        /// <returns>The culture name of the translation.</returns>
        public string CultureName()
        {
            if (!string.IsNullOrEmpty(Language) && !string.IsNullOrEmpty(Country))
            {
                return $"{Language}-{Country!.ToUpperInvariant()}";
            }

            return string.Empty;
        }

        /// <summary>Gets a string representation of the translation.</summary>
        /// <returns>A string representation of the translation.</returns>
        public override string ToString()
        {
            string cultureName = CultureName();
            string title = Title ?? "no title set";

            if (!string.IsNullOrEmpty(cultureName))
            {
                return $"{cultureName}={title}";
            }

            return title;
        }
    }
}
