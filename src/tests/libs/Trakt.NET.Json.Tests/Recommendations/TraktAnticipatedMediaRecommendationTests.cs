namespace TraktNET.Json.Recommendations
{
    public sealed class TraktAnticipatedMediaRecommendationTests
    {
        [Fact]
        public void TestTraktAnticipatedMediaRecommendationConstructor()
        {
            var item = new TraktAnticipatedMediaRecommendation();

            item.Movie.ShouldBeNull();
            item.Show.ShouldBeNull();
            item.Score.ShouldBeNull();
            item.Released.ShouldBeNull();
            item.Type.ShouldBeNull();
            item.ToString().ShouldBe(string.Empty);
        }

        [Fact]
        public async Task TestTraktAnticipatedMediaRecommendationFromJson()
        {
            TraktAnticipatedMediaRecommendation? item = await TestUtility.DeserializeJsonAsync<TraktAnticipatedMediaRecommendation>("Recommendations\\anticipatedmediarecommendation.json");

            item.ShouldNotBeNull();
            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Dune: Part Three");
            item.Movie.Year.ShouldBe(2026U);
            item.Movie.IDs.ShouldNotBeNull();
            item.Movie.IDs.Trakt.ShouldBe(1U);
            item.Movie.IDs.Slug.ShouldBe("dune-part-three-2026");
            item.Show.ShouldBeNull();
            item.Score.ShouldBe(0.82f);
#if NET7_0_OR_GREATER
            item.Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            item.Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif
            item.Type.ShouldBe(TraktSearchResultType.Movie);
            item.ToString().ShouldBe(item.Movie.ToString());
        }

        [Fact]
        public async Task TestTraktAnticipatedMediaRecommendationListFromJson()
        {
            IReadOnlyList<TraktAnticipatedMediaRecommendation>? items = await TestUtility.DeserializeJsonListAsync<TraktAnticipatedMediaRecommendation>("Recommendations\\anticipatedmediarecommendations.json");

            items.ShouldNotBeNull();
            items.Count.ShouldBe(2);

            items[0].Movie.ShouldNotBeNull();
            items[0].Movie!.Title.ShouldBe("Dune: Part Three");
            items[0].Show.ShouldBeNull();
            items[0].Score.ShouldBe(0.9f);
#if NET7_0_OR_GREATER
            items[0].Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            items[0].Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif
            items[0].Type.ShouldBe(TraktSearchResultType.Movie);

            items[1].Movie.ShouldBeNull();
            items[1].Show.ShouldNotBeNull();
            items[1].Show!.Title.ShouldBe("Euphoria");
            items[1].Score.ShouldBe(0.5f);
            items[1].Released.ShouldBeNull();
            items[1].Type.ShouldBe(TraktSearchResultType.Show);
        }
    }
}

