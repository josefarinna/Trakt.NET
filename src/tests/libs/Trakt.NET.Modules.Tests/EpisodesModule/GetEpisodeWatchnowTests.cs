using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeWatchnowTests
    {
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const string Country = "us";
        private const uint TraktEpisodeID = 73640U;
        private static readonly string EpisodeWatchnowUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/watchnow/{Country}";
        private static readonly string EpisodeWatchnowUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/watchnow/{Country}";

        private static readonly TraktEpisodeIDs EpisodeIDs = new()
        {
            Trakt = TraktEpisodeID
        };

        [Fact]
        public async Task TestGetEpisodeWatchnowWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(EpisodeWatchnowUri, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Episodes.GetEpisodeWatchnowAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey(Country).ShouldBeTrue();
            response.Content[Country].Subscription.ShouldNotBeNull();
            response.Content[Country].Subscription!.Count.ShouldBe(1);
            response.Content[Country].Subscription![0].Source.ShouldBe("netflix");
        }

        [Fact]
        public async Task TestGetEpisodeWatchnowWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(EpisodeWatchnowUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Episodes.GetEpisodeWatchnowAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeWatchnowWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(EpisodeWatchnowUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Episodes.GetEpisodeWatchnowAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeWatchnowThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(EpisodeWatchnowUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>>> act = () => client.Episodes.GetEpisodeWatchnowAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeWatchnowThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(EpisodeWatchnowUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>>> act = () => client.Episodes.GetEpisodeWatchnowAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeWatchnowAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeWatchnowAsync(string.Empty, SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.GetEpisodeWatchnowAsync("   ", SeasonNr, EpisodeNr, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.GetEpisodeWatchnowAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.GetEpisodeWatchnowAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
