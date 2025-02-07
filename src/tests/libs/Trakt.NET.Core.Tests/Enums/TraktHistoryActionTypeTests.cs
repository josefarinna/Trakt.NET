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
        }

        [Fact]
        public void TestTraktHistoryActionTypeDisplayName()
        {
            TraktHistoryActionType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktHistoryActionType.Scrobble.DisplayName().ShouldBe("Scrobble");
            TraktHistoryActionType.Checkin.DisplayName().ShouldBe("Checkin");
            TraktHistoryActionType.Watch.DisplayName().ShouldBe("Watch");
        }
    }
}
