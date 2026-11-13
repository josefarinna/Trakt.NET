namespace TraktNET.Json.Recommendations
{
    public sealed class TraktAnticipatedMovieRecommendationTests
    {
        [Fact]
        public void TestTraktAnticipatedMovieRecommendationConstructor()
        {
            var item = new TraktAnticipatedMovieRecommendation();

            item.Movie.ShouldBeNull();
            item.Score.ShouldBeNull();
            item.Released.ShouldBeNull();
            item.ToString().ShouldBe(string.Empty);
        }

        [Fact]
        public async Task TestTraktAnticipatedMovieRecommendationFromJson()
        {
            TraktAnticipatedMovieRecommendation? item = await TestUtility.DeserializeJsonAsync<TraktAnticipatedMovieRecommendation>("Recommendations\\anticipatedmovierecommendation.json");

            item.ShouldNotBeNull();
            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Dune: Part Three");
            item.Movie.Year.ShouldBe(2026U);
            item.Movie.IDs.ShouldNotBeNull();
            item.Movie.IDs.Trakt.ShouldBe(1U);
            item.Movie.IDs.Slug.ShouldBe("dune-part-three-2026");
            item.Score.ShouldBe(0.82f);
#if NET7_0_OR_GREATER
            item.Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            item.Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif
            item.ToString().ShouldBe(item.Movie.ToString());
        }

        [Fact]
        public async Task TestTraktAnticipatedMovieRecommendationListFromJson()
        {
            IReadOnlyList<TraktAnticipatedMovieRecommendation>? items = await TestUtility.DeserializeJsonListAsync<TraktAnticipatedMovieRecommendation>("Recommendations\\anticipatedmovierecommendations.json");

            items.ShouldNotBeNull();
            items.Count.ShouldBe(2);

            items[0].Movie.ShouldNotBeNull();
            items[0].Movie!.Title.ShouldBe("Dune: Part Three");
            items[0].Score.ShouldBe(0.82f);
#if NET7_0_OR_GREATER
            items[0].Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            items[0].Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif

            items[1].Movie.ShouldNotBeNull();
            items[1].Movie!.Title.ShouldBe("Blade Runner 2099");
            items[1].Score.ShouldBe(0.75f);
            items[1].Released.ShouldBeNull();
        }
    }
}

