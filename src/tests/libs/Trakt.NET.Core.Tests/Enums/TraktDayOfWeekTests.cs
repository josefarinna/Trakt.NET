using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktDayOfWeekTests
    {
        [Fact]
        public void TestTraktDayOfWeekToJson()
        {
            TraktDayOfWeek.Unspecified.ToJson().ShouldBeNull();
            TraktDayOfWeek.Monday.ToJson().ShouldBe("Monday");
            TraktDayOfWeek.Tuesday.ToJson().ShouldBe("Tuesday");
            TraktDayOfWeek.Wednesday.ToJson().ShouldBe("Wednesday");
            TraktDayOfWeek.Thursday.ToJson().ShouldBe("Thursday");
            TraktDayOfWeek.Friday.ToJson().ShouldBe("Friday");
            TraktDayOfWeek.Saturday.ToJson().ShouldBe("Saturday");
            TraktDayOfWeek.Sunday.ToJson().ShouldBe("Sunday");
            ((TraktDayOfWeek)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktDayOfWeekFromJson()
        {
            "unspecified".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Unspecified);
            "Monday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Monday);
            "Tuesday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Tuesday);
            "Wednesday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Wednesday);
            "Thursday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Thursday);
            "Friday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Friday);
            "Saturday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Saturday);
            "Sunday".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Sunday);

            string? nullValue = null;
            nullValue.ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Unspecified);
            "invalid".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Unspecified);
            "".ToTraktDayOfWeek().ShouldBe(TraktDayOfWeek.Unspecified);
        }

        [Fact]
        public void TestTraktDayOfWeekDisplayName()
        {
            TraktDayOfWeek.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktDayOfWeek.Monday.DisplayName().ShouldBe("Monday");
            TraktDayOfWeek.Tuesday.DisplayName().ShouldBe("Tuesday");
            TraktDayOfWeek.Wednesday.DisplayName().ShouldBe("Wednesday");
            TraktDayOfWeek.Thursday.DisplayName().ShouldBe("Thursday");
            TraktDayOfWeek.Friday.DisplayName().ShouldBe("Friday");
            TraktDayOfWeek.Saturday.DisplayName().ShouldBe("Saturday");
            TraktDayOfWeek.Sunday.DisplayName().ShouldBe("Sunday");
            ((TraktDayOfWeek)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktDayOfWeekJsonConverter()
        {
            var converter = new TraktDayOfWeekJsonConverter();
            converter.CanConvert(typeof(TraktDayOfWeek)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktDayOfWeek.Monday, options).ShouldBe("\"Monday\"");
            JsonSerializer.Deserialize<TraktDayOfWeek>("\"Monday\"", options).ShouldBe(TraktDayOfWeek.Monday);
            JsonSerializer.Deserialize<TraktDayOfWeek>("\"\"", options).ShouldBe(TraktDayOfWeek.Unspecified);
        }
    }
}
