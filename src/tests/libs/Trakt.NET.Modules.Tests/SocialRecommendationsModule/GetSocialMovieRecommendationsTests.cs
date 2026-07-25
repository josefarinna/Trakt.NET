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

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithWatchWindow()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?watch_window=7", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(watchWindow: 7U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithIgnoreWatched()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?ignore_watched=true", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(ignoreWatched: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithIgnoreCollected()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?ignore_collected=true", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(ignoreCollected: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithIgnoreWatchlisted()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?ignore_watchlisted=true", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(ignoreWatchlisted: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?extended=full", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(extendedInfo: TraktExtendedInfo.Full, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=2", responseContent, 2, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?limit=10", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=2&limit=10", responseContent, 2, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?watch_window=7&ignore_watched=true&ignore_collected=true&ignore_watchlisted=true&extended=full&page=2&limit=10",
                responseContent, 2, 1, 10, ItemCount);

            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(
                watchWindow: 7U, ignoreWatched: true, ignoreCollected: true, ignoreWatchlisted: true,
                extendedInfo: TraktExtendedInfo.Full, page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=2&limit=10", responseContent, 2, 5, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=2&limit=10", responseContent, 2, 2, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=1&limit=10", responseContent, 1, 2, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=1&limit=10", responseContent, 1, 1, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=2&limit=10", responseContent, 2, 2, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetOAuthClient(client, $"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=1&limit=10", responseContent, 1, 2, 10, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSocialMovieRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\socialrecommendationsmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=1&limit=10", responseContent, 1, 2, 10, ItemCount);
            TraktPagedResponse<TraktSocialMovieRecommendation> response = await client.SocialRecommendations.GetMovieRecommendationsAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetOAuthClient(client, $"{GET_SOCIAL_MOVIE_RECOMMENDATIONS_URI}?page=2&limit=10", responseContent, 2, 2, 10, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
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
