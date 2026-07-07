using System.Collections.Generic;

namespace TraktNET
{
    /// <summary>Represents watch now sources for a media item (movie, show, episode).</summary>
    public record class TraktWatchnowSources
    {
        /// <summary>Gets or sets the cable/tv watch now offers.</summary>
        public IReadOnlyList<TraktWatchnowOffer>? Cable { get; set; }

        /// <summary>Gets or sets the free watch now offers.</summary>
        public IReadOnlyList<TraktWatchnowOffer>? Free { get; set; }

        /// <summary>Gets or sets the cinema release watch now offers.</summary>
        public IReadOnlyList<TraktWatchnowOffer>? Cinema { get; set; }

        /// <summary>Gets or sets the subscription-based watch now offers.</summary>
        public IReadOnlyList<TraktWatchnowOffer>? Subscription { get; set; }

        /// <summary>Gets or sets the purchase-based watch now offers.</summary>
        public IReadOnlyList<TraktWatchnowOffer>? Purchase { get; set; }

        /// <summary>Gets or sets the streaming rank details.</summary>
        public TraktStreamingRank? StreamingRanks { get; set; }
    }
}
