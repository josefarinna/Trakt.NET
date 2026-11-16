using System.Net;

#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

using System.Text;

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
            responseData.ID.ShouldBe(3373536620UL);
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

        [Fact]
        public async Task TestCheckIntoEpisodeCreated()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Checkin\\checkinepisode_response.json");
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, _ => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
            });

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
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktEpisodeCheckinResponse responseData = response.Content!;
            responseData.ID.ShouldBe(3373536620UL);
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
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiCheckinException))]
        public async Task TestCheckIntoEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, statusCode);
            var episodeCheckin = new TraktEpisodeCheckin { Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 16U } } };

            Func<Task<TraktResponse<TraktEpisodeCheckinResponse>>> act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestCheckIntoEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, "{}");

            Func<Task<TraktResponse<TraktEpisodeCheckinResponse>>> act = () => client.Checkins.CheckIntoEpisodeAsync(null!);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var episodeCheckin = new TraktEpisodeCheckin { Episode = null! };
            act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin);
            await act.ShouldThrowAsync<ArgumentException>();

            episodeCheckin = new TraktEpisodeCheckin { Episode = new TraktEpisode { IDs = null! } };
            act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin);
            await act.ShouldThrowAsync<ArgumentException>();

            episodeCheckin = new TraktEpisodeCheckin { Episode = new TraktEpisode { IDs = new TraktEpisodeIDs() } };
            act = () => client.Checkins.CheckIntoEpisodeAsync(episodeCheckin);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
