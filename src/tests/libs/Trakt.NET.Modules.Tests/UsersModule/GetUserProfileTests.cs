using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetUserProfileTests
    {
        private const string GetUserProfileUri = $"users/{Username}";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetUserProfile()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\profile.json");

            TraktClient client = ModuleTestUtility.GetClient(GetUserProfileUri, responseContent);
            
            TraktResponse<TraktUser> response = await client.Users.GetUserProfileAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUser responseValue = response.Content;

            responseValue.Username.ShouldBe("sean");
            responseValue.Private.ShouldBe(false);
            responseValue.Name.ShouldBe("Sean Rudford");
            responseValue.VIP.ShouldBe(true);
            responseValue.VIPEP.ShouldBe(true);
            responseValue.JoinedAt.ShouldBeNull();
            responseValue.Location.ShouldBeNullOrEmpty();
            responseValue.About.ShouldBeNullOrEmpty();
            responseValue.Gender.ShouldBeNull();
            responseValue.Age.ShouldBeNull();
            responseValue.Images.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetUserProfileWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\profile.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetUserProfileUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktUser> response = await client.Users.GetUserProfileAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUser responseValue = response.Content;

            responseValue.Username.ShouldBe("sean");
            responseValue.Private.ShouldBe(false);
            responseValue.Name.ShouldBe("Sean Rudford");
            responseValue.VIP.ShouldBe(true);
            responseValue.VIPEP.ShouldBe(true);
            responseValue.JoinedAt.ShouldBeNull();
            responseValue.Location.ShouldBeNullOrEmpty();
            responseValue.About.ShouldBeNullOrEmpty();
            responseValue.Gender.ShouldBeNull();
            responseValue.Age.ShouldBeNull();
            responseValue.Images.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetUserProfileWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\profile.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me", responseContent);
            
            TraktResponse<TraktUser> response = await client.Users.GetUserProfileAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUser responseValue = response.Content;

            responseValue.Username.ShouldBe("sean");
            responseValue.Private.ShouldBe(false);
            responseValue.Name.ShouldBe("Sean Rudford");
            responseValue.VIP.ShouldBe(true);
            responseValue.VIPEP.ShouldBe(true);
            responseValue.JoinedAt.ShouldBeNull();
            responseValue.Location.ShouldBeNullOrEmpty();
            responseValue.About.ShouldBeNullOrEmpty();
            responseValue.Gender.ShouldBeNull();
            responseValue.Age.ShouldBeNull();
            responseValue.Images.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetUserProfileWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\profile.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetUserProfileUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktUser> response = await client.Users.GetUserProfileAsync(Username, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUser responseValue = response.Content;

            responseValue.Username.ShouldBe("sean");
            responseValue.Private.ShouldBe(false);
            responseValue.Name.ShouldBe("Sean Rudford");
            responseValue.VIP.ShouldBe(true);
            responseValue.VIPEP.ShouldBe(true);
            responseValue.JoinedAt.ShouldBeNull();
            responseValue.Location.ShouldBeNullOrEmpty();
            responseValue.About.ShouldBeNullOrEmpty();
            responseValue.Gender.ShouldBeNull();
            responseValue.Age.ShouldBeNull();
            responseValue.Images.ShouldBeNull();
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetUserProfileThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetUserProfileUri, statusCode);

            Func<Task<TraktResponse<TraktUser>>> act = () => client.Users.GetUserProfileAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
