using System.Net;

namespace TraktNET.CheckinModule
{
    public sealed class CheckIntoEpisodeTests
    {
        private const string CheckinUri = "checkin";

        [Fact]
        public async Task TestCheckIntoEpisode()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Checkin\\checkinepisode_response.json");
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, responseContent);

            var episodeCheckin = new TraktEpisodeCheckin
            {
                Episode = new TraktEpisode
                {
                    IDs = new TraktEpisodeIDs { Trakt = 16U }
                },
                Show = new TraktShow
                {
                    Title = "Breaking Bad",
                    Year = 2008U,
                    IDs = new TraktShowIDs { Trakt = 1U, TVDB = 81189U }
                },
                Message = "I'm the one who knocks!",
                Sharing = new TraktConnections { Twitter = true, Tumblr = false }
            };

            TraktResponse<TraktEpisodeCheckinResponse> response = await client.Checkins.CheckIntoEpisodeAsync(episodeCheckin, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktEpisodeCheckinResponse responseData = response.Content!;
            responseData.Id.ShouldBe(3373536620UL);
            responseData.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-06T01:11:37.000Z"));

            responseData.Show.ShouldNotBeNull();
            responseData.Show!.Title.ShouldBe("Breaking Bad");
            responseData.Show!.IDs!.Trakt.ShouldBe(1U);

            responseData.Episode.ShouldNotBeNull();
            responseData.Episode!.Season.ShouldBe(1U);
            responseData.Episode!.Number.ShouldBe(1U);

            responseData.Sharing.ShouldNotBeNull();
            responseData.Sharing!.Twitter.ShouldBe(true);
            responseData.Sharing!.Tumblr.ShouldBe(false);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiCheckinException))]
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
        public async Task TestCheckIntoEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, statusCode);
            var episodeCheckin = new TraktEpisodeCheckin { Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 16U } } };

            try
            {
                await client.Checkins.CheckIntoEpisodeAsync(episodeCheckin, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestCheckIntoEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, "{}");

            Func<Task<TraktResponse<TraktEpisodeCheckinResponse>>> act = () => client.Checkins.CheckIntoEpisodeAsync(null!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var episodeCheckin = new TraktEpisodeCheckin { Episode = null! };
            act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin);
            await act.ShouldThrowAsync<ArgumentException>();

            episodeCheckin = new TraktEpisodeCheckin { Episode = new TraktEpisode { IDs = null! } };
            act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin);
            await act.ShouldThrowAsync<ArgumentException>();

            episodeCheckin = new TraktEpisodeCheckin { Episode = new TraktEpisode { IDs = new TraktEpisodeIDs() } };
            act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
