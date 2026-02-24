using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetRecentlyUpdatedShowsTests
    {
        private const string GetRecentlyUpdatedShowsUri = "shows/updates";
        private static readonly DateTime StartDate = new(2026, 2, 22, 0, 0, 0, DateTimeKind.Utc);
        private const string StartDateValue = "2026-02-22T00:00:00Z";

        [Theory]
        [InlineData(null, null, null, GetRecentlyUpdatedShowsUri, "Shows\\updatedshows_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetRecentlyUpdatedShowsUri, "Shows\\updatedshows_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetRecentlyUpdatedShowsUri}?extended=full", "Shows\\updatedshows.json")]
        [InlineData(null, 4U, null, $"{GetRecentlyUpdatedShowsUri}?page=4", "Shows\\updatedshows_minimal.json")]
        [InlineData(null, null, 20U, $"{GetRecentlyUpdatedShowsUri}?limit=20", "Shows\\updatedshows_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetRecentlyUpdatedShowsUri}?page=4&limit=20", "Shows\\updatedshows_minimal.json")]
        public async Task TestGetRecentlyUpdatedShows(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1U, limit ?? 10U, extendedInfo == TraktExtendedInfo.Full);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedShowsWithStartDate()
        {
            string requestUri = $"{GetRecentlyUpdatedShowsUri}/{StartDateValue}";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, StartDate, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null, false);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktUpdatedShow> response, uint? page, uint? limit, bool isFullExtendedInfo)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            IReadOnlyList<TraktUpdatedShow> updatedShows = response.Content!;

            updatedShows[0].ShouldNotBeNull();
            updatedShows[0].UpdatedAt.ShouldBe(DateTime.Parse("2026-02-22T00:31:21.000Z").ToUniversalTime());
            updatedShows[0].Show.ShouldNotBeNull();
            updatedShows[0].Show!.Title.ShouldBe("Medalist");
            updatedShows[0].Show!.IDs!.Trakt.ShouldBe(223571U);

            if (isFullExtendedInfo)
            {
                updatedShows[0].Show!.Overview.ShouldStartWith("Tsukasa Akeuraji, a frustrated skater");
                updatedShows[0].Show!.Network.ShouldBe("Iwate Asahi TV");
            }

            updatedShows[1].ShouldNotBeNull();
            updatedShows[1].UpdatedAt.ShouldBe(DateTime.Parse("2026-02-22T00:37:47.000Z").ToUniversalTime());
            updatedShows[1].Show.ShouldNotBeNull();
            updatedShows[1].Show!.Title.ShouldBe("Scrubs");
            updatedShows[1].Show!.Year.ShouldBe(2026U);
            updatedShows[1].Show!.IDs!.Slug.ShouldBe("scrubs-2026");

            if (isFullExtendedInfo)
            {
                updatedShows[1].Show!.Airs.ShouldNotBeNull();
                updatedShows[1].Show!.Airs!.Day.ShouldBe(TraktDayOfWeek.Wednesday);
                updatedShows[1].Show!.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetRecentlyUpdatedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedShowsUri, statusCode);

            try
            {
                await client.Shows.GetRecentlyUpdatedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
