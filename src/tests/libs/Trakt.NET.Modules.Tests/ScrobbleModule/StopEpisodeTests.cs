using System.Net;

namespace TraktNET.ScrobbleModule
{
    public sealed class StopEpisodeTests
    {
        private readonly string ScrobbleStopUri = "scrobble/stop";
        private const float StopProgress = 85.0f;

        [Fact]
        public async Task TestStopEpisode()
        {
            var content = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 }, Season = 1 },
                Progress = StopProgress
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Scrobbles\\episodestopscrobbleresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStopUri, responseContent, null, null, null, null);
            TraktResponse<TraktEpisodeScrobblePostResponse> response = await client.Scrobble.StopEpisodeAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktEpisodeScrobblePostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(3373536623U);
            responseValue.Action.ShouldBe(TraktScrobbleActionType.Stop);
            responseValue.Progress.ShouldBe(StopProgress);
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
        public async Task TestStopEpisodeThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStopUri, statusCode);

            var content = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } },
                Progress = StopProgress
            };

            Func<Task<TraktResponse<TraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(content, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestStopEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStopUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(default!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktEpisodeScrobblePost { Progress = StopProgress };
            act = () => client.Scrobble.StopEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Episode = new TraktEpisode();
            act = () => client.Scrobble.StopEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Episode.IDs = new TraktEpisodeIDs();
            act = () => client.Scrobble.StopEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
