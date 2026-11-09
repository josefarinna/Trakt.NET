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

        [Fact]
        public async Task TestGetYearInReviewRange()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");
            TraktClient client = ModuleTestUtility.GetClient(URIPath, responseContent);

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetYearInReviewRangeWithSlurm()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");
            TraktClient client = ModuleTestUtility.GetClient($"{URIPath}?slurm={Slurm}", responseContent);

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, Slurm, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetYearInReviewRangeWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");
            TraktClient client = ModuleTestUtility.GetClient($"{URIPath}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetYearInReviewRangeWithSlurmAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\year_in_review.json");
            TraktClient client = ModuleTestUtility.GetClient($"{URIPath}?slurm={Slurm}&extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktUserYearInReview> response = await client.Users.GetYearInReviewRangeAsync(Username, Year, YearEnd, Slurm, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
