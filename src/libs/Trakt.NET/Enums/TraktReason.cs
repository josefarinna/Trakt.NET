namespace TraktNET
{
    /// <summary>Determines the report reason.</summary>
    [TraktEnum]
    public enum TraktReason
    {
        /// <summary>An unspecified report reason.</summary>
        Unspecified,

        /// <summary>A user is reported by spam.</summary>
        Spam,

        /// <summary>A user is reported for adult content in their profile.</summary>
        Adult,

        /// <summary>A user is reported for using not English language.</summary>
        Language,

        /// <summary>Other report reason.</summary>
        Other
    }
}
