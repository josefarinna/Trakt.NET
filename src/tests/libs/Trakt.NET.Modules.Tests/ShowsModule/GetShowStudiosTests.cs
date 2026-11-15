using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowStudiosTests
    {
        private const string GetShowStudiosUri = $"shows/{TestConstants.Shows.ShowID}/studios";
        private const string GetShowStudiosUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/studios";
        private const int ListItemCount = 2;

        [Fact]
        public async Task TestGetShowStudiosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUri, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowStudiosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowStudiosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowStudiosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUri, statusCode);

            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Shows.GetShowStudiosAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowStudiosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Shows.GetShowStudiosAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowStudiosAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
