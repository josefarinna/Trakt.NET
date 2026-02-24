using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostPlayedShowsTests
    {
        private const string GetMostPlayedShowsUri = "shows/played";

        [Theory]
        [InlineData(null, null, null, null, GetMostPlayedShowsUri, "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostPlayedShowsUri, "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedShowsUri}?extended=full", "Shows\\mostpwcshows.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedShowsUri}/monthly?extended=full&page=4&limit=20", "Shows\\mostpwcshows.json")]
        public async Task TestGetMostPlayedShows(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostPlayedShow> response = await client.Shows.GetMostPlayedShowsAsync(period, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostPlayedShowsUri}?years=2011", "Shows\\mostpwcshows_minimal.json")]
        public async Task TestGetMostPlayedShowsWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostPlayedShow> response = await client.Shows.GetMostPlayedShowsAsync(period, extendedInfo, TestConstants.Shows.Filter, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Fact]
        public async Task TestGetMostPlayedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostPlayedShow> response = await client.Shows.GetMostPlayedShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            ModuleTestUtility.SetClient(client, $"{GetMostPlayedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.Page.ShouldBe(2U);
            ValidateResponse(response, 2U, 10U);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktMostPlayedShow> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);

            IReadOnlyList<TraktMostPlayedShow> playedShows = response.Content!;

            TraktMostPlayedShow show1 = playedShows[0];
            show1.WatcherCount.ShouldBe(3910u);
            show1.Show.ShouldNotBeNull();
            show1.Show.Title.ShouldBe("Game of Thrones");
            show1.Show.IDs!.Trakt.ShouldBe(1390U);

            TraktMostPlayedShow show2 = playedShows[1];
            show2.WatcherCount.ShouldBe(1249u);
            show2.Show.ShouldNotBeNull();
            show2.Show.Title.ShouldBe("Black Mirror");
            show2.Show.IDs!.Trakt.ShouldBe(41793U);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetMostPlayedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostPlayedShowsUri, statusCode);

            try
            {
                await client.Shows.GetMostPlayedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
