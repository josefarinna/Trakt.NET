using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostFavoritedShowsTests
    {
        private const string GetMostFavoritedShowsUri = "shows/favorited";

        [Theory]
        [InlineData(null, null, null, null, GetMostFavoritedShowsUri, "Shows\\mostfavoritedshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostFavoritedShowsUri, "Shows\\mostfavoritedshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedShowsUri}?extended=full", "Shows\\mostfavoritedshows.json")]
        [InlineData(null, null, 4U, null, $"{GetMostFavoritedShowsUri}?page=4", "Shows\\mostfavoritedshows_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostFavoritedShowsUri}?limit=20", "Shows\\mostfavoritedshows_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedShowsUri}/monthly?extended=full&page=4&limit=20", "Shows\\mostfavoritedshows.json")]
        public async Task TestGetMostFavoritedShows(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostFavoritedShow> response = await client.Shows.GetMostFavoritedShowsAsync(period, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostFavoritedShowsUri}?genres=fantasy,drama&years=2011", "Shows\\mostfavoritedshows_minimal.json")]
        public async Task TestGetMostFavoritedShowsWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostFavoritedShow> response = await client.Shows.GetMostFavoritedShowsAsync(period, extendedInfo, TestConstants.Shows.Filter, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page, limit);
        }

        [Fact]
        public async Task TestGetMostFavoritedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostfavoritedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedShow> response = await client.Shows.GetMostFavoritedShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            ModuleTestUtility.SetClient(client, $"{GetMostFavoritedShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.Page.ShouldBe(2U);
            ValidateResponse(response, 2U, 10U);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktMostFavoritedShow> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);

            IReadOnlyList<TraktMostFavoritedShow> favoritedShows = response.Content!;

            TraktMostFavoritedShow show1 = favoritedShows[0];
            show1.UserCount.ShouldBe(128U);
            show1.Show.ShouldNotBeNull();
            show1.Show.Title.ShouldBe("Game of Thrones");
            show1.Show.Year.ShouldBe(2011U);
            show1.Show.IDs!.Trakt.ShouldBe(1390U);
            show1.Show.IDs.Slug.ShouldBe("game-of-thrones");

            TraktMostFavoritedShow show2 = favoritedShows[1];
            show2.UserCount.ShouldBe(37U);
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
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetMostFavoritedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostFavoritedShowsUri, statusCode);

            try
            {
                await client.Shows.GetMostFavoritedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
