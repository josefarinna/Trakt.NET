namespace TraktNET.Json.Shows
{
    public sealed class TraktShowIDsTests
    {
        [Fact]
        public void TestTraktShowIDsConstructor()
        {
            var showIDs = new TraktShowIDs();

            showIDs.Trakt.ShouldBeNull();
            showIDs.Slug.ShouldBeNull();
            showIDs.TVDB.ShouldBeNull();
            showIDs.IMDB.ShouldBeNull();
            showIDs.TMDB.ShouldBeNull();

            showIDs.HasAnyID.ShouldBe(false);
            showIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktShowIDsHasAnyId()
        {
            var showIDs = new TraktShowIDs { Trakt = 1 };
            showIDs.HasAnyID.ShouldBeTrue();

            showIDs = new TraktShowIDs { Trakt = 0 };
            showIDs.HasAnyID.ShouldBeFalse();

            showIDs = new TraktShowIDs { Slug = "slug" };
            showIDs.HasAnyID.ShouldBeTrue();

            showIDs = new TraktShowIDs { TVDB = 1 };
            showIDs.HasAnyID.ShouldBeTrue();

            showIDs = new TraktShowIDs { TVDB = 0 };
            showIDs.HasAnyID.ShouldBeFalse();

            showIDs = new TraktShowIDs { IMDB = "imdb" };
            showIDs.HasAnyID.ShouldBeTrue();

            showIDs = new TraktShowIDs { TMDB = 1 };
            showIDs.HasAnyID.ShouldBeTrue();

            showIDs = new TraktShowIDs { TMDB = 0 };
            showIDs.HasAnyID.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktShowIDsGetBestID()
        {
            var showIDs = new TraktShowIDs();

            string bestID = showIDs.BestID;
            bestID.ShouldNotBeNull();

            showIDs = new TraktShowIDs { Trakt = 1 };

            bestID = showIDs.BestID;
            bestID.ShouldBe("1");

            showIDs = new TraktShowIDs { Trakt = 0 };

            bestID = showIDs.BestID;
            bestID.ShouldBe("");

            showIDs = new TraktShowIDs { TVDB = 1 };

            bestID = showIDs.BestID;
            bestID.ShouldBe("1");

            showIDs = new TraktShowIDs { TVDB = 0 };

            bestID = showIDs.BestID;
            bestID.ShouldBe("");

            showIDs = new TraktShowIDs { Slug = "slug" };

            bestID = showIDs.BestID;
            bestID.ShouldBe("slug");

            showIDs = new TraktShowIDs { IMDB = "imdb" };

            bestID = showIDs.BestID;
            bestID.ShouldBe("imdb");

            showIDs = new TraktShowIDs { TMDB = 1 };

            bestID = showIDs.BestID;
            bestID.ShouldBe("1");

            showIDs = new TraktShowIDs { TMDB = 0 };

            bestID = showIDs.BestID;
            bestID.ShouldBe("");

            showIDs = new TraktShowIDs
            {
                Slug = "slug",
                Trakt = 1,
                TVDB = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = showIDs.BestID;
            bestID.ShouldBe("slug");

            showIDs = new TraktShowIDs
            {
                Trakt = 1,
                TVDB = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = showIDs.BestID;
            bestID.ShouldBe("1");

            showIDs = new TraktShowIDs
            {
                TVDB = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = showIDs.BestID;
            bestID.ShouldBe("1");

            showIDs = new TraktShowIDs
            {
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = showIDs.BestID;
            bestID.ShouldBe("imdb");

            showIDs = new TraktShowIDs
            {
                TMDB = 1
            };

            bestID = showIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktShowIDsFromJson()
        {
            TraktShowIDs? showIDs = await TestUtility.DeserializeJsonAsync<TraktShowIDs>("Shows\\showids.json");

            showIDs.ShouldNotBeNull();

            showIDs.Trakt.ShouldBe(1390U);
            showIDs.Slug.ShouldBe("game-of-thrones");
            showIDs.TVDB.ShouldBe(121361U);
            showIDs.IMDB.ShouldBe("tt0944947");
            showIDs.TMDB.ShouldBe(1399U);

            showIDs.HasAnyID.ShouldBe(true);
            showIDs.BestID.ShouldBe("game-of-thrones");
        }
    }
}
