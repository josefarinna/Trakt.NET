#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserSavedFilterAddPostRequestTests
    {
        private const string URIPath = "users/saved_filters";

        [Fact]
        public void TestUserSavedFilterAddPostRequestHasValidURIPath()
        {
            var request = new UserSavedFilterAddPostRequest
            {
                TraktUserSavedFilterPosts = [new TraktUserSavedFilterPost { Name = "Test Filter", Url = "/movies/recommended/weekly" }]
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSavedFilterAddPostRequestHasValidOAuthRequirement()
        {
            var request = new UserSavedFilterAddPostRequest
            {
                TraktUserSavedFilterPosts = [new TraktUserSavedFilterPost { Name = "Test Filter", Url = "/movies/recommended/weekly" }]
            };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSavedFilterAddPostRequestIsPostRequest()
        {
            var request = new UserSavedFilterAddPostRequest
            {
                TraktUserSavedFilterPosts = [new TraktUserSavedFilterPost { Name = "Test Filter", Url = "/movies/recommended/weekly" }]
            };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserSavedFilterAddPostRequestHasCorrectRequestObjectType()
        {
            var request = new UserSavedFilterAddPostRequest
            {
                TraktUserSavedFilterPosts = [new TraktUserSavedFilterPost { Name = "Test Filter", Url = "/movies/recommended/weekly" }]
            };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSavedFilterAddPostRequestValidate()
        {
            var request = new UserSavedFilterAddPostRequest { TraktUserSavedFilterPosts = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserSavedFilterAddPostRequest
            {
                TraktUserSavedFilterPosts = [new TraktUserSavedFilterPost { Name = "Test Filter", Url = "/movies/recommended/weekly" }]
            };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
