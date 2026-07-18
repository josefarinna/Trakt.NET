#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserHiddenItemsRemovePostRequestTests
    {
        private const string URIPath = "users/hidden";

        [Theory]
        [InlineData(TraktHiddenItemsSection.Calendar, $"{URIPath}/calendar/remove")]
        [InlineData(TraktHiddenItemsSection.ProgressWatched, $"{URIPath}/progress_watched/remove")]
        [InlineData(TraktHiddenItemsSection.ProgressCollected, $"{URIPath}/progress_collected/remove")]
        [InlineData(TraktHiddenItemsSection.Recommendations, $"{URIPath}/recommendations/remove")]
        [InlineData(TraktHiddenItemsSection.ProgressWatchedReset, $"{URIPath}/progress_watched_reset/remove")]
        [InlineData(TraktHiddenItemsSection.Comments, $"{URIPath}/comments/remove")]
        [InlineData(TraktHiddenItemsSection.Dropped, $"{URIPath}/dropped/remove")]
        public void TestUserHiddenItemsRemovePostRequestHasValidURIPath(TraktHiddenItemsSection section, string expectedURIPath)
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest
            {
                Section = section.AsPathParameter(),
                TraktUserHiddenItemsRemovePost = new TraktUserHiddenItemsRemovePost()
            };

            userHiddenItemsRemovePostRequest.BuildUri();
            userHiddenItemsRemovePostRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestHasValidOAuthRequirement()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = TraktHiddenItemsSection.Calendar.AsPathParameter(), TraktUserHiddenItemsRemovePost = default! };
            userHiddenItemsRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestIsPostRequest()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = TraktHiddenItemsSection.Calendar.AsPathParameter(), TraktUserHiddenItemsRemovePost = default! };
            userHiddenItemsRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestHasCorrectRequestObjectType()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = TraktHiddenItemsSection.Calendar.AsPathParameter(), TraktUserHiddenItemsRemovePost = default! };
            userHiddenItemsRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserHiddenItemsRemovePostRequestValidate()
        {
            var userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = default!, TraktUserHiddenItemsRemovePost = default! };
            Action act = () => userHiddenItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = TraktHiddenItemsSection.Calendar.AsPathParameter(), TraktUserHiddenItemsRemovePost = default! };
            act = () => userHiddenItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = TraktHiddenItemsSection.Calendar.AsPathParameter(), TraktUserHiddenItemsRemovePost = default! };
            act = () => userHiddenItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userHiddenItemsRemovePostRequest = new UserHiddenItemsRemovePostRequest { Section = TraktHiddenItemsSection.Calendar.AsPathParameter(), TraktUserHiddenItemsRemovePost = new TraktUserHiddenItemsRemovePost() };
            act = () => userHiddenItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
