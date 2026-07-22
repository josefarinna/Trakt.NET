namespace TraktNET
{
    /// <summary>Determines the type of data sync app filter.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktUserSyncType
    {
        /// <summary>An invalid sync type.</summary>
        Unspecified,

        /// <summary>Younify data sync.</summary>
        Younify,

        /// <summary>Plex data sync.</summary>
        Plex,

        /// <summary>Importer data sync.</summary>
        Import
    }
}
