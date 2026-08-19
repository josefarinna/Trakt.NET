using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktShowStatusTests
    {
        [Fact]
        public void TestTraktShowStatusToJson()
        {
            TraktShowStatus.Unspecified.ToJson().ShouldBeNull();
            TraktShowStatus.ReturningSeries.ToJson().ShouldBe("returning series");
            TraktShowStatus.Continuing.ToJson().ShouldBe("continuing");
            TraktShowStatus.InProduction.ToJson().ShouldBe("in production");
            TraktShowStatus.Planned.ToJson().ShouldBe("planned");
            TraktShowStatus.Upcoming.ToJson().ShouldBe("upcoming");
            TraktShowStatus.Pilot.ToJson().ShouldBe("pilot");
            TraktShowStatus.Canceled.ToJson().ShouldBe("canceled");
            TraktShowStatus.Ended.ToJson().ShouldBe("ended");
            ((TraktShowStatus)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktShowStatusFromJson()
        {
            "unspecified".ToTraktShowStatus().ShouldBe(TraktShowStatus.Unspecified);
            "returning series".ToTraktShowStatus().ShouldBe(TraktShowStatus.ReturningSeries);
            "continuing".ToTraktShowStatus().ShouldBe(TraktShowStatus.Continuing);
            "in production".ToTraktShowStatus().ShouldBe(TraktShowStatus.InProduction);
            "planned".ToTraktShowStatus().ShouldBe(TraktShowStatus.Planned);
            "upcoming".ToTraktShowStatus().ShouldBe(TraktShowStatus.Upcoming);
            "pilot".ToTraktShowStatus().ShouldBe(TraktShowStatus.Pilot);
            "canceled".ToTraktShowStatus().ShouldBe(TraktShowStatus.Canceled);
            "ended".ToTraktShowStatus().ShouldBe(TraktShowStatus.Ended);

            string? nullValue = null;
            nullValue.ToTraktShowStatus().ShouldBe(TraktShowStatus.Unspecified);
            "invalid".ToTraktShowStatus().ShouldBe(TraktShowStatus.Unspecified);
            "".ToTraktShowStatus().ShouldBe(TraktShowStatus.Unspecified);
        }

        [Fact]
        public void TestTraktShowStatusDisplayName()
        {
            TraktShowStatus.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktShowStatus.ReturningSeries.DisplayName().ShouldBe("Returning Series");
            TraktShowStatus.Continuing.DisplayName().ShouldBe("Continuing");
            TraktShowStatus.InProduction.DisplayName().ShouldBe("In Production");
            TraktShowStatus.Planned.DisplayName().ShouldBe("Planned");
            TraktShowStatus.Upcoming.DisplayName().ShouldBe("Upcoming");
            TraktShowStatus.Pilot.DisplayName().ShouldBe("Pilot");
            TraktShowStatus.Canceled.DisplayName().ShouldBe("Canceled");
            TraktShowStatus.Ended.DisplayName().ShouldBe("Ended");
            ((TraktShowStatus)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktShowStatusJsonConverter()
        {
            var converter = new TraktShowStatusJsonConverter();
            converter.CanConvert(typeof(TraktShowStatus)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktShowStatus.ReturningSeries, options).ShouldBe("\"returning series\"");
            JsonSerializer.Deserialize<TraktShowStatus>("\"returning series\"", options).ShouldBe(TraktShowStatus.ReturningSeries);
            JsonSerializer.Deserialize<TraktShowStatus>("\"\"", options).ShouldBe(TraktShowStatus.Unspecified);
        }
    }
}
