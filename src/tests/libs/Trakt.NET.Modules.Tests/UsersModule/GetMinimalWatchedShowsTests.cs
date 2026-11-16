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

        [Theory]
        [InlineData(null, null, null, null, $"{GetMinimalWatchedShowsUri}?extended=min")]
        [InlineData(true, null, null, null, $"{GetMinimalWatchedShowsUri}?specials=true&extended=min")]
        [InlineData(null, true, null, null, $"{GetMinimalWatchedShowsUri}?season_numbers=true&extended=min")]
        [InlineData(null, null, Page, null, $"{GetMinimalWatchedShowsUri}?extended=min&page=2")]
        [InlineData(null, null, null, Limit, $"{GetMinimalWatchedShowsUri}?extended=min&limit=4")]
        [InlineData(null, null, Page, Limit, $"{GetMinimalWatchedShowsUri}?extended=min&page=2&limit=4")]
        [InlineData(true, true, Page, Limit, $"{GetMinimalWatchedShowsUri}?specials=true&season_numbers=true&extended=min&page=2&limit=4")]
        public async Task TestGetMinimalWatchedShows(bool? specials, bool? seasonNumbers, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedshowsminimal.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ShowsCount);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>> response = await client.Users.GetMinimalWatchedShowsAsync(Username, specials, seasonNumbers, page, limit, TestContext.Current.CancellationToken);

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
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMinimalWatchedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
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
