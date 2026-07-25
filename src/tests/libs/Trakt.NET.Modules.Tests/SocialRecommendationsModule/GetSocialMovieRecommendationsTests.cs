using System.Net;

namespace TraktNET.SocialRecommendationsModule
{
    public sealed class GetSocialMovieRecommendationsTests
    {
        private const string GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI = "social_recommendations/movies";
        private const uint ItemCount = 1;

        [Fact]
        public async Task TestGetSocialMovieRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI,
                responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);

            TraktSocialMovieRecommendation item = response.Content[0];
            item.ShouldNotBeNull();
            item.Title.ShouldBe("Star Wars: The Force Awakens");
            item.Year.ShouldBe(2015U);
            item.IDs.ShouldNotBeNull();
            item.IDs.Trakt.ShouldBe((uint?)94024U);
            item.FavoritedBy.ShouldNotBeNull();
            item.FavoritedBy.Count.ShouldBe(1);
            item.FavoritedBy[0].Username.ShouldBe("sean");
            item.RecommendedBy.ShouldNotBeNull();
            item.RecommendedBy.Count.ShouldBe(1);
            item.RecommendedBy[0].Username.ShouldBe("sean");
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
        public async Task TestGetSocialMovieRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI, statusCode);

            Func<Task<TraktPagedResponse<TraktSocialMovieRecommendation>>> act = () => client.SocialRecommendations.GetMovieRecommendationsAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
