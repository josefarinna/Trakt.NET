using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UserMonthInReviewTests
    {
        private const string Username = "sean";
        private const uint Year = 2024;
        private const uint Month = 10;
        private const string Slurm = "vip_token";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const string URIPath = "users/sean/mir/2024/10";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(Slurm, null, $"{URIPath}?slurm={Slurm}")]
        [InlineData(null, ExtendedInfo, $"{URIPath}?extended=full")]
        [InlineData(Slurm, ExtendedInfo, $"{URIPath}?slurm={Slurm}&extended=full")]
        public async Task TestGetMonthInReview(string? slurm, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\month_in_review.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktUserMonthInReview> response = await client.Users.GetMonthInReviewAsync(Username, Year, Month, slurm, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMonthInReviewWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\month_in_review.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktUserMonthInReview> response = await client.Users.GetMonthInReviewAsync(Username, Year, Month, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMonthInReviewWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\month_in_review.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/mir/2024/10", responseContent);

            TraktResponse<TraktUserMonthInReview> response = await client.Users.GetMonthInReviewAsync("me", Year, Month, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMonthInReviewThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(URIPath, statusCode);

            Func<Task<TraktResponse<TraktUserMonthInReview>>> act = () => client.Users.GetMonthInReviewAsync(Username, Year, Month, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMonthInReviewArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(URIPath, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktUserMonthInReview>>> act = () => client.Users.GetMonthInReviewAsync(null!, Year, Month, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetMonthInReviewAsync(string.Empty, Year, Month, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetMonthInReviewAsync("  ", Year, Month, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetMonthInReviewAsync(Username, 0, Month, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetMonthInReviewAsync(Username, Year, 0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
