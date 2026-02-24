using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetTrendingShowsTests
    {
        private const string GetTrendingShowsUri = "shows/trending";

        [Theory]
        [InlineData(null, null, null, GetTrendingShowsUri, "Shows\\trendingshows_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetTrendingShowsUri, "Shows\\trendingshows_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetTrendingShowsUri}?extended=full", "Shows\\trendingshows_minimal.json")] // Usando minimal para la estructura de lista
        [InlineData(null, 4U, null, $"{GetTrendingShowsUri}?page=4", "Shows\\trendingshows_minimal.json")]
        [InlineData(null, null, 20U, $"{GetTrendingShowsUri}?limit=20", "Shows\\trendingshows_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetTrendingShowsUri}?page=4&limit=20", "Shows\\trendingshows_minimal.json")]
        public async Task TestGetTrendingShows(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktTrendingShow> response = await client.Shows.GetTrendingShowsAsync(extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktTrendingShow> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);

            IReadOnlyList<TraktTrendingShow> trendingShows = response.Content!;

            trendingShows[0].ShouldNotBeNull();
            trendingShows[0].Watchers.ShouldBe(8021U);
            trendingShows[0].Show.ShouldNotBeNull();
            trendingShows[0].Show!.Title.ShouldBe("The Pitt");
            trendingShows[0].Show!.Year.ShouldBe(2025U);
            trendingShows[0].Show!.IDs!.Trakt.ShouldBe(232884U);
            trendingShows[0].Show!.IDs!.Slug.ShouldBe("the-pitt");

            trendingShows[1].ShouldNotBeNull();
            trendingShows[1].Watchers.ShouldBe(5663U);
            trendingShows[1].Show.ShouldNotBeNull();
            trendingShows[1].Show!.Title.ShouldBe("The Night Agent");
            trendingShows[1].Show!.Year.ShouldBe(2023U);
            trendingShows[1].Show!.IDs!.Trakt.ShouldBe(184471U);
        }

        [Theory]
#if TRAKT_NET_4_0_ENABLE_CONVENIENCE_EXCEPTIONS
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        public async Task TestGetTrendingShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetTrendingShowsUri, statusCode);

            try
            {
                await client.Shows.GetTrendingShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
