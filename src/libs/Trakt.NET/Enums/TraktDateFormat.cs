namespace TraktNET
{
    [TraktEnum]
    public enum TraktDateFormat
    {
        /// <summary>An invalid date format.</summary>
        Unspecified,

        /// <summary>The date format for Month Day Year.</summary>
        [TraktEnumMember(JsonValue = "mdy")]
        MonthDayYear,

        /// <summary>The date format for Day Month Year.</summary>
        [TraktEnumMember(JsonValue = "dmy")]
        DayMonthYear,

        /// <summary>The date format for Year Month Day.</summary>
        [TraktEnumMember(JsonValue = "ymd")]
        YearMonthDay,

        /// <summary>The date format for Year Day Month.</summary>
        [TraktEnumMember(JsonValue = "ydm")]
        YearDayMonth
    }
}
