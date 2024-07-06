namespace TraktNET
{
    [TraktEnum]
    public enum TraktDateFormat
    {
        /// <summary>An invalid date format.</summary>
        Unspecified,

        /// <summary>The date format for Month Day Year.</summary>
        [TraktEnumMember("mdy")]
        MonthDayYear,

        /// <summary>The date format for Day Month Year.</summary>
        [TraktEnumMember("dmy")]
        DayMonthYear,

        /// <summary>The date format for Year Month Day.</summary>
        [TraktEnumMember("ymd")]
        YearMonthDay,

        /// <summary>The date format for Year Day Month.</summary>
        [TraktEnumMember("ydm")]
        YearDayMonth
    }
}
