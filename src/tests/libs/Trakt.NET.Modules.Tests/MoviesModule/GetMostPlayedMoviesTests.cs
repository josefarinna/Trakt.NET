using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostPlayedMoviesTests
    {
        private const string GetMostPlayedMoviesUri = "movies/played";

        [Theory]
        [InlineData(null, null, null, null, GetMostPlayedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostPlayedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedMoviesUri}?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostPlayedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostPlayedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMostPlayedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMostPlayedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMostPlayedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMostPlayedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMostPlayedMoviesUri}?extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMostPlayedMoviesUri}?extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, GetMostPlayedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostPlayedMoviesUri}/monthly", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, GetMostPlayedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, null, $"{GetMostPlayedMoviesUri}/monthly", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedMoviesUri}?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedMoviesUri}/monthly?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, null, $"{GetMostPlayedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, null, $"{GetMostPlayedMoviesUri}/monthly?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20U, $"{GetMostPlayedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, 20U, $"{GetMostPlayedMoviesUri}/monthly?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, 20U, $"{GetMostPlayedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, 20U, $"{GetMostPlayedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMostPlayedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, null, $"{GetMostPlayedMoviesUri}/monthly?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMostPlayedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, 20U, $"{GetMostPlayedMoviesUri}/monthly?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostPlayedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostPlayedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMostPlayedMoviesUri}?extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, null, $"{GetMostPlayedMoviesUri}/monthly?extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMostPlayedMoviesUri}?extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, 20U, $"{GetMostPlayedMoviesUri}/monthly?extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedMoviesUri}/monthly?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        public async Task TestGetMostPlayedMovies(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, null, page, limit);

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

            IReadOnlyList<TraktMostPlayedMovie> playedMovies = response.Content!;

            TraktMostPlayedMovie playedMovie = playedMovies[0];

            playedMovie.Title.Should().Be("The Hunt for Red October");
            playedMovie.Year.Should().Be(1990U);
            playedMovie.IDs!.Slug.Should().Be("the-hunt-for-red-october-1990");

            playedMovie = playedMovies[1];

            playedMovie.Title.Should().Be("Rebel Ridge");
            playedMovie.Year.Should().Be(2024U);
            playedMovie.IDs!.Slug.Should().Be("rebel-ridge-2024");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, null, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, null, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, null, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, 20U, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, 20U, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, null, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, 20U, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, null, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, 20U, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostPlayedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        public async Task TestGetMostPlayedMoviesWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, TestConstants.Movies.Filter, page, limit);

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

            IReadOnlyList<TraktMostPlayedMovie> playedMovies = response.Content!;

            TraktMostPlayedMovie playedMovie = playedMovies[0];

            playedMovie.Title.Should().Be("The Hunt for Red October");
            playedMovie.Year.Should().Be(1990U);
            playedMovie.IDs!.Slug.Should().Be("the-hunt-for-red-october-1990");

            playedMovie = playedMovies[1];

            playedMovie.Title.Should().Be("Rebel Ridge");
            playedMovie.Year.Should().Be(2024U);
            playedMovie.IDs!.Slug.Should().Be("rebel-ridge-2024");
        }

        [Fact]
        public async Task TestGetMostPlayedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(page: 2);

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
        public async Task TestGetMostPlayedMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(page: 1);

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
        public async Task TestGetMostPlayedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(page: 2);

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
        public async Task TestGetMostPlayedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(page: 1);

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
        public async Task TestGetMostPlayedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMostPlayedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostPlayedMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostPlayedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostPlayedMovie> response = await client.Movies.GetMostPlayedMoviesAsync(page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMostPlayedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostPlayedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostPlayedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetMostPlayedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
