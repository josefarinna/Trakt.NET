using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodePeopleTests
    {
        private readonly string GetEpisodePeopleUri = $"shows/{TestConstants.Shows.TraktShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, "shows/1390/seasons/1/episodes/1/people")]
        [InlineData(ExtendedInfo, "shows/1390/seasons/1/episodes/1/people?extended=full")]
        public async Task TestGetEpisodePeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            TraktCastAndCrew responseValue = response.Content;
            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(3);
            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production.Count.ShouldBe(2);
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art.Count.ShouldBe(1);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew.Count.ShouldBe(1);
            responseValue.Crew.CostumeAndMakeUp.ShouldBeNull();
            responseValue.Crew.Directing.ShouldBeNull();
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing.Count.ShouldBe(3);
            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound.Count.ShouldBe(1);
            responseValue.Crew.Camera.ShouldBeNull();
            responseValue.Crew.Lighting.ShouldBeNull();
            responseValue.Crew.VisualEffects.ShouldBeNull();
            responseValue.Crew.Editing.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodePeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodePeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodePeopleUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(default(TraktShow)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(0, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
