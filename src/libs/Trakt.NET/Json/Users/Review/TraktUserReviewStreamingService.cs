namespace TraktNET
{
    /// <summary>Represents streaming service watch count details for a review period.</summary>
    public record class TraktUserReviewStreamingService
    {
        /// <summary>Gets or sets the source identifier of the streaming service.</summary>
        public string? Source { get; set; }

        /// <summary>Gets or sets the display name of the streaming service.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the count of shows watched on this service.</summary>
        public uint? Shows { get; set; }

        /// <summary>Gets or sets the count of movies watched on this service.</summary>
        public uint? Movies { get; set; }

        /// <summary>Gets or sets the total count of titles watched on this service.</summary>
        public uint? All { get; set; }
    }
}
