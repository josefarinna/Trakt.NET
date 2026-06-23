namespace TraktNET.Json.Networks
{
    public sealed partial class TraktNetworkIDsTests
    {
        [Fact]
        public void TestTraktNetworkIDsDefaultConstructor()
        {
            var networkIDs = new TraktNetworkIDs();

            networkIDs.Trakt.ShouldBeNull();
            networkIDs.TMDB.ShouldBeNull();

            networkIDs.HasAnyID.ShouldBeFalse();
            networkIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktNetworkIDsHasAnyId()
        {
            var networkIDs = new TraktNetworkIDs { Trakt = 1 };
            networkIDs.HasAnyID.ShouldBeTrue();

            networkIDs = new TraktNetworkIDs { Trakt = 0 };
            networkIDs.HasAnyID.ShouldBeFalse();

            networkIDs = new TraktNetworkIDs { TMDB = 1 };
            networkIDs.HasAnyID.ShouldBeTrue();

            networkIDs = new TraktNetworkIDs { TMDB = 0 };
            networkIDs.HasAnyID.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktNetworkIDsGetBestID()
        {
            var networkIDs = new TraktNetworkIDs();

            var bestID = networkIDs.BestID;
            bestID.ShouldNotBeNull();

            networkIDs = new TraktNetworkIDs { Trakt = 1 };

            bestID = networkIDs.BestID;
            bestID.ShouldBe("1");

            networkIDs = new TraktNetworkIDs { Trakt = 0 };

            bestID = networkIDs.BestID;
            bestID.ShouldBe("");

            networkIDs = new TraktNetworkIDs { TMDB = 1 };

            bestID = networkIDs.BestID;
            bestID.ShouldBe("1");

            networkIDs = new TraktNetworkIDs { TMDB = 0 };

            bestID = networkIDs.BestID;
            bestID.ShouldBe("");

            networkIDs = new TraktNetworkIDs
            {
                Trakt = 1,
                TMDB = 1
            };

            bestID = networkIDs.BestID;
            bestID.ShouldBe("1");

            networkIDs = new TraktNetworkIDs
            {
                TMDB = 1
            };

            bestID = networkIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktNetworkIDsFromJson()
        {
            TraktNetworkIDs? networkIDs = await TestUtility.DeserializeJsonAsync<TraktNetworkIDs>("Networks\\networkids.json");

            networkIDs.ShouldNotBeNull();
            networkIDs.Trakt.ShouldBe(869U);
            networkIDs.TMDB.ShouldBe(1446U);

            networkIDs.HasAnyID.ShouldBeTrue();
            networkIDs.BestID.ShouldBe("869");
        }
    }
}
