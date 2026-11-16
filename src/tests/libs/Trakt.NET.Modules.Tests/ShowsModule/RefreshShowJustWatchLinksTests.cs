using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class RefreshShowJustWatchLinksTests
    {
        private const string RefreshShowUri = $"shows/{TestConstants.Shows.ShowID}/refresh/justwatch";
        private const string RefreshShowUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/refresh/justwatch";

        [Fact]
        public async Task TestRefreshShowJustWatchLinksWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUri, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.RefreshShowJustWatchLinksAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshShowJustWatchLinksWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.RefreshShowJustWatchLinksAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshShowJustWatchLinksWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.RefreshShowJustWatchLinksAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestRefreshShowJustWatchLinksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Shows.RefreshShowJustWatchLinksAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshShowJustWatchLinksThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.RefreshShowJustWatchLinksAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.RefreshShowJustWatchLinksAsync(new TraktShowIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.RefreshShowJustWatchLinksAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
