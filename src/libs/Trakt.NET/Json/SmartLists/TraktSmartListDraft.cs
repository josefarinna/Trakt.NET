using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents a smart list draft response for a list that stopped updating.</summary>
    public record class TraktSmartListDraft
    {
        /// <summary>
        /// Information about the list.
        /// See also <seealso cref="TraktSmartListDraftList" />.
        /// </summary>
        public TraktSmartListDraftList? List { get; set; }

        /// <summary>The origin URL of the list.</summary>
        public string? OriginUrl { get; set; }

        /// <summary>
        /// The source of the smart list.
        /// See also <seealso cref="TraktSmartListSource" />.
        /// </summary>
        public TraktSmartListSource? Source { get; set; }

        /// <summary>
        /// The media type of the smart list.
        /// See also <seealso cref="TraktSmartListMediaType" />.
        /// </summary>
        public TraktSmartListMediaType? MediaType { get; set; }

        /// <summary>
        /// The filter constraints applied to the source of the smart list.
        /// See also <seealso cref="TraktSmartListFilters" />.
        /// </summary>
        public TraktSmartListFilters? Filters { get; set; }

        /// <summary>The list of unsupported criteria.</summary>
        public IReadOnlyList<string>? Unsupported { get; set; }

        /// <summary>The share of the list's current titles the setup brings back, from 0 to 1.</summary>
        public float? Confidence { get; set; }

        /// <summary>
        /// Information about the conversion, if the list has already been converted.
        /// See also <seealso cref="TraktSmartListDraftConverted" />.
        /// </summary>
        public TraktSmartListDraftConverted? Converted { get; set; }
    }
}
