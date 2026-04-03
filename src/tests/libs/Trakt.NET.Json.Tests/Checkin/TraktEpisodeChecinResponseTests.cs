namespace TraktNET.Json.Checkin
{
    public sealed class TraktEpisodeCheckinResponseTests
    {
        [Fact]
        public void TestTraktEpisodeCheckinResponseConstructor()
        {
            var response = new TraktEpisodeCheckinResponse();

            response.ID.ShouldBe(0UL);
            response.WatchedAt.ShouldBeNull();
            response.Sharing.ShouldBeNull();
            response.Episode.ShouldBeNull();
            response.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeCheckinResponseFromJson()
        {
            TraktEpisodeCheckinResponse? response = await TestUtility.DeserializeJsonAsync<TraktEpisodeCheckinResponse>("Checkin\\checkinepisode_response.json");

            response.ShouldNotBeNull();

            response!.ID.ShouldBe(3373536620UL);
            response!.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-06T01:11:37.000Z"));

            response!.Sharing.ShouldNotBeNull();
            response!.Sharing!.Twitter.ShouldBe(true);
            response!.Sharing!.Tumblr.ShouldBe(false);

            response!.Show.ShouldNotBeNull();
            response!.Show!.Title.ShouldBe("Breaking Bad");
            response!.Show!.Year.ShouldBe(2008U);
            response!.Show!.IDs.ShouldNotBeNull();
            response!.Show!.IDs!.Trakt.ShouldBe(1U);
            response!.Show!.IDs!.TVDB.ShouldBe(81189U);

            response!.Episode.ShouldNotBeNull();
            response!.Episode!.Season.ShouldBe(1U);
            response!.Episode!.Number.ShouldBe(1U);
        }
    }
}
