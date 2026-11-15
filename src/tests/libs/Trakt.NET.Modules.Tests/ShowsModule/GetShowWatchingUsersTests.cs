using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchingUsersTests
    {
        private const string GetShowWatchingUsersUri = $"shows/{TestConstants.Shows.ShowID}/watching";
        private const string GetShowWatchingUsersUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/watching";
        private const int ListItemCount = 2;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetShowWatchingUsersUri)]
        [InlineData(ExtendedInfo, $"{GetShowWatchingUsersUri}?extended=full")]
        public async Task TestGetShowWatchingUsersWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.TraktShowID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowWatchingUsersWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUri, statusCode);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowWatchingUsersAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
