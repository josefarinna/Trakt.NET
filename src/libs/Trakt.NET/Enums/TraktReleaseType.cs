namespace TraktNET
{
    /// <summary>Determines, how a movie was released.</summary>
    [TraktEnum]
    public enum TraktReleaseType
    {
        /// <summary>An invalid release type.</summary>
        Unspecified,

        /// <summary>An unknown release type.</summary>
        Unknown,

        /// <summary>The release was a premiere.</summary>
        Premiere,

        /// <summary>The release was limited.</summary>
        Limited,

        /// <summary>The release was theatrical.</summary>
        Theatrical,

        /// <summary>The release was digital.</summary>
        Digital,

        /// <summary>The release was physical.</summary>
        Physical,

        /// <summary>The release was in TV.</summary>
        TV
    }
}
