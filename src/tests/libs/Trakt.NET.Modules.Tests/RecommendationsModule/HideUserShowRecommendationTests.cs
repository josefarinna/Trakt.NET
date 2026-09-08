using System.Globalization;
using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class HideUserShowRecommendationTests
    {
        private readonly string HideShowRecommendationUri = $"recommendations/shows/{TestConstants.Shows.TraktShowID}";

        [Fact]
        public async Task TestHideShowRecommendation()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.TraktShowID.ToString(CultureInfo.InvariantCulture), TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationRatingsWithTraktID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationRatingsWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(showIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationRatingsWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/shows/{TestConstants.Shows.ShowSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(showIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationRatingsWithShowIds()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/shows/{TestConstants.Shows.ShowSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideShowRecommendationRatingsWithShow()
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetShowRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideShowRecommendationUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowRatingsThrowsArgumentExceptions()
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
