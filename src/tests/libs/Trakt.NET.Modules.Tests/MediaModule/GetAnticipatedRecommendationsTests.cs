using System.Net;

namespace TraktNET.MediaModule
{
    public sealed class GetAnticipatedRecommendationsTests
    {
        private const string GetAnticipatedRecommendationsUri = "media/recommendations/anticipated";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemsCount = 2U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetAnticipatedRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAnticipatedRecommendationsUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);

            TraktAnticipatedMediaRecommendation movieItem = response.Content[0];
            movieItem.Movie.ShouldNotBeNull();
            movieItem.Movie.Title.ShouldBe("Dune: Part Three");
            movieItem.Show.ShouldBeNull();
            movieItem.Score.ShouldBe(0.9f);
#if NET7_0_OR_GREATER
            movieItem.Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            movieItem.Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif
            movieItem.Type.ShouldBe(TraktSearchResultType.Movie);

            TraktAnticipatedMediaRecommendation showItem = response.Content[1];
            showItem.Movie.ShouldBeNull();
            showItem.Show.ShouldNotBeNull();
            showItem.Show.Title.ShouldBe("Euphoria");
            showItem.Score.ShouldBe(0.5f);
            showItem.Released.ShouldBeNull();
            showItem.Type.ShouldBe(TraktSearchResultType.Show);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAnticipatedRecommendationsUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedMediaRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?page={Page}",
                                                                responseContent, Page, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?limit={Limit}",
                                                                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?page={Page}&limit={Limit}",
                                                                responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?extended={ExtendedInfo.ToURI()}",
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetAnticipatedRecommendationsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Media.GetAnticipatedRecommendationsAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetAnticipatedRecommendationsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetAnticipatedRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAnticipatedRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktAnticipatedMediaRecommendation>>> act = () => client.Media.GetAnticipatedRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
