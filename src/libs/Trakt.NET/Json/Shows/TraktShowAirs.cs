namespace TraktNET
{
    /// <summary>The air time of a Trakt show.</summary>
    public record class TraktShowAirs
    {
        /// <summary>The day of week on which the show airs. See also <seealso cref="TraktDayOfWeek" />.</summary>
        public TraktDayOfWeek? Day { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>The time of day at which the show airs.</summary>
        public TimeOnly? Time { get; set; }
#else
        /// <summary>The time of day at which the show airs.</summary>
        public string? Time { get; set; }
#endif

        /// <summary>The time zone ID (Olson) for the location in which the show airs.</summary>
        public string? Timezone { get; set; }
    }
}
