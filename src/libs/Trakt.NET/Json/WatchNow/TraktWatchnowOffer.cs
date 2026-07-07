namespace TraktNET
{
    /// <summary>Represents a specific watch now offer/option for a media item.</summary>
    public record class TraktWatchnowOffer
    {
        /// <summary>Gets or sets the source/provider name.</summary>
        public string? Source { get; set; }

        /// <summary>Gets or sets the link to watch the item.</summary>
        public string? Link { get; set; }

        /// <summary>Gets or sets whether the content is available in UHD (Ultra HD).</summary>
        public bool Uhd { get; set; }

        /// <summary>Gets or sets the pricing currency code (e.g., "USD").</summary>
        public string? Currency { get; set; }

        /// <summary>Gets or sets the prices for the offer (rent/purchase).</summary>
        public TraktWatchnowPrices? Prices { get; set; }

        /// <summary>Gets or sets the link for tvOS app.</summary>
        public string? LinkTvos { get; set; }

        /// <summary>Gets or sets the direct web link.</summary>
        public string? LinkDirect { get; set; }

        /// <summary>Gets or sets the Android app link.</summary>
        public string? LinkAndroid { get; set; }

        /// <summary>Gets or sets the webOS link details.</summary>
        public TraktWatchnowWebos? LinkWebos { get; set; }
    }
}
