using System.Net;

namespace TraktNET.ScrobbleModule
{
    public sealed class StartEpisodeTests
    {
        private readonly string ScrobbleStartUri = "scrobble/start";
        private const float StartProgress = 10.0f;

        [Fact]
        public async Task TestStartEpisode()
        {
            var content = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 }, Season = 1 },
                Progress = StartProgress
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Scrobbles\\episodestartscrobbleresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStartUri, responseContent, null, null, null, null);
            TraktResponse<TraktEpisodeScrobblePostResponse> response = await client.Scrobble.StartEpisodeAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktEpisodeScrobblePostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(0U);
            responseValue.Action.ShouldBe(TraktScrobbleActionType.Start);
            responseValue.Progress.ShouldBe(StartProgress);
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
        public async Task TestStartEpisodeThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStartUri, statusCode);

            var content = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 }, Season = 1 },
                Progress = StartProgress
            };

            Func<Task<TraktResponse<TraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeAsync(content, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestStartEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStartUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeAsync(default, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var content = new TraktEpisodeScrobblePost { Progress = StartProgress };
            act = () => client.Scrobble.StartEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Episode = new TraktEpisode();
            act = () => client.Scrobble.StartEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Episode.IDs = new TraktEpisodeIDs();
            act = () => client.Scrobble.StartEpisodeAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
