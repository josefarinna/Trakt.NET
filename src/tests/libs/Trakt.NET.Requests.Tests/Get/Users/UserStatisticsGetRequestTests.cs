#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserStatisticsGetRequestTests
    {
        private const string URIPath = "users/123/stats";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserStatisticsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var userStatisticsGetRequest = new UserStatisticsGetRequest
            {
                Id = "123",
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userStatisticsGetRequest.BuildUri();
            userStatisticsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserStatisticsGetRequestHasValidOAuthRequirement()
        {
            var userStatisticsGetRequest = new UserStatisticsGetRequest { Id = default! };
            userStatisticsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserStatisticsGetRequestIsGetRequest()
        {
            var userStatisticsGetRequest = new UserStatisticsGetRequest { Id = default! };
            userStatisticsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserStatisticsGetRequestHasCorrectRequestObjectType()
        {
            var userStatisticsGetRequest = new UserStatisticsGetRequest { Id = default! };
            userStatisticsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserStatisticsGetRequestValidate()
        {
            var userStatisticsGetRequest = new UserStatisticsGetRequest { Id = string.Empty };
            Action act = () => userStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userStatisticsGetRequest = new UserStatisticsGetRequest { Id = "  " };
            act = () => userStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userStatisticsGetRequest = new UserStatisticsGetRequest { Id = "id with spaces" };
            act = () => userStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
