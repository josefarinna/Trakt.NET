namespace TraktNET
{
    /// <summary>An award in the award catalog.</summary>
    public record class TraktAwardCatalogAward : TraktAward
    {
        /// <summary>Gets or sets the award kind. See also <seealso cref="TraktAwardKind" />.</summary>
        public TraktAwardKind? Kind { get; set; }
    }
}
