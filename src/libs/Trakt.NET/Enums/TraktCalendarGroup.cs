namespace TraktNET
{
    /// <summary>Determines how calendar items are grouped.</summary>
    [TraktEnum(HasQuerySupport = true, QueryName = "group")]
    public enum TraktCalendarGroup
    {
        /// <summary>An invalid calendar group.</summary>
        Unspecified,

        /// <summary>Collapse same-show-same-day episodes into a single card.</summary>
        Day
    }
}
