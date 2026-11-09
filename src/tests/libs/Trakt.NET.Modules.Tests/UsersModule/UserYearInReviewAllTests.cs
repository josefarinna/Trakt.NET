using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UserYearInReviewAllTests
    {
        private const string Username = "sean";
        private const string Slurm = "vip_token";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const string URIPath = "users/sean/yir/all";

        [Fact]
        public async Task TestGetAllTimeYearInReview()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");
            TraktClient client = ModuleTestUtility.GetClient(URIPath, responseContent);

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllTimeYearInReviewWithSlurm()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");
            TraktClient client = ModuleTestUtility.GetClient($"{URIPath}?slurm={Slurm}", responseContent);

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync(Username, Slurm, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllTimeYearInReviewWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");
            TraktClient client = ModuleTestUtility.GetClient($"{URIPath}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync(Username, extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllTimeYearInReviewWithSlurmAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review_all.json");
            TraktClient client = ModuleTestUtility.GetClient($"{URIPath}?slurm={Slurm}&extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktUserAllTimeYearInReview> response = await client.Users.GetAllTimeYearInReviewAsync(Username, Slurm, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
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
