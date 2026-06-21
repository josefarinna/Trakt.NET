#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieCommentsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/comments";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktCommentSortOrder.Newest, null, null, null, $"{URIPath}/newest")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.VIP, null, null, $"{URIPath}?extended=vip")]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, null, null, $"{URIPath}/newest")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.VIP, null, null, $"{URIPath}?extended=vip")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.VIP, null, null, $"{URIPath}/newest?extended=vip")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, null, 10, null, $"{URIPath}/newest?page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, 20, $"{URIPath}/newest?limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, 10, 20, $"{URIPath}/newest?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.VIP, 10, null, $"{URIPath}?extended=vip&page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.VIP, null, 20, $"{URIPath}?extended=vip&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.VIP, 10, 20, $"{URIPath}?extended=vip&page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.VIP, 10, null, $"{URIPath}/newest?extended=vip&page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.VIP, null, 20, $"{URIPath}/newest?extended=vip&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.VIP, 10, 20, $"{URIPath}/newest?extended=vip&page=10&limit=20")]
        public void TestMovieCommentsGetRequestHasValidURIPath(TraktCommentSortOrder? sortOrder,
            TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var movieCommentsGetRequest = new MovieCommentsGetRequest
            {
                Id = MovieID,
                SortOrder = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            movieCommentsGetRequest.BuildUri();
            movieCommentsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieCommentsGetRequestHasValidOAuthRequirement()
        {
            var movieCommentsGetRequest = new MovieCommentsGetRequest { Id = MovieID };
            movieCommentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestMovieCommentsGetRequestIsGetRequest()
        {
            var movieCommentsGetRequest = new MovieCommentsGetRequest { Id = MovieID };
            movieCommentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieCommentsGetRequestHasCorrectRequestObjectType()
        {
            var movieCommentsGetRequest = new MovieCommentsGetRequest { Id = MovieID };
            movieCommentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieCommentsGetRequestValidate()
        {
            var movieCommentsGetRequest = new MovieCommentsGetRequest { Id = string.Empty };
            Action act = () => movieCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieCommentsGetRequest = new MovieCommentsGetRequest { Id = "  " };
            act = () => movieCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieCommentsGetRequest = new MovieCommentsGetRequest { Id = "id with spaces" };
            act = () => movieCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
