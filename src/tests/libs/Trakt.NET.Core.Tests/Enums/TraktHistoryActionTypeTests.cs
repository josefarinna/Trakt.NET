using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktHistoryActionTypeTests
    {
        [Fact]
        public void TestTraktHistoryActionTypeToJson()
        {
            TraktHistoryActionType.Unspecified.ToJson().ShouldBeNull();
            TraktHistoryActionType.Scrobble.ToJson().ShouldBe("scrobble");
            TraktHistoryActionType.Checkin.ToJson().ShouldBe("checkin");
            TraktHistoryActionType.Watch.ToJson().ShouldBe("watch");
            ((TraktHistoryActionType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktHistoryActionTypeFromJson()
        {
            "unspecified".ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Unspecified);
            "scrobble".ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Scrobble);
            "checkin".ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Checkin);
            "watch".ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Watch);

            string? nullValue = null;
            nullValue.ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Unspecified);
            "invalid".ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Unspecified);
            "".ToTraktHistoryActionType().ShouldBe(TraktHistoryActionType.Unspecified);
        }

        [Fact]
        public void TestTraktHistoryActionTypeDisplayName()
        {
            TraktHistoryActionType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktHistoryActionType.Scrobble.DisplayName().ShouldBe("Scrobble");
            TraktHistoryActionType.Checkin.DisplayName().ShouldBe("Checkin");
            TraktHistoryActionType.Watch.DisplayName().ShouldBe("Watch");
            ((TraktHistoryActionType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktHistoryActionTypeJsonConverter()
        {
            var converter = new TraktHistoryActionTypeJsonConverter();
            converter.CanConvert(typeof(TraktHistoryActionType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktHistoryActionType.Scrobble, options).ShouldBe("\"scrobble\"");
            JsonSerializer.Deserialize<TraktHistoryActionType>("\"scrobble\"", options).ShouldBe(TraktHistoryActionType.Scrobble);
            JsonSerializer.Deserialize<TraktHistoryActionType>("\"\"", options).ShouldBe(TraktHistoryActionType.Unspecified);
        }
    }
}
