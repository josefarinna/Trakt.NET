using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchingUsersTests
    {
        private const string GetShowWatchingUsersUriPrefix = "shows";
        private const string GetShowWatchingUsersUriSuffix = "watching";
        private const string GetShowWatchingUsersUriWithSlug = GetShowWatchingUsersUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + GetShowWatchingUsersUriSuffix;

        [Theory]
        [InlineData(null, $"{GetShowWatchingUsersUriPrefix}/1390/{GetShowWatchingUsersUriSuffix}", "Shows\\showwatchingusers.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetShowWatchingUsersUriPrefix}/1390/{GetShowWatchingUsersUriSuffix}", "Shows\\showwatchingusers.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowWatchingUsersUriPrefix}/1390/{GetShowWatchingUsersUriSuffix}?extended=full", "Shows\\showwatchingusers.json")]
        public async Task TestGetShowWatchingUsersWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowID, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowWatchingUsersUriWithSlug, "Shows\\showwatchingusers.json")]
        [InlineData(TraktExtendedInfo.None, GetShowWatchingUsersUriWithSlug, "Shows\\showwatchingusers.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowWatchingUsersUriWithSlug}?extended=full", "Shows\\showwatchingusers.json")]
        public async Task TestGetShowWatchingUsersWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowSlug, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktUser> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktUser> users = response.Content!;

            users[0].ShouldNotBeNull();
            users[0].Username.ShouldBe("user1");
            users[0].Name.ShouldBe("User Name 1");
            users[0].IDs.ShouldNotBeNull();
            users[0].IDs!.Slug.ShouldBe("user1");

            users[1].ShouldNotBeNull();
            users[1].Username.ShouldBe("user2");
            users[1].Name.ShouldBe("User Name 2");
            users[1].IDs.ShouldNotBeNull();
            users[1].IDs!.Slug.ShouldBe("user2");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowWatchingUsersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowWatchingUsersAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
