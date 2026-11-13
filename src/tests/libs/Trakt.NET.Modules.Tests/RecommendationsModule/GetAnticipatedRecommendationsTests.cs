namespace TraktNET.RecommendationsModule
{
    public sealed class GetAnticipatedRecommendationsTests
    {
        private const string MoviesUri = "movies/recommendations/anticipated";
        private const string ShowsUri = "shows/recommendations/anticipated";
        private const string MediaUri = "media/recommendations/anticipated";
        private const uint ItemsCount = 2U;

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(MoviesUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ShowsUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(MediaUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
        }
    }
}

