namespace TraktNET.Enums
{
    public sealed class TraktDateFormatTests
    {
        [Fact]
        public void TestTraktDateFormatToJson()
        {
            TraktDateFormat.Unspecified.ToJson().Should().BeNull();
            TraktDateFormat.MonthDayYear.ToJson().Should().Be("mdy");
            TraktDateFormat.DayMonthYear.ToJson().Should().Be("dmy");
            TraktDateFormat.YearMonthDay.ToJson().Should().Be("ymd");
            TraktDateFormat.YearDayMonth.ToJson().Should().Be("ydm");
        }

        [Fact]
        public void TestTraktDateFormatFromJson()
        {
            "unspecified".ToTraktDateFormat().Should().Be(TraktDateFormat.Unspecified);
            "mdy".ToTraktDateFormat().Should().Be(TraktDateFormat.MonthDayYear);
            "dmy".ToTraktDateFormat().Should().Be(TraktDateFormat.DayMonthYear);
            "ymd".ToTraktDateFormat().Should().Be(TraktDateFormat.YearMonthDay);
            "ydm".ToTraktDateFormat().Should().Be(TraktDateFormat.YearDayMonth);

            string? nullValue = null;
            nullValue.ToTraktDateFormat().Should().Be(TraktDateFormat.Unspecified);
        }

        [Fact]
        public void TestTraktDateFormatDisplayName()
        {
            TraktDateFormat.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktDateFormat.MonthDayYear.DisplayName().Should().Be("Month Day Year");
            TraktDateFormat.DayMonthYear.DisplayName().Should().Be("Day Month Year");
            TraktDateFormat.YearMonthDay.DisplayName().Should().Be("Year Month Day");
            TraktDateFormat.YearDayMonth.DisplayName().Should().Be("Year Day Month");
        }
    }
}
