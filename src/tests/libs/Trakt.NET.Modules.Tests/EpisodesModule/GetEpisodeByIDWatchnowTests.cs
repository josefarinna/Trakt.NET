using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeByIDWatchnowTests
    {
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const string Country = "us";
        private const uint TraktEpisodeID = 73640U;
        private static readonly string EpisodeByIDWatchnowUri = $"episodes/{TraktEpisodeID}/watchnow/{Country}";

        private static readonly TraktEpisodeIDs EpisodeIDs = new()
        {
            Trakt = TraktEpisodeID
        };

        [Fact]
        public async Task TestGetEpisodeByIDWatchnowWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(EpisodeByIDWatchnowUri, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Episodes.GetEpisodeByIDWatchnowAsync(TraktEpisodeID, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("us").ShouldBeTrue();
            response.Content["us"].Subscription.ShouldNotBeNull();
            response.Content["us"].Subscription!.Count.ShouldBe(1);
            response.Content["us"].Subscription![0].Source.ShouldBe("netflix");
        }

        [Fact]
        public async Task TestGetEpisodeByIDWatchnowWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(EpisodeByIDWatchnowUri, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Episodes.GetEpisodeByIDWatchnowAsync(EpisodeIDs, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeByIDWatchnowThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(EpisodeByIDWatchnowUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>>> act = () => client.Episodes.GetEpisodeByIDWatchnowAsync(TraktEpisodeID, Country, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeByIDWatchnowThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(EpisodeByIDWatchnowUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>>> act = () => client.Episodes.GetEpisodeByIDWatchnowAsync(default(TraktEpisodeIDs)!, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeByIDWatchnowAsync(new TraktEpisodeIDs(), Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeByIDWatchnowAsync(string.Empty, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.GetEpisodeByIDWatchnowAsync("   ", Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.GetEpisodeByIDWatchnowAsync(TraktEpisodeID, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.GetEpisodeByIDWatchnowAsync(TraktEpisodeID, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
