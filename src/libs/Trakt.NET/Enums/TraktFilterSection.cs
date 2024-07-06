namespace TraktNET
{
    /// <summary>Determines the filter section of saved filters.</summary>
    [TraktEnum]
    public enum TraktFilterSection
    {
        /// <summary>An invalid filter section.</summary>
        Unspecified,

        /// <summary>The filter section for movies.</summary>
        Movies,

        /// <summary>The filter section for shows.</summary>
        Shows,

        /// <summary>The filter section for calendars.</summary>
        Calendars,

        /// <summary>The filter section for search.</summary>
        Search
    }
}
