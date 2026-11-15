using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeRatingsTests
    {
        private readonly string GetEpisodeRatingsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/ratings";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/ratings")]
        [InlineData(TraktExtendedInfo.None, $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/ratings")]
        [InlineData(TraktExtendedInfo.All, $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/ratings?extended=all")]
        public async Task TestGetEpisodeRatingsWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktRating responseValue = response.Content;

            responseValue.Rating.ShouldBe(8.54044f);
            responseValue.Votes.ShouldBe(3919U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            responseValue.Distribution.ShouldNotBeNull();
            responseValue.Distribution.Count.ShouldBe(10);
            responseValue.Distribution.ShouldBeEquivalentTo(distribution);
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/ratings")]
        public async Task TestGetEpisodeRatingsWithSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/ratings")]
        public async Task TestGetEpisodeRatingsWithIDs(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/ratings")]
        public async Task TestGetEpisodeRatingsWithShow(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(show, SeasonNr, EpisodeNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, statusCode);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeRatingsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(default(TraktShow)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(0, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
