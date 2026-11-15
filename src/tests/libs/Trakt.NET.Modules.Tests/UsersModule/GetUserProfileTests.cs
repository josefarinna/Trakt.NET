using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetUserProfileTests
    {
        private const string GetUserProfileUri = $"users/{Username}";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetUserProfileUri)]
        [InlineData(ExtendedInfo, $"{GetUserProfileUri}?extended=full")]
        public async Task TestGetUserProfile(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\profile.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktUser> response = await client.Users.GetUserProfileAsync(Username, extendedInfo, TestContext.Current.CancellationToken);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetUserProfileThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetUserProfileUri, statusCode);

            Func<Task<TraktResponse<TraktUser>>> act = () => client.Users.GetUserProfileAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
