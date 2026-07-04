#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserHiddenItemsAddPostRequestTests
    {
        private const string URIPath = "users/hidden";

        [Theory]
        [InlineData(TraktHiddenItemsSection.Calendar, $"{URIPath}/calendar")]
        [InlineData(TraktHiddenItemsSection.ProgressWatched, $"{URIPath}/progress_watched")]
        [InlineData(TraktHiddenItemsSection.ProgressCollected, $"{URIPath}/progress_collected")]
        [InlineData(TraktHiddenItemsSection.Recommendations, $"{URIPath}/recommendations")]
        [InlineData(TraktHiddenItemsSection.ProgressWatchedReset, $"{URIPath}/progress_watched_reset")]
        [InlineData(TraktHiddenItemsSection.Comments, $"{URIPath}/comments")]
        [InlineData(TraktHiddenItemsSection.Dropped, $"{URIPath}/dropped")]
        public void TestUserHiddenItemsAddPostRequestHasValidURIPath(TraktHiddenItemsSection section, string expectedURIPath)
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest
            {
                Section = section,
                TraktUserHiddenItemsPost = new TraktUserHiddenItemsPost()
            };

            userHiddenItemsAddPostRequest.BuildUri();
            userHiddenItemsAddPostRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestHasValidOAuthRequirement()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest { TraktUserHiddenItemsPost = default! };
            userHiddenItemsAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestIsPostRequest()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest { TraktUserHiddenItemsPost = default! };
            userHiddenItemsAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestHasCorrectRequestObjectType()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest { TraktUserHiddenItemsPost = default! };
            userHiddenItemsAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserHiddenItemsAddPostRequestValidate()
        {
            var userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest { TraktUserHiddenItemsPost = default! };
            Action act = () => userHiddenItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest { Section = TraktHiddenItemsSection.Calendar, TraktUserHiddenItemsPost = default! };
            act = () => userHiddenItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userHiddenItemsAddPostRequest = new UserHiddenItemsAddPostRequest { Section = TraktHiddenItemsSection.Calendar, TraktUserHiddenItemsPost = new TraktUserHiddenItemsPost() };
            act = () => userHiddenItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
