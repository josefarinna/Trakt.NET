namespace TraktNET.Json.Recommendations
{
    public sealed class TraktAnticipatedShowRecommendationTests
    {
        [Fact]
        public void TestTraktAnticipatedShowRecommendationConstructor()
        {
            var item = new TraktAnticipatedShowRecommendation();

            item.Show.ShouldBeNull();
            item.Score.ShouldBeNull();
            item.Released.ShouldBeNull();
            item.ToString().ShouldBe(string.Empty);
        }

        [Fact]
        public async Task TestTraktAnticipatedShowRecommendationFromJson()
        {
            TraktAnticipatedShowRecommendation? item = await TestUtility.DeserializeJsonAsync<TraktAnticipatedShowRecommendation>("Recommendations\\anticipatedshowrecommendation.json");

            item.ShouldNotBeNull();
            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Euphoria");
            item.Show.Year.ShouldBe(2027U);
            item.Show.IDs.ShouldNotBeNull();
            item.Show.IDs.Trakt.ShouldBe(2U);
            item.Show.IDs.Slug.ShouldBe("euphoria-2019");
            item.Score.ShouldBe(0.4f);
            item.Released.ShouldBeNull();
            item.ToString().ShouldBe(item.Show.ToString());
        }

        [Fact]
        public async Task TestTraktAnticipatedShowRecommendationListFromJson()
        {
            IReadOnlyList<TraktAnticipatedShowRecommendation>? items = await TestUtility.DeserializeJsonListAsync<TraktAnticipatedShowRecommendation>("Recommendations\\anticipatedshowrecommendations.json");

            items.ShouldNotBeNull();
            items.Count.ShouldBe(2);

            items[0].Show.ShouldNotBeNull();
            items[0].Show!.Title.ShouldBe("Euphoria");
            items[0].Score.ShouldBe(0.4f);
            items[0].Released.ShouldBeNull();

            items[1].Show.ShouldNotBeNull();
            items[1].Show!.Title.ShouldBe("Stranger Things");
            items[1].Score.ShouldBe(0.91f);
#if NET7_0_OR_GREATER
            items[1].Released.ShouldBe(TestUtility.ParseDate("2025-11-06"));
#else
            items[1].Released.ShouldBe(TestUtility.ParseUTCDateTime("2025-11-06T00:00:00.000Z"));
#endif
        }
    }
}

