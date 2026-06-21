#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserHiddenItemsAddPostRequestTests
    {
        private const string URIPath = "users/hidden";

        [Theory]
        [InlineData(TraktHiddenItemsSection.Unspecified, $"{URIPath}/")]
        [InlineData(TraktHiddenItemsSection.Calendar, $"{URIPath}/calendar")]
        public void TestUserHiddenItemsAddPostRequestHasValidURIPath(TraktHiddenItemsSection section, string expectedURIPath)
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest
            {
                Section = section
            };

            userHiddenItemsAddPostRequest.BuildUri();
            userHiddenItemsAddPostRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestHasValidOAuthRequirement()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest();
            userHiddenItemsAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestIsPostRequest()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest();
            userHiddenItemsAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestHasCorrectRequestObjectType()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest();
            userHiddenItemsAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestValidate()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest();
            Action act = () => userHiddenItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
