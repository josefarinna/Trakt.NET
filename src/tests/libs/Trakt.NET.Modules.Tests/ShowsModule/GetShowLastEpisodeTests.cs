using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowLastEpisodeTests
    {
        private const string GetShowLastEpisodeUri = $"shows/{TestConstants.Shows.ShowID}/last_episode";
        private const string GetShowLastEpisodeUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/last_episode";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetShowLastEpisodeWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithIDAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowLastEpisodeUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.TraktShowID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowLastEpisodeWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUri, statusCode);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowLastEpisodeAsync(new TraktShowIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
