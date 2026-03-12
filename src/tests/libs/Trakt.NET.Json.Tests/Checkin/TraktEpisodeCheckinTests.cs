namespace TraktNET.Json.Checkin
{
    public sealed class TraktEpisodeCheckinTests
    {
        [Fact]
        public void TestTraktEpisodeCheckinConstructor()
        {
            var episodeCheckin = new TraktEpisodeCheckin
            {
                Episode = new TraktEpisode()
            };

            episodeCheckin.Show.ShouldBeNull();
            episodeCheckin.Sharing.ShouldBeNull();
            episodeCheckin.Message.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeCheckinFromJsonMinimal()
        {
            TraktEpisodeCheckin? episodeCheckin = await TestUtility.DeserializeJsonAsync<TraktEpisodeCheckin>("Checkin\\checkinepisode_minimal.json");

            episodeCheckin.ShouldNotBeNull();

            episodeCheckin!.Episode.ShouldNotBeNull();
            episodeCheckin!.Episode.IDs.ShouldNotBeNull();
            episodeCheckin!.Episode.IDs!.Trakt.ShouldBe(16U);

            episodeCheckin!.Message.ShouldBe("I'm the one who knocks!");

            episodeCheckin!.Sharing.ShouldNotBeNull();
            episodeCheckin!.Sharing!.Twitter.ShouldBe(true);
            episodeCheckin!.Sharing!.Tumblr.ShouldBe(false);

            episodeCheckin!.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeCheckinFromJsonFull()
        {
            TraktEpisodeCheckin? episodeCheckin = await TestUtility.DeserializeJsonAsync<TraktEpisodeCheckin>("Checkin\\checkinepisode.json");

            episodeCheckin.ShouldNotBeNull();

            episodeCheckin!.Show.ShouldNotBeNull();
            episodeCheckin!.Show!.Title.ShouldBe("Breaking Bad");
            episodeCheckin!.Show!.Year.ShouldBe(2008U);
            episodeCheckin!.Show!.IDs.ShouldNotBeNull();
            episodeCheckin!.Show!.IDs!.Trakt.ShouldBe(1U);
            episodeCheckin!.Show!.IDs!.TVDB.ShouldBe(81189U);

            episodeCheckin!.Episode.ShouldNotBeNull();
            episodeCheckin!.Episode.Season.ShouldBe(1U);
            episodeCheckin!.Episode.Number.ShouldBe(1U);

            episodeCheckin!.Sharing.ShouldNotBeNull();
            episodeCheckin!.Sharing!.Twitter.ShouldBe(true);
            episodeCheckin!.Sharing!.Tumblr.ShouldBe(false);

            episodeCheckin!.Message.ShouldBe("I'm the one who knocks!");
        }
    }
}
