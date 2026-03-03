namespace TraktNET
{
    /// <summary>Represents a language available on Trakt.</summary>
    public record class TraktLanguage
    {
        /// <summary>Gets or sets the full name of the language (e.g., "English").</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the 2-character language code (e.g., "en").</summary>
        public string? Code { get; set; }

        /// <summary>Returns a string representation of the language.</summary>
        /// <returns>The name of the language if it exists; otherwise, an empty string.</returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return Name!;
            }

            return string.Empty;
        }
    }
}
