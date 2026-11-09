#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserYearInReviewRangeGetRequestTests
    {
        [Theory]
        [InlineData("sean", 2020U, 2024U, "users/sean/yir/2020/2024")]
        [InlineData("sean", 2020U, 2024U, "users/sean/yir/2020/2024?extended=full", null, TraktExtendedInfo.Full)]
        [InlineData("sean", 2020U, 2024U, "users/sean/yir/2020/2024?slurm=vip_token", "vip_token")]
        [InlineData("sean", 2020U, 2024U, "users/sean/yir/2020/2024?slurm=vip_token&extended=full", "vip_token", TraktExtendedInfo.Full)]
        public void TestUserYearInReviewRangeGetRequestHasValidURIPath(string username, uint year, uint yearEnd, string expectedURIPath,
            string? slurm = null, TraktExtendedInfo? extendedInfo = null)
        {
            var request = new UserYearInReviewRangeGetRequest
            {
                Id = username,
                Year = year,
                YearEnd = yearEnd,
                Slurm = slurm,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserYearInReviewRangeGetRequestHasValidOAuthRequirement()
        {
            var request = new UserYearInReviewRangeGetRequest { Id = "sean", Year = 2020, YearEnd = 2024 };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserYearInReviewRangeGetRequestIsGetRequest()
        {
            var request = new UserYearInReviewRangeGetRequest { Id = "sean", Year = 2020, YearEnd = 2024 };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserYearInReviewRangeGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserYearInReviewRangeGetRequest { Id = "sean", Year = 2020, YearEnd = 2024 };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserYearInReviewRangeGetRequestValidate()
        {
            var request = new UserYearInReviewRangeGetRequest { Id = string.Empty, Year = 2020, YearEnd = 2024 };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewRangeGetRequest { Id = "  ", Year = 2020, YearEnd = 2024 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewRangeGetRequest { Id = "id with spaces", Year = 2020, YearEnd = 2024 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewRangeGetRequest { Id = "sean", Year = 0, YearEnd = 2024 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewRangeGetRequest { Id = "sean", Year = 2020, YearEnd = 0 };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserYearInReviewRangeGetRequest { Id = "sean", Year = 2020, YearEnd = 2024 };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
