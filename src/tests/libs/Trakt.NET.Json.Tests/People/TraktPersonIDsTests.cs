namespace TraktNET.Json.People
{
    public sealed class TraktPersonIDsTests
    {
        [Fact]
        public void TestTraktPersonIDsConstructor()
        {
            var personIDs = new TraktPersonIDs();

            personIDs.Trakt.ShouldBeNull();
            personIDs.Slug.ShouldBeNull();
            personIDs.IMDB.ShouldBeNull();
            personIDs.TMDB.ShouldBeNull();

            personIDs.HasAnyID.ShouldBe(false);
            personIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktPersonIDsHasAnyId()
        {
            var personIDs = new TraktPersonIDs { Trakt = 1 };
            personIDs.HasAnyID.ShouldBeTrue();

            personIDs = new TraktPersonIDs { Trakt = 0 };
            personIDs.HasAnyID.ShouldBeFalse();

            personIDs = new TraktPersonIDs { Slug = "slug" };
            personIDs.HasAnyID.ShouldBeTrue();

            personIDs = new TraktPersonIDs { IMDB = "imdb" };
            personIDs.HasAnyID.ShouldBeTrue();

            personIDs = new TraktPersonIDs { TMDB = 1 };
            personIDs.HasAnyID.ShouldBeTrue();

            personIDs = new TraktPersonIDs { TMDB = 0 };
            personIDs.HasAnyID.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktPersonIDsGetBestID()
        {
            var personIDs = new TraktPersonIDs();

            string bestID = personIDs.BestID;
            bestID.ShouldNotBeNull();

            personIDs = new TraktPersonIDs { Trakt = 1 };

            bestID = personIDs.BestID;
            bestID.ShouldBe("1");

            personIDs = new TraktPersonIDs { Trakt = 0 };

            bestID = personIDs.BestID;
            bestID.ShouldBe("");

            personIDs = new TraktPersonIDs { Slug = "slug" };

            bestID = personIDs.BestID;
            bestID.ShouldBe("slug");

            personIDs = new TraktPersonIDs { IMDB = "imdb" };

            bestID = personIDs.BestID;
            bestID.ShouldBe("imdb");

            personIDs = new TraktPersonIDs { TMDB = 1 };

            bestID = personIDs.BestID;
            bestID.ShouldBe("1");

            personIDs = new TraktPersonIDs { TMDB = 0 };

            bestID = personIDs.BestID;
            bestID.ShouldBe("");

            personIDs = new TraktPersonIDs
            {
                Slug = "slug",
                Trakt = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = personIDs.BestID;
            bestID.ShouldBe("slug");

            personIDs = new TraktPersonIDs
            {
                Trakt = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = personIDs.BestID;
            bestID.ShouldBe("1");

            personIDs = new TraktPersonIDs
            {
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = personIDs.BestID;
            bestID.ShouldBe("imdb");

            personIDs = new TraktPersonIDs
            {
                TMDB = 1
            };

            bestID = personIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktPersonIDsFromJson()
        {
            TraktPersonIDs? personIDs = await TestUtility.DeserializeJsonAsync<TraktPersonIDs>("People\\personids.json");

            personIDs.ShouldNotBeNull();

            personIDs!.Trakt.ShouldBe(297737U);
            personIDs!.Slug.ShouldBe("bryan-cranston");
            personIDs!.IMDB.ShouldBe("nm0186505");
            personIDs!.TMDB.ShouldBe(17419U);

            personIDs!.HasAnyID.ShouldBe(true);
            personIDs!.BestID.ShouldBe("bryan-cranston");
        }
    }
}
