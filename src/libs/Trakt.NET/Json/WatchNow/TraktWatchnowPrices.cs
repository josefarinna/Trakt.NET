namespace TraktNET
{
    /// <summary>Represents the rent and purchase prices for a watch now offer.</summary>
    public record class TraktWatchnowPrices
    {
        /// <summary>Gets or sets the rent price (as string, e.g., "1.99").</summary>
        public string? Rent { get; set; }

        /// <summary>Gets or sets the purchase price (as string, e.g., "9.99").</summary>
        public string? Purchase { get; set; }
    }
}
