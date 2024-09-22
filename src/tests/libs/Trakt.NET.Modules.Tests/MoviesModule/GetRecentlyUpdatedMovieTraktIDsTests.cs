using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetRecentlyUpdatedMovieTraktIDsTests
    {
        private const string GetRecentlyUpdatedMovieTraktIDsUri = "movies/updates/id";
        private static readonly DateTime StartDate = new(2024, 9, 24, 21, 24, 15, DateTimeKind.Utc);
        private const string StartDateValue = "2024-09-24T21:00:00Z";

        [Theory]
        [InlineData(null, null, GetRecentlyUpdatedMovieTraktIDsUri, "Movies\\updatedmovieids.json")]
        [InlineData(4U, null, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=4", "Movies\\updatedmovieids.json")]
        [InlineData(null, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}?limit=20", "Movies\\updatedmovieids.json")]
        [InlineData(4U, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=4&limit=20", "Movies\\updatedmovieids.json")]
        public async Task TestGetRecentlyUpdatedMovieTraktIDs(uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(null, page, limit);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(page ?? 1U);
            response.Limit.Should().Be(limit ?? 10U);
            response.PageCount.Should().Be(1U);
            response.ItemCount.Should().Be(10U);

            IReadOnlyList<uint> updatedMovies = response.Content!;

            updatedMovies.Should().HaveCount(10);

            updatedMovies[0].Should().Be(366829U);
            updatedMovies[1].Should().Be(1110521U);
            updatedMovies[2].Should().Be(1110522U);
            updatedMovies[3].Should().Be(1110523U);
            updatedMovies[4].Should().Be(361391U);
            updatedMovies[5].Should().Be(823915U);
            updatedMovies[6].Should().Be(766592U);
            updatedMovies[7].Should().Be(556530U);
            updatedMovies[8].Should().Be(855458U);
            updatedMovies[9].Should().Be(1108919U);
        }

        [Theory]
        [InlineData(null, null, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}", "Movies\\updatedmovieids.json")]
        [InlineData(4U, null, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}?page=4", "Movies\\updatedmovieids.json")]
        [InlineData(null, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}?limit=20", "Movies\\updatedmovieids.json")]
        [InlineData(4U, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}?page=4&limit=20", "Movies\\updatedmovieids.json")]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsWithStartDate(uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(StartDate, page, limit);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(page ?? 1U);
            response.Limit.Should().Be(limit ?? 10U);
            response.PageCount.Should().Be(1U);
            response.ItemCount.Should().Be(10U);

            IReadOnlyList<uint> updatedMovies = response.Content!;

            updatedMovies.Should().HaveCount(10);

            updatedMovies[0].Should().Be(366829U);
            updatedMovies[1].Should().Be(1110521U);
            updatedMovies[2].Should().Be(1110522U);
            updatedMovies[3].Should().Be(1110523U);
            updatedMovies[4].Should().Be(361391U);
            updatedMovies[5].Should().Be(823915U);
            updatedMovies[6].Should().Be(766592U);
            updatedMovies[7].Should().Be(556530U);
            updatedMovies[8].Should().Be(855458U);
            updatedMovies[9].Should().Be(1108919U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 2);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 1);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 3, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 2);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(3U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 1, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 1);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(1U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 2);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 2, 10, 10);

            response = await response.GetPreviousPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 1);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 2, 10, 10);

            response = await response.GetNextPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(10);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(10U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
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
        public async Task TestGetRecentlyUpdatedMovieTraktIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedMovieTraktIDsUri, statusCode);

            try
            {
                await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
