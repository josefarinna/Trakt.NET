using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowNextEpisodeTests
    {
        private const string GetShowNextEpisodeUriPrefix = "shows";
        private const string GetShowNextEpisodeUriSuffix = "next_episode";

        private const string ShowID = "1390";
        private const string ShowSlug = "game-of-thrones";

        private const string GetShowNextEpisodeUri = GetShowNextEpisodeUriPrefix + "/" + ShowID + "/" + GetShowNextEpisodeUriSuffix;
        private const string GetShowNextEpisodeUriWithSlug = GetShowNextEpisodeUriPrefix + "/" + ShowSlug + "/" + GetShowNextEpisodeUriSuffix;

        [Theory]
        [InlineData(null, GetShowNextEpisodeUri)]
        [InlineData(TraktExtendedInfo.None, GetShowNextEpisodeUri)]
        [InlineData(TraktExtendedInfo.Full, GetShowNextEpisodeUri + "?extended=full")]
        public async Task TestGetShowNextEpisodeWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.ShowID, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowNextEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.None, GetShowNextEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.Full, GetShowNextEpisodeUriWithSlug + "?extended=full")]
        public async Task TestGetShowNextEpisodeWithSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.ShowSlug, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowNextEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.None, GetShowNextEpisodeUriWithSlug)]
        [InlineData(TraktExtendedInfo.Full, GetShowNextEpisodeUriWithSlug + "?extended=full")]
        public async Task TestGetShowNextEpisodeWithIDs(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.ShowIDs, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowNextEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowNextEpisodeUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowNextEpisodeAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowNextEpisodeWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowNextEpisodeUriWithSlug, "{}");

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowNextEpisodeAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
#pragma warning restore CS8625

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowNextEpisodeAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        private static void ValidateResponse(TraktResponse<TraktEpisode> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktEpisode episode = response.Content!;
            episode.Title.ShouldBe("Winter Is Coming");
            episode.Season.ShouldBe(1U);
            episode.Number.ShouldBe(1U);
            episode.IDs.ShouldNotBeNull();
            episode.IDs!.Trakt.ShouldBe(73640U);
            episode.NumberAbsolute.ShouldBe(1U);
            episode.Rating.ShouldBe(8.08208f);
        }
    }
}
