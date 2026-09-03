#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserMonthInReviewGetRequestTests
    {
        [Theory]
        [InlineData("sean", 2024U, 10U, "users/sean/mir/2024/10")]
        [InlineData("sean", 2024U, 10U, "users/sean/mir/2024/10?extended=full", TraktExtendedInfo.Full)]
        public void TestUserMonthInReviewGetRequestHasValidURIPath(string username, uint year, uint month, string expectedURIPath, TraktExtendedInfo? extendedInfo = null)
        {
            var request = new UserMonthInReviewGetRequest
            {
                Id = username,
                Year = year,
                Month = month,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserMonthInReviewGetRequestHasValidOAuthRequirement()
        {
            var request = new UserMonthInReviewGetRequest { Id = "sean", Year = 2024, Month = 10 };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserMonthInReviewGetRequestIsGetRequest()
        {
            var request = new UserMonthInReviewGetRequest { Id = "sean", Year = 2024, Month = 10 };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserMonthInReviewGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserMonthInReviewGetRequest { Id = "sean", Year = 2024, Month = 10 };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserMonthInReviewGetRequestValidate()
        {
            var request = new UserMonthInReviewGetRequest { Id = string.Empty, Year = 2024, Month = 10 };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserMonthInReviewGetRequest { Id = "  ", Year = 2024, Month = 10 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserMonthInReviewGetRequest { Id = "id with spaces", Year = 2024, Month = 10 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserMonthInReviewGetRequest { Id = "sean", Year = 0, Month = 10 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserMonthInReviewGetRequest { Id = "sean", Year = 2024, Month = 0 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserMonthInReviewGetRequest { Id = "sean", Year = 2024, Month = 10 };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
