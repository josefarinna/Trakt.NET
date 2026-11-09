#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserYearInReviewAllGetRequestTests
    {
        [Theory]
        [InlineData("sean", "users/sean/yir/all")]
        [InlineData("sean", "users/sean/yir/all?extended=full", null, TraktExtendedInfo.Full)]
        [InlineData("sean", "users/sean/yir/all?slurm=vip_token", "vip_token")]
        [InlineData("sean", "users/sean/yir/all?slurm=vip_token&extended=full", "vip_token", TraktExtendedInfo.Full)]
        public void TestUserYearInReviewAllGetRequestHasValidURIPath(string username, string expectedURIPath,
            string? slurm = null, TraktExtendedInfo? extendedInfo = null)
        {
            var request = new UserYearInReviewAllGetRequest
            {
                Id = username,
                Slurm = slurm,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserYearInReviewAllGetRequestHasValidOAuthRequirement()
        {
            var request = new UserYearInReviewAllGetRequest { Id = "sean" };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserYearInReviewAllGetRequestIsGetRequest()
        {
            var request = new UserYearInReviewAllGetRequest { Id = "sean" };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserYearInReviewAllGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserYearInReviewAllGetRequest { Id = "sean" };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserYearInReviewAllGetRequestValidate()
        {
            var request = new UserYearInReviewAllGetRequest { Id = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewAllGetRequest { Id = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewAllGetRequest { Id = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewAllGetRequest { Id = "sean" };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
