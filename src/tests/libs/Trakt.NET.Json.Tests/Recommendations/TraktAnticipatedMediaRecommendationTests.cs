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
        public void TestTraktAnticipatedMediaRecommendationToStringWithShow()
        {
            var item = new TraktAnticipatedMediaRecommendation
            {
                Show = new TraktShow
                {
                    Title = "Euphoria"
                }
            };

            item.ToString().ShouldBe("Euphoria");
            item.Type.ShouldBe(TraktSearchResultType.Show);
        }

        [Fact]
        public void TestTraktAnticipatedMediaRecommendationToJson()
        {
            var movieRecommendation = new TraktAnticipatedMediaRecommendation
            {
                Movie = new TraktMovie
                {
                    Title = "Dune: Part Three",
                    Year = 2026U
                },
                Score = 0.75f,
                Released =
#if NET7_0_OR_GREATER
                    TestUtility.ParseDate("2027-03-12")
#else
                    TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z")
#endif
            };

            string json = TestUtility.SerializeObject(movieRecommendation);
            json.ShouldContain("\"title\":\"Dune: Part Three\"");
            json.ShouldContain("\"year\":2026");
            json.ShouldContain("\"score\":0.75");
            json.ShouldContain("\"released\":\"2027-03-12");

            var showRecommendation = new TraktAnticipatedMediaRecommendation
            {
                Show = new TraktShow
                {
                    Title = "Euphoria",
                    Year = 2027U
                },
                Score = 0.5f
            };

            json = TestUtility.SerializeObject(showRecommendation);
            json.ShouldContain("\"title\":\"Euphoria\"");
            json.ShouldContain("\"year\":2027");
            json.ShouldContain("\"score\":0.5");
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
