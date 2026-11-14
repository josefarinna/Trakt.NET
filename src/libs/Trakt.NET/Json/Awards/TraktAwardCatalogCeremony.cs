namespace TraktNET
{
    /// <summary>A ceremony in the award catalog.</summary>
    public record class TraktAwardCatalogCeremony : TraktAward
    {
        /// <summary>Gets or sets the media types for the ceremony. See also <seealso cref="TraktAwardMediaType" />.</summary>
        public IReadOnlyList<TraktAwardMediaType>? MediaTypes { get; set; }

        /// <summary>Gets or sets the awards in the ceremony. See also <seealso cref="TraktAwardCatalogAward" />.</summary>
        public IReadOnlyList<TraktAwardCatalogAward>? Awards { get; set; }
    }
}
