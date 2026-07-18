namespace TraktNET
{
    /// <summary>A smart list post.</summary>
    public record class TraktSmartListPost
    {
        /// <summary>Gets or sets the required name of the smart list.</summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the required source of the smart list.
        /// See also <seealso cref="TraktSmartListSource" />.
        /// </summary>
        public TraktSmartListSource? Source { get; set; }

        /// <summary>
        /// Gets or sets the required media type of the smart list.
        /// See also <seealso cref="TraktSmartListMediaType" />.
        /// </summary>
        public TraktSmartListMediaType? MediaType { get; set; }

        /// <summary>
        /// Gets or sets the filter constraints applied to the source of the smart list.
        /// See also <seealso cref="TraktSmartListFilters" />.
        /// </summary>
        public TraktSmartListFilters? Filters { get; set; }

        /// <summary>
        /// Gets or sets the optional privacy setting of the smart list.
        /// See also <seealso cref="TraktListPrivacy" />.
        /// </summary>
        public TraktListPrivacy? Privacy { get; set; }

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(Name, "smart list name must not be null or empty");

            if (Source == null || Source == TraktSmartListSource.Unspecified)
                throw new TraktPostValidationException(nameof(Source), "Source must not be unspecified");

            if (MediaType == null || MediaType == TraktSmartListMediaType.Unspecified)
                throw new TraktPostValidationException(nameof(MediaType), "MediaType must not be unspecified");

            if (Privacy != null && Privacy == TraktListPrivacy.Unspecified)
                throw new TraktPostValidationException(nameof(Privacy), "Privacy must not be unspecified");
        }
    }
}
