namespace TraktNET.Json.Lists
{
    public sealed class TraktListIDsTests
    {
        [Fact]
        public void TestTraktListIDsConstructor()
        {
            var listIDs = new TraktListIDs();

            listIDs.Trakt.ShouldBeNull();
            listIDs.Slug.ShouldBeNull();

            listIDs.HasAnyID.ShouldBe(false);
            listIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktListIDsHasAnyId()
        {
            var listIDs = new TraktListIDs { Trakt = 1 };
            listIDs.HasAnyID.ShouldBeTrue();

            listIDs = new TraktListIDs { Slug = "slug" };
            listIDs.HasAnyID.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktListIDsBestID()
        {
            var listIDs = new TraktListIDs();

            string bestID = listIDs.BestID;
            bestID.ShouldNotBeNull();

            listIDs = new TraktListIDs { Trakt = 1 };

            bestID = listIDs.BestID;
            bestID.ShouldBe("1");

            listIDs = new TraktListIDs { Slug = "slug" };

            bestID = listIDs.BestID;
            bestID.ShouldBe("slug");

            listIDs = new TraktListIDs
            {
                Slug = "slug",
                Trakt = 1
            };

            bestID = listIDs.BestID;
            bestID.ShouldBe("slug");

            new TraktListIDs().BestID.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestTraktListIDsFromJson()
        {
            TraktListIDs? listIDs = await TestUtility.DeserializeJsonAsync<TraktListIDs>("Lists\\listids.json");

            listIDs.ShouldNotBeNull();

            listIDs!.Trakt.ShouldBe(1248149U);
            listIDs!.Slug.ShouldBe("marvel-cinematic-universe");

            listIDs!.HasAnyID.ShouldBe(true);
            listIDs!.BestID.ShouldBe("marvel-cinematic-universe");
        }
    }
}
