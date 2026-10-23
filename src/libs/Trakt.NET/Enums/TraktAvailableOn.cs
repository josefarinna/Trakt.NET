namespace TraktNET
{
    /// <summary>Determines the media server or source where a collected item is available.</summary>
    [TraktEnum(HasQuerySupport = true, QueryName = "available_on")]
    public enum TraktAvailableOn
    {
        /// <summary>An invalid source.</summary>
        Unspecified,

        /// <summary>Items synced from a connected media server.</summary>
        Digital,

        /// <summary>Items not synced from a connected media server.</summary>
        Other,

        /// <summary>Items synced from a Plex media server.</summary>
        Plex,

        /// <summary>Items synced from a Jellyfin media server.</summary>
        Jellyfin
    }
}

