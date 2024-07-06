namespace TraktNET
{
    /// <summary>Determines the section, from which hidden items should be requested.</summary>
    [TraktEnum]
    public enum TraktHiddenItemsSection
    {
        /// <summary>An invalid section.</summary>
        Unspecified,

        /// <summary>The section for calendars.</summary>
        Calendar,

        /// <summary>The section for watched progress.</summary>
        ProgressWatched,

        /// <summary>The section for collected progress.</summary>
        ProgressCollected,

        /// <summary>The section for recommendations.</summary>
        Recommendations,

        /// <summary>The section for watched reset progress.</summary>
        ProgressWatchedReset,

        /// <summary>The section for watched reset progress.</summary>
        Comments
    }
}
