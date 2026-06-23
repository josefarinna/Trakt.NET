namespace TraktNET.Json.Episodes
{
    public sealed class TraktepisodeIDsTests
    {
        [Fact]
        public void TestTraktEpisodeIDsConstructor()
        {
            var episodeIDs = new TraktEpisodeIDs();

            episodeIDs.Trakt.ShouldBeNull();
            episodeIDs.TVDB.ShouldBeNull();
            episodeIDs.IMDB.ShouldBeNull();
            episodeIDs.TMDB.ShouldBeNull();

            episodeIDs.HasAnyID.ShouldBe(false);
            episodeIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktEpisodeIDsHasAnyId()
        {
            var episodeIDs = new TraktEpisodeIDs { Trakt = 1 };
            episodeIDs.HasAnyID.ShouldBeTrue();

            episodeIDs = new TraktEpisodeIDs { Trakt = 0 };
            episodeIDs.HasAnyID.ShouldBeFalse();

            episodeIDs = new TraktEpisodeIDs { TVDB = 1 };
            episodeIDs.HasAnyID.ShouldBeTrue();

            episodeIDs = new TraktEpisodeIDs { TVDB = 0 };
            episodeIDs.HasAnyID.ShouldBeFalse();

            episodeIDs = new TraktEpisodeIDs { IMDB = "imdb" };
            episodeIDs.HasAnyID.ShouldBeTrue();

            episodeIDs = new TraktEpisodeIDs { TMDB = 1 };
            episodeIDs.HasAnyID.ShouldBeTrue();

            episodeIDs = new TraktEpisodeIDs { TMDB = 0 };
            episodeIDs.HasAnyID.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktEpisodeIDsGetBestID()
        {
            var episodeIDs = new TraktEpisodeIDs();

            var bestID = episodeIDs.BestID;
            bestID.ShouldNotBeNull();

            episodeIDs = new TraktEpisodeIDs { Trakt = 1 };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("1");

            episodeIDs = new TraktEpisodeIDs { Trakt = 0 };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("");

            episodeIDs = new TraktEpisodeIDs { TVDB = 1 };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("1");

            episodeIDs = new TraktEpisodeIDs { TVDB = 0 };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("");

            episodeIDs = new TraktEpisodeIDs { IMDB = "imdb" };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("imdb");

            episodeIDs = new TraktEpisodeIDs { TMDB = 1 };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("1");

            episodeIDs = new TraktEpisodeIDs { TMDB = 0 };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("");

            episodeIDs = new TraktEpisodeIDs
            {
                Trakt = 1,
                TVDB = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("1");

            episodeIDs = new TraktEpisodeIDs
            {
                TVDB = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("1");

            episodeIDs = new TraktEpisodeIDs
            {
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("imdb");

            episodeIDs = new TraktEpisodeIDs
            {
                TMDB = 1
            };

            bestID = episodeIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktepisodeIDsFromJson()
        {
            TraktEpisodeIDs? episodeIDs = await TestUtility.DeserializeJsonAsync<TraktEpisodeIDs>("Episodes\\episodeIDs.json");

            episodeIDs.ShouldNotBeNull();

            episodeIDs.Trakt.ShouldBe(73640U);
            episodeIDs.TVDB.ShouldBe(3254641U);
            episodeIDs.IMDB.ShouldBe("tt1480055");
            episodeIDs.TMDB.ShouldBe(63056U);

            episodeIDs.HasAnyID.ShouldBe(true);
            episodeIDs.BestID.ShouldBe("73640");
        }
    }
}
