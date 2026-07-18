namespace TraktNET
{
    /// <summary>Represents a Younify streaming service connection.</summary>
    public record class TraktYounifyConnection
    {
        /// <summary>Gets or sets the streaming service id (e.g. "netflix").</summary>
        public string? Id { get; set; }

        /// <summary>Gets or sets the display name of the streaming service.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets whether the service requires Trakt VIP. <c>false</c> is the free tier.</summary>
        public bool? Vip { get; set; }

        /// <summary>Gets or sets the brand color of the streaming service.</summary>
        public string? Color { get; set; }

        /// <summary>Gets or sets the images for the streaming service.</summary>
        public TraktYounifyConnectionImages? Images { get; set; }

        /// <summary>Gets or sets whether the current user may connect this service (VIP gating).</summary>
        public bool? Connectable { get; set; }

        /// <summary>Gets or sets whether the service is linked for the current user.</summary>
        public bool? Connected { get; set; }

        /// <summary>Gets or sets whether the link is healthy. <c>false</c> means a broken link.</summary>
        public bool? Active { get; set; }

        /// <summary>Gets or sets the connected profile name, or <c>null</c> when not connected.</summary>
        public string? Profile { get; set; }

        /// <summary>Gets or sets when the service last synced, normalized to <c>.000Z</c>, or <c>null</c> when not connected.</summary>
        public string? LastSyncedAt { get; set; }
    }
}
