using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSettingsTests
    {
        private const string GetSettingsUri = "users/settings";

        [Fact]
        public async Task TestGetSettings()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usersettings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSettingsUri, responseContent);
            
            TraktResponse<TraktUserSettings> response = await client.Users.GetSettingsAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserSettings responseValue = response.Content;

            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("sean");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Sean Rudford");
            responseValue.User.VIP.ShouldBe(true);
            responseValue.User.VIPEP.ShouldBe(true);
            responseValue.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            responseValue.User.Location.ShouldBe("SF");
            responseValue.User.About.ShouldBe("I have all your cassette tapes.");
            responseValue.User.Gender.ShouldBe(TraktGender.Male);
            responseValue.User.Age.ShouldBe(35U);
            responseValue.User.Images.ShouldNotBeNull();
            responseValue.User.Images.Avatar.ShouldNotBeNull();
            responseValue.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            responseValue.Account.ShouldNotBeNull();
            responseValue.Account.DateFormat.ShouldBe(TraktDateFormat.DayMonthYear);
            responseValue.Account.Timezone.ShouldBe("America/Los_Angeles");
            responseValue.Account.Time24Hr.ShouldBe(true);
            responseValue.Account.CoverImage.ShouldBe("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            responseValue.Connections.ShouldNotBeNull();
            responseValue.Connections.Twitter.ShouldBe(true);
            responseValue.Connections.Mastodon.ShouldBe(true);
            responseValue.Connections.Google.ShouldBe(true);
            responseValue.Connections.Tumblr.ShouldBe(true);
            responseValue.Connections.Medium.ShouldBe(true);
            responseValue.Connections.Slack.ShouldBe(true);
            responseValue.Connections.Facebook.ShouldBe(true);
            responseValue.SharingText.ShouldNotBeNull();
            responseValue.SharingText.Watching.ShouldBe("I'm watching [item]");
            responseValue.SharingText.Watched.ShouldBe("I just watched [item]");
            responseValue.SharingText.Rated.ShouldBe("[item] [stars]");
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
        public async Task TestGetSettingsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSettingsUri, statusCode);

            Func<Task<TraktResponse<TraktUserSettings>>> act = () => client.Users.GetSettingsAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
