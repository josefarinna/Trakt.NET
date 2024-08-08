namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeCommentsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/comments";

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
        public void TestEpisodeCommentsGetRequestHasValidURIPath(TraktCommentSortOrder? sortOrder,
            TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                SortOrder = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            episodeCommentsGetRequest.BuildUri();
            episodeCommentsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeCommentsGetRequestHasValidOAuthRequirement()
        {
            var episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeCommentsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestEpisodeCommentsGetRequestIsGetRequest()
        {
            var episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeCommentsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeCommentsGetRequestHasCorrectRequestObjectType()
        {
            var episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeCommentsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeCommentsGetRequestValidate()
        {
            var episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodeCommentsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeCommentsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeCommentsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeCommentsGetRequest.Validate();
            act.Should().NotThrow();

            episodeCommentsGetRequest = new EpisodeCommentsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeCommentsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
