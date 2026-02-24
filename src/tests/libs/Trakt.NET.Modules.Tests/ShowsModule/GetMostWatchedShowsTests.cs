using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostWatchedShowsTests
    {
        private const string GetMostWatchedShowsUri = "shows/watched";

        [Theory]
        [InlineData(null, null, null, null, GetMostWatchedShowsUri, "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostWatchedShowsUri, "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedShowsUri}?extended=full", "Shows\\mostpwcshows.json")]
        [InlineData(null, null, 4U, null, $"{GetMostWatchedShowsUri}?page=4", "Shows\\mostpwcshows_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostWatchedShowsUri}?limit=20", "Shows\\mostpwcshows_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedShowsUri}/monthly?extended=full&page=4&limit=20", "Shows\\mostpwcshows.json")]
        public async Task TestGetMostWatchedShows(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(period, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostWatchedShowsUri}?years=2011", "Shows\\mostpwcshows_minimal.json")]
        public async Task TestGetMostWatchedShowsWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(period, extendedInfo, TestConstants.Shows.Filter, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Fact]
        public async Task TestGetMostWatchedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.Page.ShouldBe(2U);
            ValidateResponse(response, 2U, 10U);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktMostWatchedShow> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);

            IReadOnlyList<TraktMostWatchedShow> watchedShows = response.Content!;

            // Primer elemento: Game of Thrones
            TraktMostWatchedShow show1 = watchedShows[0];
            show1.WatcherCount.ShouldBe(3910u);
            show1.Show.ShouldNotBeNull();
            show1.Show.Title.ShouldBe("Game of Thrones");
            show1.Show.Year.ShouldBe(2011U);
            show1.Show.IDs!.Trakt.ShouldBe(1390U);

            // Segundo elemento: Black Mirror
            TraktMostWatchedShow show2 = watchedShows[1];
            show2.WatcherCount.ShouldBe(1249u);
            show2.Show.ShouldNotBeNull();
            show2.Show.Title.ShouldBe("Black Mirror");
            show2.Show.Year.ShouldBe(2011U);
            show2.Show.IDs!.Trakt.ShouldBe(41793U);
        }

        [Fact]
        public async Task TestGetMostWatchedShowsPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetMostWatchedShowsPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetMostWatchedShowsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.HasPreviousPage.ShouldBe(true);

            // Mock de la llamada interna que hará GetPreviousPageAsync
            ModuleTestUtility.SetClient(client, $"{GetMostWatchedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetMostWatchedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostWatchedShowsUri, statusCode);

            try
            {
                await client.Shows.GetMostWatchedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
