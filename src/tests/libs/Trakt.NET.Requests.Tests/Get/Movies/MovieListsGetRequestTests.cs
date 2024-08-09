namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieListsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/lists";

        [Theory]
        [InlineData(null, null, null, null, null, URIPath)]
        [InlineData(TraktListType.Unspecified, null, null, null, null, URIPath)]
        [InlineData(TraktListType.Watchlist, null, null, null, null, $"{URIPath}/watchlists")]
        [InlineData(null, TraktListSortOrder.Unspecified, null, null, null, URIPath)]
        [InlineData(null, TraktListSortOrder.Added, null, null, null, $"{URIPath}/added")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktListType.Watchlist, TraktListSortOrder.Unspecified, null, null, null, $"{URIPath}/watchlists")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Added, null, null, null, $"{URIPath}/added")]
        [InlineData(TraktListType.Watchlist, TraktListSortOrder.Added, null, null, null, $"{URIPath}/watchlists/added")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktListType.Watchlist, null, TraktExtendedInfo.None, null, null, $"{URIPath}/watchlists")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktListType.Watchlist, null, TraktExtendedInfo.Full, null, null, $"{URIPath}/watchlists?extended=full")]
        [InlineData(TraktListType.Unspecified, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListType.Watchlist, null, null, 10, null, $"{URIPath}/watchlists?page=10")]
        [InlineData(TraktListType.Unspecified, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListType.Watchlist, null, null, null, 20, $"{URIPath}/watchlists?limit=20")]
        [InlineData(TraktListType.Unspecified, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListType.Watchlist, null, null, 10, 20, $"{URIPath}/watchlists?page=10&limit=20")]
        [InlineData(null, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktListSortOrder.Added, TraktExtendedInfo.None, null, null, $"{URIPath}/added")]
        [InlineData(null, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktListSortOrder.Added, TraktExtendedInfo.Full, null, null, $"{URIPath}/added?extended=full")]
        [InlineData(null, TraktListSortOrder.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktListSortOrder.Added, null, 10, null, $"{URIPath}/added?page=10")]
        [InlineData(null, TraktListSortOrder.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktListSortOrder.Added, null, null, 20, $"{URIPath}/added?limit=20")]
        [InlineData(null, TraktListSortOrder.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktListSortOrder.Added, null, 10, 20, $"{URIPath}/added?page=10&limit=20")]
        [InlineData(null, null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListType.Watchlist, TraktListSortOrder.Added, TraktExtendedInfo.Full, 10, null, $"{URIPath}/watchlists/added?extended=full&page=10")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListType.Watchlist, TraktListSortOrder.Added, TraktExtendedInfo.Full, null, 20, $"{URIPath}/watchlists/added?extended=full&limit=20")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListType.Watchlist, TraktListSortOrder.Added, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/watchlists/added?extended=full&page=10&limit=20")]
        public void TestMovieListsGetRequestHasValidURIPath(TraktListType? listType, TraktListSortOrder? sortOrder,
            TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var movieListsGetRequest = new MovieListsGetRequest
            {
                Id = MovieID,
                ListType = listType,
                SortOrder = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            movieListsGetRequest.BuildUri();
            movieListsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieListsGetRequestHasValidOAuthRequirement()
        {
            var movieListsGetRequest = new MovieListsGetRequest { Id = MovieID };
            movieListsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieListsGetRequestIsGetRequest()
        {
            var movieListsGetRequest = new MovieListsGetRequest { Id = MovieID };
            movieListsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieListsGetRequestHasCorrectRequestObjectType()
        {
            var movieListsGetRequest = new MovieListsGetRequest { Id = MovieID };
            movieListsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieListsGetRequestValidate()
        {
            var movieListsGetRequest = new MovieListsGetRequest { Id = string.Empty };

            Action act = () => movieListsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieListsGetRequest = new MovieListsGetRequest { Id = "  " };

            act = () => movieListsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieListsGetRequest = new MovieListsGetRequest { Id = "id with spaces" };

            act = () => movieListsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
