namespace TraktNET
{
    /// <summary>Represents a country available on Trakt.</summary>
    public record class TraktCountry
    {
        /// <summary>Gets or sets the full name of the country (e.g., "Spain").</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the 2-character country code (e.g., "es").</summary>
        public string? Code { get; set; }

        /// <summary>Returns a string representation of the country.</summary>
        /// <returns>The name of the country if it exists; otherwise, an empty string.</returns>
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
