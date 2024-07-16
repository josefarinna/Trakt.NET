namespace TraktNET
{
    /// <summary>Determines the last activity type of a collection or watched progress.</summary>
    [TraktEnum(HasQuerySupport = true, QueryName = "last_activity")]
    public enum TraktLastActivity
    {
        /// <summary>An invalid last activity type.</summary>
        Unspecified,

        /// <summary>Use last collected episodes while calculating collection or watched progress.</summary>
        Collected,

        /// <summary>Use last aired episodes while calculating collection or watched progress.</summary>
        Aired,

        /// <summary>Use last watched episodes while calculating collection or watched progress.</summary>
        Watched
    }
}
