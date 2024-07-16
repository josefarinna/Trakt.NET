namespace TraktNET
{
    /// <summary>Determines the time period for most played, most watched and most collected movie and show requests.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktTimePeriod
    {
        /// <summary>An invalid time period.</summary>
        Unspecified,

        /// <summary>A daily time period.</summary>
        Daily,

        /// <summary>A weekly time period.</summary>
        Weekly,

        /// <summary>A monthly time period.</summary>
        Monthly,

        /// <summary>An yearly time period.</summary>
        Yearly,

        /// <summary>An overall time period.</summary>
        All
    }
}
