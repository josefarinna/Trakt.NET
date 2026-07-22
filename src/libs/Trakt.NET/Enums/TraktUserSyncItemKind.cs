namespace TraktNET
{
    /// <summary>Determines the kind of sync item.</summary>
    [TraktEnum]
    public enum TraktUserSyncItemKind
    {
        /// <summary>An invalid sync item kind.</summary>
        Unspecified,

        /// <summary>History item kind.</summary>
        History,

        /// <summary>Rating item kind.</summary>
        Rating
    }
}
