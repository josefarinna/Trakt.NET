using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowNextEpisodeTests
    {
        private const string GetShowNextEpisodeUri = $"shows/{TestConstants.Shows.ShowID}/next_episode";
        private const string GetShowNextEpisodeUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/next_episode";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetShowNextEpisodeUri)]
        [InlineData(ExtendedInfo, $"{GetShowNextEpisodeUri}?extended=full")]
        public async Task TestGetShowNextEpisodeWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.TraktShowID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowNextEpisodeWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowNextEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowNextEpisodeWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowNextEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowNextEpisodeWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowNextEpisodeUri, statusCode);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowNextEpisodeWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowNextEpisodeUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowNextEpisodeAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowNextEpisodeAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
