using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class GetMovieRecommendationsTests
    {
        private const string GetMovieRecommendationsUri = "recommendations/movies";

        [Theory]
        [InlineData(null, null, null, null, null, GetMovieRecommendationsUri)]
        [InlineData(true, true, null, null, null, $"{GetMovieRecommendationsUri}?ignore_collected=true&ignore_watchlisted=true")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetMovieRecommendationsUri}?extended=full")]
        [InlineData(null, null, null, 2U, null, $"{GetMovieRecommendationsUri}?page=2")]
        [InlineData(null, null, null, null, 5U, $"{GetMovieRecommendationsUri}?limit=5")]
        [InlineData(true, null, null, 2U, null, $"{GetMovieRecommendationsUri}?ignore_collected=true&page=2")]
        [InlineData(true, true, TraktExtendedInfo.Full, 3U, 10U, $"{GetMovieRecommendationsUri}?ignore_collected=true&ignore_watchlisted=true&extended=full&page=3&limit=10")]
        public async Task TestGetMovieRecommendations(bool? ignoreCollected, bool? ignoreWatchlisted, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, 3);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(3);
            response.ItemCount.ShouldBe(3U);
            response.Page.ShouldBe(expectedPage);
            response.Limit.ShouldBe(expectedLimit);
            response.PageCount.ShouldBe(1U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestGetMovieRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMovieRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecommendedMovie>>> act = () => client.Recommendations.GetMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
