namespace TraktNET.Scrobbles
{
    public sealed class TraktEpisodeScrobblePostResponseTests
    {
        [Fact]
        public void TestTraktEpisodeScrobblePostResponseDefaultConstructor()
        {
            var episodeScrobbleResponse = new TraktEpisodeScrobblePostResponse();

            episodeScrobbleResponse.ID.ShouldBe(0UL);
            episodeScrobbleResponse.Action.ShouldBeNull();
            episodeScrobbleResponse.Progress.ShouldBeNull();
            episodeScrobbleResponse.Sharing.ShouldBeNull();
            episodeScrobbleResponse.Episode.ShouldBeNull();
            episodeScrobbleResponse.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeScrobblePostResponseFromJson()
        {
            TraktEpisodeScrobblePostResponse? episodeScrobbleResponse = await TestUtility.DeserializeJsonAsync<TraktEpisodeScrobblePostResponse>("Scrobbles\\episodescrobblepostresponse.json");

            episodeScrobbleResponse.ShouldNotBeNull();
            episodeScrobbleResponse.ID.ShouldBe(3373536623UL);
            episodeScrobbleResponse.Action.ShouldBe(TraktScrobbleActionType.Stop);
            episodeScrobbleResponse.Progress.ShouldBe(85.9f);
            episodeScrobbleResponse.Sharing.ShouldNotBeNull();
            episodeScrobbleResponse.Sharing.Twitter.ShouldBe(true);
            episodeScrobbleResponse.Sharing.Tumblr.ShouldBe(true);
            episodeScrobbleResponse.Episode.ShouldNotBeNull();
            episodeScrobbleResponse.Episode.Season.ShouldBe(1U);
            episodeScrobbleResponse.Episode.Number.ShouldBe(1U);
            episodeScrobbleResponse.Episode.Title.ShouldBe("Winter Is Coming");
            episodeScrobbleResponse.Episode.IDs.ShouldNotBeNull();
            episodeScrobbleResponse.Episode.IDs!.Trakt.ShouldBe(73640U);
            episodeScrobbleResponse.Episode.IDs!.TVDB.ShouldBe(3254641U);
            episodeScrobbleResponse.Episode.IDs!.IMDB.ShouldBe("tt1480055");
            episodeScrobbleResponse.Episode.IDs!.TMDB.ShouldBe(63056U);
            episodeScrobbleResponse.Show.ShouldNotBeNull();
            episodeScrobbleResponse.Show.Title.ShouldBe("Game of Thrones");
            episodeScrobbleResponse.Show.Year.ShouldBe(2011U);
            episodeScrobbleResponse.Show.IDs.ShouldNotBeNull();
            episodeScrobbleResponse.Show.IDs!.Trakt.ShouldBe(1390U);
            episodeScrobbleResponse.Show.IDs!.Slug.ShouldBe("game-of-thrones");
            episodeScrobbleResponse.Show.IDs!.TVDB.ShouldBe(121361U);
            episodeScrobbleResponse.Show.IDs!.IMDB.ShouldBe("tt0944947");
            episodeScrobbleResponse.Show.IDs!.TMDB.ShouldBe(1399U);
        }
    }
}
