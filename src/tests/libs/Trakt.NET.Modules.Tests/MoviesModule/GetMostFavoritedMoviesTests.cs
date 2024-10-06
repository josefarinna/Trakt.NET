using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostFavoritedMoviesTests
    {
        private const string GetMostFavoritedMoviesUri = "movies/favorited";

        [Theory]
        [InlineData(null, null, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}?extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostFavoritedMoviesUri}?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostFavoritedMoviesUri}?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMostFavoritedMoviesUri}?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMostFavoritedMoviesUri}?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMostFavoritedMoviesUri}?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMostFavoritedMoviesUri}?extended=full&page=4", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMostFavoritedMoviesUri}?extended=full&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostFavoritedMoviesUri}/monthly", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, null, $"{GetMostFavoritedMoviesUri}/monthly", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}?extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}/monthly?extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, null, $"{GetMostFavoritedMoviesUri}?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, null, $"{GetMostFavoritedMoviesUri}/monthly?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20U, $"{GetMostFavoritedMoviesUri}?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, 20U, $"{GetMostFavoritedMoviesUri}/monthly?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, 20U, $"{GetMostFavoritedMoviesUri}?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMostFavoritedMoviesUri}?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, null, $"{GetMostFavoritedMoviesUri}/monthly?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMostFavoritedMoviesUri}?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, 20U, $"{GetMostFavoritedMoviesUri}/monthly?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMostFavoritedMoviesUri}?extended=full&page=4", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, null, $"{GetMostFavoritedMoviesUri}/monthly?extended=full&page=4", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMostFavoritedMoviesUri}?extended=full&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, 20U, $"{GetMostFavoritedMoviesUri}/monthly?extended=full&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        public async Task TestGetMostFavoritedMovies(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(period, extendedInfo, null, page, limit);

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

            IReadOnlyList<TraktMostFavoritedMovie> favoritedMovies = response.Content!;

            TraktMostFavoritedMovie favoritedMovie = favoritedMovies[0];

            favoritedMovie.Title.Should().Be("Deadpool & Wolverine");
            favoritedMovie.Year.Should().Be(2024U);
            favoritedMovie.IDs!.Slug.Should().Be("deadpool-wolverine-2024");

            favoritedMovie = favoritedMovies[1];

            favoritedMovie.Title.Should().Be("A Quiet Place: Day One");
            favoritedMovie.Year.Should().Be(2024U);
            favoritedMovie.IDs!.Slug.Should().Be("a-quiet-place-day-one-2024");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        public async Task TestGetMostFavoritedMoviesWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(period, extendedInfo, TestConstants.Movies.Filter, page, limit);

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

            IReadOnlyList<TraktMostFavoritedMovie> favoritedMovies = response.Content!;

            TraktMostFavoritedMovie favoritedMovie = favoritedMovies[0];

            favoritedMovie.Title.Should().Be("Deadpool & Wolverine");
            favoritedMovie.Year.Should().Be(2024U);
            favoritedMovie.IDs!.Slug.Should().Be("deadpool-wolverine-2024");

            favoritedMovie = favoritedMovies[1];

            favoritedMovie.Title.Should().Be("A Quiet Place: Day One");
            favoritedMovie.Year.Should().Be(2024U);
            favoritedMovie.IDs!.Slug.Should().Be("a-quiet-place-day-one-2024");
        }

        [Fact]
        public async Task TestGetMostFavoritedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 2);

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
        public async Task TestGetMostFavoritedMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 1);

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
        public async Task TestGetMostFavoritedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 2);

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
        public async Task TestGetMostFavoritedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 1);

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
        public async Task TestGetMostFavoritedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostFavoritedMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostFavoritedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostFavoritedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetMostFavoritedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
