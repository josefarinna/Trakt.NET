using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostCollectedShowsTests
    {
        private const string GetMostCollectedShowsUri = "shows/collected";

        [Theory]
        [InlineData(null, null, null, null, GetMostCollectedShowsUri, "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostCollectedShowsUri, "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostCollectedShowsUri}?extended=full", "Shows\\mostpwcshows.json")]
        [InlineData(null, null, 4U, null, $"{GetMostCollectedShowsUri}?page=4", "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostCollectedShowsUri}?limit=20", "Shows\\mostpwcshows_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostCollectedShowsUri}/monthly?extended=full&page=4&limit=20", "Shows\\mostpwcshows.json")]
        public async Task TestGetMostCollectedShows(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(period, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostCollectedShowsUri}?genres=fantasy,drama&years=2011", "Shows\\mostpwcshows_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostCollectedShowsUri}/monthly?genres=fantasy,drama&years=2011&extended=full&page=4&limit=20", "Shows\\mostpwcshows.json")]
        public async Task TestGetMostCollectedShowsWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(period, extendedInfo, TestConstants.Shows.Filter, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Fact]
        public async Task TestGetMostCollectedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            ModuleTestUtility.SetClient(client, $"{GetMostCollectedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.Page.ShouldBe(2U);
            ValidateResponse(response, 2U, 10U);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktMostCollectedShow> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);

            IReadOnlyList<TraktMostCollectedShow> collectedShows = response.Content!;

            TraktMostCollectedShow show1 = collectedShows[0];
            show1.WatcherCount.ShouldBe(3910U);
            show1.PlayCount.ShouldBe(69164U);
            show1.CollectedCount.ShouldBe(1000U);
            show1.Show.ShouldNotBeNull();
            show1.Show.Title.ShouldBe("Game of Thrones");
            show1.Show.Year.ShouldBe(2011U);
            show1.Show.IDs!.Trakt.ShouldBe(1390U);
            show1.Show.IDs.Slug.ShouldBe("game-of-thrones");

            TraktMostCollectedShow show2 = collectedShows[1];
            show2.WatcherCount.ShouldBe(1249U);
            show2.PlayCount.ShouldBe(9785U);
            show2.CollectedCount.ShouldBe(103U);
            show2.Show.ShouldNotBeNull();
            show2.Show.Title.ShouldBe("Black Mirror");
            show2.Show.Year.ShouldBe(2011U);
            show2.Show.IDs!.Trakt.ShouldBe(41793U);
            show2.Show.IDs.Slug.ShouldBe("black-mirror");
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        public async Task TestGetMostCollectedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostCollectedShowsUri, statusCode);

            try
            {
                await client.Shows.GetMostCollectedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
