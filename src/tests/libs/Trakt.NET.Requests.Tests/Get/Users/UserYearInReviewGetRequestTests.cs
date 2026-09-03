#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserYearInReviewGetRequestTests
    {
        [Theory]
        [InlineData("sean", 2024U, "users/sean/yir/2024")]
        [InlineData("sean", 2024U, "users/sean/yir/2024?extended=full", TraktExtendedInfo.Full)]
        public void TestUserYearInReviewGetRequestHasValidURIPath(string username, uint year, string expectedURIPath, TraktExtendedInfo? extendedInfo = null)
        {
            var request = new UserYearInReviewGetRequest
            {
                Id = username,
                Year = year,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserYearInReviewGetRequestHasValidOAuthRequirement()
        {
            var request = new UserYearInReviewGetRequest { Id = "sean", Year = 2024 };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserYearInReviewGetRequestIsGetRequest()
        {
            var request = new UserYearInReviewGetRequest { Id = "sean", Year = 2024 };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserYearInReviewGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserYearInReviewGetRequest { Id = "sean", Year = 2024 };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserYearInReviewGetRequestValidate()
        {
            var request = new UserYearInReviewGetRequest { Id = string.Empty, Year = 2024 };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewGetRequest { Id = "  ", Year = 2024 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewGetRequest { Id = "id with spaces", Year = 2024 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewGetRequest { Id = "sean", Year = 0 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewGetRequest { Id = "sean", Year = 2024 };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
