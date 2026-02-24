using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetRecentlyUpdatedShowTraktIDsTests
    {
        private const string GetRecentlyUpdatedShowTraktIDsUri = "shows/updates/id";
        private static readonly DateTime StartDate = new(2026, 2, 22, 17, 0, 0, DateTimeKind.Utc);
        private const string StartDateValue = "2026-02-22T17:00:00Z";

        [Theory]
        [InlineData(null, null, GetRecentlyUpdatedShowTraktIDsUri, "Shows\\updatedshowids.json")]
        [InlineData(4U, null, $"{GetRecentlyUpdatedShowTraktIDsUri}?page=4", "Shows\\updatedshowids.json")]
        [InlineData(null, 20U, $"{GetRecentlyUpdatedShowTraktIDsUri}?limit=20", "Shows\\updatedshowids.json")]
        [InlineData(4U, 20U, $"{GetRecentlyUpdatedShowTraktIDsUri}?page=4&limit=20", "Shows\\updatedshowids.json")]
        public async Task TestGetRecentlyUpdatedShowTraktIDs(uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 10);

            TraktPagedResponse<uint> response = await client.Shows.GetRecentlyUpdatedShowTraktIDsAsync(null, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1U, limit ?? 10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedShowTraktIDsWithStartDate()
        {
            string requestUri = $"{GetRecentlyUpdatedShowTraktIDsUri}/{StartDateValue}";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshowids.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<uint> response = await client.Shows.GetRecentlyUpdatedShowTraktIDsAsync(StartDate, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        private static void ValidateResponse(TraktPagedResponse<uint> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            IReadOnlyList<uint> showTraktIDs = response.Content!;

            showTraktIDs[0].ShouldBe(223571U);
            showTraktIDs[1].ShouldBe(158359U);
            showTraktIDs[2].ShouldBe(316390U);
            showTraktIDs[3].ShouldBe(283328U);
            showTraktIDs[4].ShouldBe(291441U);
            showTraktIDs[5].ShouldBe(228089U);
            showTraktIDs[6].ShouldBe(316848U);
            showTraktIDs[7].ShouldBe(62402U);
            showTraktIDs[8].ShouldBe(40020U);
            showTraktIDs[9].ShouldBe(5848U);
        }

        [Theory]
#if TRAKT_NET_4_0_ENABLE_CONVENIENCE_EXCEPTIONS
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        public async Task TestGetRecentlyUpdatedShowTraktIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedShowTraktIDsUri, statusCode);

            try
            {
                await client.Shows.GetRecentlyUpdatedShowTraktIDsAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }
    }
}
