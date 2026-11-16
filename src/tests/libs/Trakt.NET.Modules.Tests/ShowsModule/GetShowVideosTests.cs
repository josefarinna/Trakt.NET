using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowVideosTests
    {
        private const string GetShowVideosUri = $"shows/{TestConstants.Shows.ShowID}/videos";
        private const string GetShowVideosUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/videos";
        private const int ListItemCount = 2;

        [Fact]
        public async Task TestGetShowVideosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Shows.GetShowVideosAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowVideosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Shows.GetShowVideosAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowVideosAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
