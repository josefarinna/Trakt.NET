namespace TraktNET
{
    /// <summary>Determines the media type in a calendar feed.</summary>
    [TraktEnum(HasQuerySupport = true, QueryName = "type")]
    public enum TraktCalendarMediaType
    {
        /// <summary>An invalid media type.</summary>
        Unspecified,

        /// <summary>The calendar contains movies.</summary>
        Movie,

        /// <summary>The calendar contains shows.</summary>
        Show
    }
}
