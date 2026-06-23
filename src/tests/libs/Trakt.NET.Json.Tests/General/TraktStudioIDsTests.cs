namespace TraktNET.Json.General
{
    public sealed class TraktStudioIDsTests
    {
        [Fact]
        public void TestTraktStudioIDsConstructor()
        {
            var studioIDs = new TraktStudioIDs();

            studioIDs.Trakt.ShouldBeNull();
            studioIDs.Slug.ShouldBeNull();
            studioIDs.TMDB.ShouldBeNull();

            studioIDs.HasAnyID.ShouldBe(false);
            studioIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktStudioIDsHasAnyId()
        {
            var studioIDs = new TraktStudioIDs { Trakt = 1 };
            studioIDs.HasAnyID.ShouldBeTrue();

            studioIDs = new TraktStudioIDs { Slug = "slug" };
            studioIDs.HasAnyID.ShouldBeTrue();

            studioIDs = new TraktStudioIDs { TMDB = 1 };
            studioIDs.HasAnyID.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktStudioIDsGetBestID()
        {
            var studioIDs = new TraktStudioIDs();

            string bestID = studioIDs.BestID;
            bestID.ShouldNotBeNull();

            studioIDs = new TraktStudioIDs { Trakt = 1 };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("1");

            studioIDs = new TraktStudioIDs { Trakt = 0 };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("");

            studioIDs = new TraktStudioIDs { Slug = "slug" };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("slug");

            studioIDs = new TraktStudioIDs { TMDB = 1 };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("1");

            studioIDs = new TraktStudioIDs { TMDB = 0 };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("");

            studioIDs = new TraktStudioIDs
            {
                Slug = "slug",
                Trakt = 1,
                TMDB = 1
            };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("slug");

            studioIDs = new TraktStudioIDs
            {
                Trakt = 1,
                TMDB = 1
            };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("1");

            studioIDs = new TraktStudioIDs
            {
                TMDB = 1
            };

            bestID = studioIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktStudioIDsFromJson()
        {
            TraktStudioIDs? studioIDs = await TestUtility.DeserializeJsonAsync<TraktStudioIDs>("General\\studioids.json");

            studioIDs.ShouldNotBeNull();

            studioIDs!.Trakt.ShouldBe(181U);
            studioIDs!.Slug.ShouldBe("marvel-studios");
            studioIDs!.TMDB.ShouldBe(420U);

            studioIDs!.HasAnyID.ShouldBe(true);
            studioIDs!.BestID.ShouldBe("marvel-studios");
        }
    }
}
