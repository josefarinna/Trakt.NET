using System.Net;

namespace TraktNET.ScrobbleModule
{
    public sealed class PauseEpisodeTests
    {
        private readonly string ScrobblePauseUri = "scrobble/pause";
        private const float PauseProgress = 75.0f;

        [Fact]
        public async Task TestPauseEpisode()
        {
            var content = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 }, Season = 1 },
                Progress = PauseProgress
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Scrobbles\\episodepausescrobbleresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobblePauseUri, responseContent, null, null, null, null);
            TraktResponse<TraktEpisodeScrobblePostResponse> response = await client.Scrobble.PauseEpisodeAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktEpisodeScrobblePostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(0U);
            responseValue.Action.ShouldBe(TraktScrobbleActionType.Pause);
            responseValue.Progress.ShouldBe(PauseProgress);
            responseValue.Sharing.ShouldNotBeNull();
            responseValue.Sharing.Twitter.ShouldBe(true);
            responseValue.Sharing.Tumblr.ShouldBe(false);
            responseValue.Episode.ShouldNotBeNull();
            responseValue.Episode.Season.ShouldBe(1U);
            responseValue.Episode.Number.ShouldBe(1U);
            responseValue.Episode.Title.ShouldBe("Pilot");
            responseValue.Episode.IDs.ShouldNotBeNull();
            responseValue.Episode.IDs!.Trakt.ShouldBe(16U);
            responseValue.Episode.IDs!.TVDB.ShouldBe(349232U);
            responseValue.Episode.IDs!.IMDB.ShouldBe("tt0959621");
            responseValue.Episode.IDs!.TMDB.ShouldBe(62085U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestPauseEpisodeThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobblePauseUri, statusCode);

            var content = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } },
                Progress = PauseProgress
            };

            Func<Task<TraktResponse<TraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.PauseEpisodeAsync(content, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestPauseEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobblePauseUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.PauseEpisodeAsync(default!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktEpisodeScrobblePost { Progress = PauseProgress };
            act = () => client.Scrobble.PauseEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Episode = new TraktEpisode();
            act = () => client.Scrobble.PauseEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Episode.IDs = new TraktEpisodeIDs();
            act = () => client.Scrobble.PauseEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
