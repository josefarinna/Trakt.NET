namespace TraktNET
{
    /// <summary>A Trakt smart list template.</summary>
    public record class TraktSmartListTemplate
    {
        /// <summary>The smart list template ID (kebab slug).</summary>
        public string? Id { get; set; }

        /// <summary>
        /// The source of the smart list template.
        /// See also <seealso cref="TraktSmartListSource" />.
        /// </summary>
        public TraktSmartListSource? Source { get; set; }

        /// <summary>
        /// The media type of the smart list template.
        /// See also <seealso cref="TraktSmartListMediaType" />.
        /// </summary>
        public TraktSmartListMediaType? MediaType { get; set; }

        /// <summary>
        /// The filter constraints applied to the source of the smart list template.
        /// See also <seealso cref="TraktSmartListFilters" />.
        /// </summary>
        public TraktSmartListFilters? Filters { get; set; }

        /// <summary>Gets or sets whether results depend on the viewer.</summary>
        public bool? Personal { get; set; }

        /// <summary>The total number of items, or <c>null</c> if personal.</summary>
        public uint? Total { get; set; }

        /// <summary>
        /// Gets or sets the list of items for the smart list template.
        /// See also <seealso cref="TraktListItem" />.
        /// </summary>
        public IReadOnlyList<TraktListItem>? Items { get; set; }
    }
}
