using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class GetMovieRecommendationsTests
    {
        private const string GetMovieRecommendationsUri = "recommendations/movies";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint MovieRecommendationsCount = 3U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetMovieRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMovieRecommendationsUri,
                                                                responseContent, 1, 1, 10, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}?page={Page}",
                                                                responseContent, Page, 1, 10, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}?limit={Limit}",
                                                                responseContent, 1, 1, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsWithIgnoreCollected()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}?ignore_collected=true",
                                                                responseContent, 1, 1, 10, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(ignoreCollected: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsWithIgnoreWatchlisted()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}?ignore_watchlisted=true",
                                                                responseContent, 1, 1, 10, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(ignoreWatchlisted: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}?extended={ExtendedInfo.ToURI()}",
                                                                responseContent, 1, 1, 10, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MovieRecommendationsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MovieRecommendationsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
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
        public async Task TestGetMovieRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMovieRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecommendedMovie>>> act = () => client.Recommendations.GetMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
