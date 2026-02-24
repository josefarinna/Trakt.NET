using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostAnticipatedShowsTests
    {
        private const string GetMostAnticipatedShowsUri = "shows/anticipated";

        [Theory]
        [InlineData(null, null, null, GetMostAnticipatedShowsUri, "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetMostAnticipatedShowsUri, "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMostAnticipatedShowsUri}?extended=full", "Shows\\mostanticipatedshows.json")]
        [InlineData(null, 4U, null, $"{GetMostAnticipatedShowsUri}?page=4", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(null, null, 20U, $"{GetMostAnticipatedShowsUri}?limit=20", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetMostAnticipatedShowsUri}?page=4&limit=20", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMostAnticipatedShowsUri}?extended=full&page=4&limit=20", "Shows\\mostanticipatedshows.json")]
        public async Task TestGetMostAnticipatedShows(
            TraktExtendedInfo? extendedInfo,
            uint? page,
            uint? limit,
            string requestUri,
            string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostAnticipatedShow> response =
                await client.Shows.GetMostAnticipatedShowsAsync(
                    extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktMostAnticipatedShow> anticipatedShows = response.Content!;

            TraktMostAnticipatedShow show = anticipatedShows[0];

            show.Title.ShouldBe("Game of Thrones");
            show.Year.ShouldBe(2011U);
            show.IDs!.Slug.ShouldBe("game-of-thrones");

            show = anticipatedShows[1];

            show.Title.ShouldBe("Stranger Things");
            show.Year.ShouldBe(2016U);
            show.IDs!.Slug.ShouldBe("stranger-things");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetMostAnticipatedShowsUri}?genres=fantasy,drama&years=2011", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMostAnticipatedShowsUri}?genres=fantasy,drama&years=2011&extended=full&page=4&limit=20", "Shows\\mostanticipatedshows.json")]
        public async Task TestGetMostAnticipatedShowsWithFilter(
            TraktExtendedInfo? extendedInfo,
            uint? page,
            uint? limit,
            string requestUri,
            string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostAnticipatedShow> response =
                await client.Shows.GetMostAnticipatedShowsAsync(
                    extendedInfo,
                    TestConstants.Shows.Filter,
                    page,
                    limit,
                    TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMostAnticipatedShow> anticipatedShows = response.Content!;

            anticipatedShows[0].Title.ShouldBe("Game of Thrones");
            anticipatedShows[1].Title.ShouldBe("Stranger Things");
        }

        [Fact]
        public async Task TestGetMostAnticipatedShowsPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedShow> response =
                await client.Shows.GetMostAnticipatedShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetMostAnticipatedShowsPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedShow> response =
                await client.Shows.GetMostAnticipatedShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Theory]
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
        public async Task TestGetMostAnticipatedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostAnticipatedShowsUri, statusCode);

            try
            {
                await client.Shows.GetMostAnticipatedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
