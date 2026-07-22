namespace TraktNET.Json.Users
{
    public sealed class TraktUserActivityTests
    {
        [Fact]
        public void TestTraktUserActivityDefaultConstructor()
        {
            var userActivity = new TraktUserActivity();

            userActivity.Id.ShouldBeNull();
            userActivity.ActivityAt.ShouldBeNull();
            userActivity.Action.ShouldBeNull();
            userActivity.Type.ShouldBeNull();
            userActivity.User.ShouldBeNull();
            userActivity.UserRating.ShouldBeNull();
            userActivity.Movie.ShouldBeNull();
            userActivity.Show.ShouldBeNull();
            userActivity.Season.ShouldBeNull();
            userActivity.Episode.ShouldBeNull();
            userActivity.List.ShouldBeNull();
            userActivity.Comment.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserActivityFromJson()
        {
            IReadOnlyList<TraktUserActivity>? activities = await TestUtility.DeserializeJsonListAsync<TraktUserActivity>("Users\\activities.json");

            activities.ShouldNotBeNull();
            activities.Count.ShouldBe(1);

            TraktUserActivity userActivity = activities[0];
            userActivity.ShouldNotBeNull();
            userActivity.Id.ShouldBe(123456UL);
            userActivity.ActivityAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-11-20T12:00:00.000Z"));
            userActivity.Action.ShouldBe("scrobble");
            userActivity.Type.ShouldBe(TraktSyncItemType.Episode);

            userActivity.User.ShouldNotBeNull();
            userActivity.User.Username.ShouldBe("sean");
            userActivity.User.Private.ShouldBe(false);
            userActivity.User.Name.ShouldBe("Sean");
            userActivity.User.VIP.ShouldBe(true);
            userActivity.User.VIPEP.ShouldBe(false);

            userActivity.Episode.ShouldNotBeNull();
            userActivity.Episode.Season.ShouldBe(1U);
            userActivity.Episode.Number.ShouldBe(1U);
            userActivity.Episode.Title.ShouldBe("Pilot");

            userActivity.Show.ShouldNotBeNull();
            userActivity.Show.Title.ShouldBe("Breaking Bad");
            userActivity.Show.Year.ShouldBe(2008U);
        }
    }
}
