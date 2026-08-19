using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktDateFormatTests
    {
        [Fact]
        public void TestTraktDateFormatToJson()
        {
            TraktDateFormat.Unspecified.ToJson().ShouldBeNull();
            TraktDateFormat.MonthDayYear.ToJson().ShouldBe("mdy");
            TraktDateFormat.DayMonthYear.ToJson().ShouldBe("dmy");
            TraktDateFormat.YearMonthDay.ToJson().ShouldBe("ymd");
            TraktDateFormat.YearDayMonth.ToJson().ShouldBe("ydm");
            ((TraktDateFormat)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktDateFormatFromJson()
        {
            "unspecified".ToTraktDateFormat().ShouldBe(TraktDateFormat.Unspecified);
            "mdy".ToTraktDateFormat().ShouldBe(TraktDateFormat.MonthDayYear);
            "dmy".ToTraktDateFormat().ShouldBe(TraktDateFormat.DayMonthYear);
            "ymd".ToTraktDateFormat().ShouldBe(TraktDateFormat.YearMonthDay);
            "ydm".ToTraktDateFormat().ShouldBe(TraktDateFormat.YearDayMonth);

            string? nullValue = null;
            nullValue.ToTraktDateFormat().ShouldBe(TraktDateFormat.Unspecified);
            "invalid".ToTraktDateFormat().ShouldBe(TraktDateFormat.Unspecified);
            "".ToTraktDateFormat().ShouldBe(TraktDateFormat.Unspecified);
        }

        [Fact]
        public void TestTraktDateFormatDisplayName()
        {
            TraktDateFormat.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktDateFormat.MonthDayYear.DisplayName().ShouldBe("Month Day Year");
            TraktDateFormat.DayMonthYear.DisplayName().ShouldBe("Day Month Year");
            TraktDateFormat.YearMonthDay.DisplayName().ShouldBe("Year Month Day");
            TraktDateFormat.YearDayMonth.DisplayName().ShouldBe("Year Day Month");
            ((TraktDateFormat)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktDateFormatJsonConverter()
        {
            var converter = new TraktDateFormatJsonConverter();
            converter.CanConvert(typeof(TraktDateFormat)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktDateFormat.MonthDayYear, options).ShouldBe("\"mdy\"");
            JsonSerializer.Deserialize<TraktDateFormat>("\"mdy\"", options).ShouldBe(TraktDateFormat.MonthDayYear);
            JsonSerializer.Deserialize<TraktDateFormat>("\"\"", options).ShouldBe(TraktDateFormat.Unspecified);
        }
    }
}
