namespace TraktNET
{
    /// <summary>Represents a source where a collected item is available.</summary>
    public record class TraktSyncCollectionAvailableOn
    {
        /// <summary>Gets or sets the available on source. See also <seealso cref="TraktAvailableOn" />.</summary>
        public TraktAvailableOn? Name { get; set; }
    }
}

