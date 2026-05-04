using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowLastEpisodeTests
    {
        private const string GetShowLastEpisodeUriPrefix = "shows";
        private const string GetShowLastEpisodeUriSuffix = "last_episode";

        private const string ShowID = "1390";
        private const string ShowSlug = "game-of-thrones";

        private const string GetShowLastEpisodeUri = GetShowLastEpisodeUriPrefix + "/" + ShowID + "/" + GetShowLastEpisodeUriSuffix;
        private const string GetShowLastEpisodeUriWithSlug = GetShowLastEpisodeUriPrefix + "/" + ShowSlug + "/" + GetShowLastEpisodeUriSuffix;

        [Theory]
        [InlineData(null, GetShowLastEpisodeUri)]
        [InlineData(TraktExtendedInfo.None, GetShowLastEpisodeUri)]
        [InlineData(TraktExtendedInfo.Full, GetShowLastEpisodeUri + "?extended=full")]
        public async Task TestGetShowLastEpisodeWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.TraktShowID, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowLastEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.None, GetShowLastEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.Full, GetShowLastEpisodeUriWithSlug + "?extended=full")]
        public async Task TestGetShowLastEpisodeWithSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowSlug, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowLastEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.None, GetShowLastEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.Full, GetShowLastEpisodeUriWithSlug + "?extended=full")]
        public async Task TestGetShowLastEpisodeWithIDs(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowIDs, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktEpisode> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Content!.Title.ShouldBe("Winter Is Coming");
        }
    }
}
