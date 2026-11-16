using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UserYearInReviewAllTests
    {
        private const string Username = "sean";
        private const string Slurm = "vip_token";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const string URIPath = "users/sean/yir/all";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(Slurm, null, $"{URIPath}?slurm={Slurm}")]
        [InlineData(null, ExtendedInfo, $"{URIPath}?extended=full")]
        [InlineData(Slurm, ExtendedInfo, $"{URIPath}?slurm={Slurm}&extended=full")]
        public async Task TestGetAllTimeYearInReview(string? slurm, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync(Username, slurm, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllTimeYearInReviewWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllTimeYearInReviewWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/yir/all", responseContent);

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetAllTimeYearInReviewThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(URIPath, statusCode);

            Func<Task<TraktResponse<TraktUserAllTimeYearInReview>>> act = () => client.Users.GetAllTimeYearInReviewAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllTimeYearInReviewArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(URIPath, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktUserAllTimeYearInReview>>> act = () => client.Users.GetAllTimeYearInReviewAsync(null!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetAllTimeYearInReviewAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetAllTimeYearInReviewAsync("  ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
