#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserHiddenItemsRemovePostRequestTests
    {
        [Theory]
        [InlineData(TraktHiddenItemsSection.Calendar, "users/hidden/calendar/remove")]
        [InlineData(TraktHiddenItemsSection.Comments, "users/hidden/comments/remove")]
        [InlineData(TraktHiddenItemsSection.ProgressCollected, "users/hidden/progresscollected/remove")]
        [InlineData(TraktHiddenItemsSection.Dropped, "users/hidden/dropped/remove")]
        [InlineData(TraktHiddenItemsSection.Recommendations, "users/hidden/recommendations/remove")]
        public void TestUserHiddenItemsRemovePostRequestHasValidURIPath(TraktHiddenItemsSection section, string expectedURIPath)
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest
            {
                Section = section
            };

            userHiddenItemsRemovePostRequest.BuildUri();
            userHiddenItemsRemovePostRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestHasValidOAuthRequirement()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest();
            userHiddenItemsRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestIsPostRequest()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest();
            userHiddenItemsRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestHasCorrectRequestObjectType()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest();
            userHiddenItemsRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestValidate()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest();
            Action act = () => userHiddenItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
