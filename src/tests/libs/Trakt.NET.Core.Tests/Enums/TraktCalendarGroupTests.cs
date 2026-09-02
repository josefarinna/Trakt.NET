using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktCalendarGroupTests
    {
        [Fact]
        public void TestTraktCalendarGroupToJson()
        {
            TraktCalendarGroup.Unspecified.ToJson().ShouldBeNull();
            TraktCalendarGroup.Day.ToJson().ShouldBe("day");
            ((TraktCalendarGroup)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktCalendarGroupFromJson()
        {
            "unspecified".ToTraktCalendarGroup().ShouldBe(TraktCalendarGroup.Unspecified);
            "day".ToTraktCalendarGroup().ShouldBe(TraktCalendarGroup.Day);

            string? nullValue = null;
            nullValue.ToTraktCalendarGroup().ShouldBe(TraktCalendarGroup.Unspecified);
            "invalid".ToTraktCalendarGroup().ShouldBe(TraktCalendarGroup.Unspecified);
            "".ToTraktCalendarGroup().ShouldBe(TraktCalendarGroup.Unspecified);
        }

        [Fact]
        public void TestTraktCalendarGroupDisplayName()
        {
            TraktCalendarGroup.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCalendarGroup.Day.DisplayName().ShouldBe("Day");
            ((TraktCalendarGroup)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktCalendarGroupJsonConverter()
        {
            var converter = new TraktCalendarGroupJsonConverter();
            converter.CanConvert(typeof(TraktCalendarGroup)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCalendarGroup.Day, options).ShouldBe("\"day\"");
            JsonSerializer.Deserialize<TraktCalendarGroup>("\"day\"", options).ShouldBe(TraktCalendarGroup.Day);
            JsonSerializer.Deserialize<TraktCalendarGroup>("\"\"", options).ShouldBe(TraktCalendarGroup.Unspecified);
        }
    }
}
