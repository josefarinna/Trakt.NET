#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Recommendations
{
    public sealed class UserRecommendationHideShowDeleteRequestTests
    {
        private const string URIPath = "recommendations/shows/123";

        [Fact]
        public void TestUserRecommendationHideShowDeleteRequestHasValidURIPath()
        {
            var userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest
            {
                Id = "123"
            };

            userRecommendationHideShowDeleteRequest.BuildUri();
            userRecommendationHideShowDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserRecommendationHideShowDeleteRequestHasValidOAuthRequirement()
        {
            var userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest { Id = default! };
            userRecommendationHideShowDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserRecommendationHideShowDeleteRequestIsDeleteRequest()
        {
            var userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest { Id = default! };
            userRecommendationHideShowDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserRecommendationHideShowDeleteRequestHasCorrectRequestObjectType()
        {
            var userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest { Id = default! };
            userRecommendationHideShowDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestUserRecommendationHideShowDeleteRequestValidate()
        {
            var userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest { Id = string.Empty };
            Action act = () => userRecommendationHideShowDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest { Id = "  " };
            act = () => userRecommendationHideShowDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userRecommendationHideShowDeleteRequest = new UserRecommendationHideShowDeleteRequest { Id = "id with spaces" };
            act = () => userRecommendationHideShowDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
