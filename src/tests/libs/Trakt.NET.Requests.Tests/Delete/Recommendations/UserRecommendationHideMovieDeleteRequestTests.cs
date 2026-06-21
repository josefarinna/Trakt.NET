#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Recommendations
{
    public sealed class UserRecommendationHideMovieDeleteRequestTests
    {
        private const string URIPath = "recommendations/movies/123";

        [Fact]
        public void TestUserRecommendationHideMovieDeleteRequestHasValidURIPath()
        {
            var userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest
            {
                Id = "123"
            };

            userRecommendationHideMovieDeleteRequest.BuildUri();
            userRecommendationHideMovieDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserRecommendationHideMovieDeleteRequestHasValidOAuthRequirement()
        {
            var userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest { Id = default! };
            userRecommendationHideMovieDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserRecommendationHideMovieDeleteRequestIsDeleteRequest()
        {
            var userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest { Id = default! };
            userRecommendationHideMovieDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserRecommendationHideMovieDeleteRequestHasCorrectRequestObjectType()
        {
            var userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest { Id = default! };
            userRecommendationHideMovieDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestUserRecommendationHideMovieDeleteRequestValidate()
        {
            var userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest { Id = string.Empty };
            Action act = () => userRecommendationHideMovieDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest { Id = "  " };
            act = () => userRecommendationHideMovieDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userRecommendationHideMovieDeleteRequest = new UserRecommendationHideMovieDeleteRequest { Id = "id with spaces" };
            act = () => userRecommendationHideMovieDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
