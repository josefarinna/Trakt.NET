using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UserYearInReviewRangeTests
    {
        private const string Username = "sean";
        private const uint Year = 2020;
        private const uint YearEnd = 2024;
        private const string Slurm = "vip_token";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const string URIPath = "users/sean/yir/2020/2024";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(Slurm, null, $"{URIPath}?slurm={Slurm}")]
        [InlineData(null, ExtendedInfo, $"{URIPath}?extended=full")]
        [InlineData(Slurm, ExtendedInfo, $"{URIPath}?slurm={Slurm}&extended=full")]
        public async Task TestGetYearInReviewRange(string? slurm, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, slurm, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetYearInReviewRangeWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetYearInReviewRangeWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/yir/2020/2024", responseContent);

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync("me", Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetYearInReviewRangeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(URIPath, statusCode);

            Func<Task<TraktResponse<TraktUserYearInReview>>> act = () => client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetYearInReviewRangeArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(URIPath, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktUserYearInReview>>> act = () => client.Users.GetYearInReviewRangeAsync(null!, Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetYearInReviewRangeAsync(string.Empty, Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetYearInReviewRangeAsync("  ", Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetYearInReviewRangeAsync(Username, 0, YearEnd, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetYearInReviewRangeAsync(Username, Year, 0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
