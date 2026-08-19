using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktTimePeriodTests
    {
        [Fact]
        public void TestTraktTimePeriodToJson()
        {
            TraktTimePeriod.Unspecified.ToJson().ShouldBeNull();
            TraktTimePeriod.Daily.ToJson().ShouldBe("daily");
            TraktTimePeriod.Weekly.ToJson().ShouldBe("weekly");
            TraktTimePeriod.Monthly.ToJson().ShouldBe("monthly");
            TraktTimePeriod.Yearly.ToJson().ShouldBe("yearly");
            TraktTimePeriod.All.ToJson().ShouldBe("all");
            ((TraktTimePeriod)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktTimePeriodFromJson()
        {
            "unspecified".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Unspecified);
            "daily".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Daily);
            "weekly".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Weekly);
            "monthly".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Monthly);
            "yearly".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Yearly);
            "all".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.All);

            string? nullValue = null;
            nullValue.ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Unspecified);
            "invalid".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Unspecified);
            "".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Unspecified);
        }

        [Fact]
        public void TestTraktTimePeriodDisplayName()
        {
            TraktTimePeriod.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktTimePeriod.Daily.DisplayName().ShouldBe("Daily");
            TraktTimePeriod.Weekly.DisplayName().ShouldBe("Weekly");
            TraktTimePeriod.Monthly.DisplayName().ShouldBe("Monthly");
            TraktTimePeriod.Yearly.DisplayName().ShouldBe("Yearly");
            TraktTimePeriod.All.DisplayName().ShouldBe("All");
            ((TraktTimePeriod)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktTimePeriodJsonConverter()
        {
            var converter = new TraktTimePeriodJsonConverter();
            converter.CanConvert(typeof(TraktTimePeriod)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktTimePeriod.Daily, options).ShouldBe("\"daily\"");
            JsonSerializer.Deserialize<TraktTimePeriod>("\"daily\"", options).ShouldBe(TraktTimePeriod.Daily);
            JsonSerializer.Deserialize<TraktTimePeriod>("\"\"", options).ShouldBe(TraktTimePeriod.Unspecified);
        }
    }
}
