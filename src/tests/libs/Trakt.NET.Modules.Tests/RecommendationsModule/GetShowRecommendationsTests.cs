using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class GetShowRecommendationsTests
    {
        private const string GetShowRecommendationsUri = "recommendations/shows";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ShowRecommendationsCount = 3U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetShowRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetShowRecommendationsUri,
                                                                responseContent, 1, 1, 10, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}?page={Page}",
                                                                responseContent, Page, 1, 10, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}?limit={Limit}",
                                                                responseContent, 1, 1, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsWithIgnoreCollected()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}?ignore_collected=true",
                                                                responseContent, 1, 1, 10, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(ignoreCollected: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsWithIgnoreWatchlisted()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}?ignore_watchlisted=true",
                                                                responseContent, 1, 1, 10, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(ignoreWatchlisted: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}?extended={ExtendedInfo.ToURI()}",
                                                                responseContent, 1, 1, 10, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ShowRecommendationsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ShowRecommendationsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
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
        public async Task TestGetShowRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetShowRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecommendedShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
