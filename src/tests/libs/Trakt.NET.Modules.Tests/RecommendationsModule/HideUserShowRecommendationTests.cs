using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class HideUserShowRecommendationTests
    {
        private readonly string HideShowRecommendationUri = $"recommendations/shows/{TestConstants.Shows.TraktShowID}";

        [Fact]
        public async Task TestHideShowRecommendationWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/shows/{TestConstants.Shows.ShowSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/shows/{TestConstants.Shows.ShowSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/shows/{TestConstants.Shows.ShowSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(show, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestHideShowRecommendationWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestHideShowRecommendationWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideShowRecommendationAsync(default(TraktShow)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideShowRecommendationAsync(new TraktShowIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Recommendations.HideShowRecommendationAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
