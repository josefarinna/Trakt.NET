namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonIDsTests
    {
        [Fact]
        public void TestTraktSeasonIDsConstructor()
        {
            var seasonIDs = new TraktSeasonIDs();

            seasonIDs.Trakt.ShouldBeNull();
            seasonIDs.TVDB.ShouldBeNull();
            seasonIDs.TMDB.ShouldBeNull();

            seasonIDs.HasAnyID.ShouldBeFalse();
            seasonIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktSeasonIDsHasAnyId()
        {
            var seasonIDs = new TraktSeasonIDs { Trakt = 1 };
            seasonIDs.HasAnyID.ShouldBeTrue();

            seasonIDs = new TraktSeasonIDs { Trakt = 0 };
            seasonIDs.HasAnyID.ShouldBeFalse();

            seasonIDs = new TraktSeasonIDs { TVDB = 1 };
            seasonIDs.HasAnyID.ShouldBeTrue();

            seasonIDs = new TraktSeasonIDs { TVDB = 0 };
            seasonIDs.HasAnyID.ShouldBeFalse();

            seasonIDs = new TraktSeasonIDs { TMDB = 1 };
            seasonIDs.HasAnyID.ShouldBeTrue();

            seasonIDs = new TraktSeasonIDs { TMDB = 0 };
            seasonIDs.HasAnyID.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktSeasonIDsGetBestID()
        {
            var seasonIDs = new TraktSeasonIDs();

            var bestID = seasonIDs.BestID;
            bestID.ShouldNotBeNull();

            seasonIDs = new TraktSeasonIDs { Trakt = 1 };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("1");

            seasonIDs = new TraktSeasonIDs { Trakt = 0 };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("");

            seasonIDs = new TraktSeasonIDs { TVDB = 1 };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("1");

            seasonIDs = new TraktSeasonIDs { TVDB = 0 };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("");

            seasonIDs = new TraktSeasonIDs { TMDB = 1 };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("1");

            seasonIDs = new TraktSeasonIDs { TMDB = 0 };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("");

            seasonIDs = new TraktSeasonIDs
            {
                Trakt = 1,
                TVDB = 1,
                TMDB = 1
            };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("1");

            seasonIDs = new TraktSeasonIDs
            {
                TVDB = 1,
                TMDB = 1
            };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("1");

            seasonIDs = new TraktSeasonIDs
            {
                TMDB = 1
            };

            bestID = seasonIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktSeasonIDsFromJson()
        {
            TraktSeasonIDs? seasonIDs = await TestUtility.DeserializeJsonAsync<TraktSeasonIDs>("Seasons\\seasonids.json");

            seasonIDs.ShouldNotBeNull();

            seasonIDs.Trakt.ShouldBe(3963U);
            seasonIDs.TVDB.ShouldBe(364731U);
            seasonIDs.TMDB.ShouldBe(3624U);

            seasonIDs.HasAnyID.ShouldBeTrue();
            seasonIDs.BestID.ShouldBe("3963");
        }
    }
}
