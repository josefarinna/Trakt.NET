namespace TraktNET
{
    /// <summary>Represents a streaming service where a collected item is available.</summary>
    public record class TraktSyncCollectionAvailableOn
    {
        /// <summary>Gets or sets the name of the streaming service.</summary>
        public string? Name { get; set; }
    }
}
