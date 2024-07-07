namespace TraktNET
{
    /// <summary>Determines the day of a week.</summary>
    [TraktEnum]
    public enum TraktDayOfWeek
    {
        /// <summary>An invalid weekday.</summary>
        Unspecified,

        /// <summary>The weekday is monday.</summary>
        [TraktEnumMember(JsonValue = "Monday")]
        Monday,

        /// <summary>The weekday is tuesday.</summary>
        [TraktEnumMember(JsonValue = "Tuesday")]
        Tuesday,

        /// <summary>The weekday is wednesday.</summary>
        [TraktEnumMember(JsonValue = "Wednesday")]
        Wednesday,

        /// <summary>The weekday is thursday.</summary>
        [TraktEnumMember(JsonValue = "Thursday")]
        Thursday,

        /// <summary>The weekday is friday.</summary>
        [TraktEnumMember(JsonValue = "Friday")]
        Friday,

        /// <summary>The weekday is saturday.</summary>
        [TraktEnumMember(JsonValue = "Saturday")]
        Saturday,

        /// <summary>The weekday is sunday.</summary>
        [TraktEnumMember(JsonValue = "Sunday")]
        Sunday
    }
}
