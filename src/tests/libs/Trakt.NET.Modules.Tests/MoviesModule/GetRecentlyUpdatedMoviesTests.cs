using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetRecentlyUpdatedMoviesTests
    {
        private const string GetRecentlyUpdatedMoviesUri = "movies/updates";
        private static readonly DateTime StartDate = new(2024, 9, 23, 19, 8, 15, DateTimeKind.Utc);
        private const string StartDateValue = "2024-09-23T19:00:00Z";

        [Theory]
        [InlineData(null, null, null, GetRecentlyUpdatedMoviesUri, "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetRecentlyUpdatedMoviesUri, "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetRecentlyUpdatedMoviesUri}?extended=full", "Movies\\updatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetRecentlyUpdatedMoviesUri}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetRecentlyUpdatedMoviesUri}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetRecentlyUpdatedMoviesUri}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetRecentlyUpdatedMoviesUri}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetRecentlyUpdatedMoviesUri}?extended=full&page=4", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetRecentlyUpdatedMoviesUri}?extended=full&limit=20", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}?extended=full&page=4&limit=20", "Movies\\updatedmovies.json")]
        public async Task TestGetRecentlyUpdatedMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(extendedInfo, null, page, limit);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(page ?? 1U);
            response.Limit.Should().Be(limit ?? 10U);
            response.PageCount.Should().Be(1U);
            response.ItemCount.Should().Be(2U);

            IReadOnlyList<TraktUpdatedMovie> updatedMovies = response.Content!;

            TraktUpdatedMovie updatedMovie = updatedMovies[0];

            updatedMovie.Title.Should().Be("Second Life");
            updatedMovie.Year.Should().Be(2024U);
            updatedMovie.IDs!.Slug.Should().Be("second-life-2024-1110139");

            updatedMovie = updatedMovies[1];

            updatedMovie.Title.Should().Be("Milk & Serial");
            updatedMovie.Year.Should().Be(2024U);
            updatedMovie.IDs!.Slug.Should().Be("milk-serial-2024");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full", "Movies\\updatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full&page=4", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full&limit=20", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full&page=4&limit=20", "Movies\\updatedmovies.json")]
        public async Task TestGetRecentlyUpdatedMoviesWithStartDate(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(extendedInfo, StartDate, page, limit);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(page ?? 1U);
            response.Limit.Should().Be(limit ?? 10U);
            response.PageCount.Should().Be(1U);
            response.ItemCount.Should().Be(2U);

            IReadOnlyList<TraktUpdatedMovie> updatedMovies = response.Content!;

            TraktUpdatedMovie updatedMovie = updatedMovies[0];

            updatedMovie.Title.Should().Be("Second Life");
            updatedMovie.Year.Should().Be(2024U);
            updatedMovie.IDs!.Slug.Should().Be("second-life-2024-1110139");

            updatedMovie = updatedMovies[1];

            updatedMovie.Title.Should().Be("Milk & Serial");
            updatedMovie.Year.Should().Be(2024U);
            updatedMovie.IDs!.Slug.Should().Be("milk-serial-2024");
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 2);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 1);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 2);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(3U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 1);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(1U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 2);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 1);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(1U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(2U);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);
            response.Page.Should().Be(2U);
            response.Limit.Should().Be(10U);
            response.PageCount.Should().Be(2U);
            response.ItemCount.Should().Be(2U);
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
        public async Task TestGetRecentlyUpdatedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetRecentlyUpdatedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
