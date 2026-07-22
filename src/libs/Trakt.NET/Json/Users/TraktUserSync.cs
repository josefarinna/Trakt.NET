namespace TraktNET
{
    /// <summary>Represents a user data sync.</summary>
    public record class TraktUserSync
    {
        /// <summary>Gets or sets the sync ID.</summary>
        public ulong Id { get; set; }

        /// <summary>Gets or sets the UTC datetime when the sync ran.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the sync kind.</summary>
        public TraktUserSyncType? Kind { get; set; }

        /// <summary>Gets or sets the source of the sync.</summary>
        public string? Source { get; set; }

        /// <summary>Gets or sets the application name that created the sync.</summary>
        public string? Application { get; set; }

        /// <summary>Gets or sets whether the sync was undone.</summary>
        public bool? Undone { get; set; }

        /// <summary>Gets or sets the UTC datetime when the sync was reversed.</summary>
        public DateTime? UndoneAt { get; set; }

        /// <summary>Gets or sets the added counts per section.</summary>
        public TraktUserSyncItemsCount? Items { get; set; }

        /// <summary>Gets or sets the paused item count.</summary>
        public uint? PausedCount { get; set; }

        /// <summary>Gets or sets the skipped item count.</summary>
        public uint? SkippedCount { get; set; }
    }
}
