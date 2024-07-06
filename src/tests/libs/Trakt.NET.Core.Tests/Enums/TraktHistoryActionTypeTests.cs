namespace TraktNET.Enums
{
    public sealed class TraktHistoryActionTypeTests
    {
        [Fact]
        public void TestTraktHistoryActionTypeToJson()
        {
            TraktHistoryActionType.Unspecified.ToJson().Should().BeNull();
            TraktHistoryActionType.Scrobble.ToJson().Should().Be("scrobble");
            TraktHistoryActionType.Checkin.ToJson().Should().Be("checkin");
            TraktHistoryActionType.Watch.ToJson().Should().Be("watch");
        }

        [Fact]
        public void TestTraktHistoryActionTypeFromJson()
        {
            "unspecified".ToTraktHistoryActionType().Should().Be(TraktHistoryActionType.Unspecified);
            "scrobble".ToTraktHistoryActionType().Should().Be(TraktHistoryActionType.Scrobble);
            "checkin".ToTraktHistoryActionType().Should().Be(TraktHistoryActionType.Checkin);
            "watch".ToTraktHistoryActionType().Should().Be(TraktHistoryActionType.Watch);

            string? nullValue = null;
            nullValue.ToTraktHistoryActionType().Should().Be(TraktHistoryActionType.Unspecified);
        }

        [Fact]
        public void TestTraktHistoryActionTypeDisplayName()
        {
            TraktHistoryActionType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktHistoryActionType.Scrobble.DisplayName().Should().Be("Scrobble");
            TraktHistoryActionType.Checkin.DisplayName().Should().Be("Checkin");
            TraktHistoryActionType.Watch.DisplayName().Should().Be("Watch");
        }
    }
}
