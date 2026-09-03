using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetMinimalWatchedShowsTests
    {
        private const string GetMinimalWatchedShowsUri = $"users/{Username}/watched/shows";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ShowsCount = 1U;

        [Fact]
        public async Task TestGetMinimalWatchedShows()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedShowsUri}?extended=min", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Content["1390"].ShouldNotBeNull();
            response.Content["1390"]["1"].ShouldNotBeNull();
            response.Content["1390"]["1"]["1"].Count.ShouldBe(2);
            response.Content["1390"]["1"]["1"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Content["1390"]["1"]["1"][1].ShouldBe("2015-01-01T12:00:00.000Z");
            response.Content["1390"]["1"]["2"].Count.ShouldBe(1);
            response.Content["1390"]["1"]["2"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMinimalWatchedShowsUri}?extended=min", responseContent, Page, 1, Limit, ShowsCount);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/watched/shows?extended=min", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedShowsUri}?specials=true&extended=min", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, specials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithSeasonNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedShowsUri}?season_numbers=true&extended=min", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, seasonNumbers: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedShowsUri}?extended=min&page={Page}", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedShowsUri}?extended=min&limit={Limit}", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedShowsUri}?extended=min&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedShowsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetMinimalWatchedShowsUri}?specials=true&season_numbers=true&extended=min&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response =
                await client.Users.GetMinimalWatchedShowsAsync(Username, true, true, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
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
        public async Task TestGetMinimalWatchedShowsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMinimalWatchedShowsUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>>>> act =
                () => client.Users.GetMinimalWatchedShowsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null!)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("user name")]
        public async Task TestGetMinimalWatchedShowsThrowsValidationException(string? username)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMinimalWatchedShowsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>>>> act =
                () => client.Users.GetMinimalWatchedShowsAsync(username!, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
