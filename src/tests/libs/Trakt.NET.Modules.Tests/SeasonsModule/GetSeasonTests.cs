using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonTests
    {
        private const string GetSeasonUri = "shows";
        private const uint SeasonNumber = 1U;
        private static readonly string GetSeasonUriWithSlug = $"{GetSeasonUri}/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNumber}/info";

        [Theory]
        [InlineData(null, $"{GetSeasonUri}/1390/seasons/1/info", "Seasons\\season_minimal.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetSeasonUri}/1390/seasons/1/info", "Seasons\\season_minimal.json")]
        [InlineData(TraktExtendedInfo.Images, $"{GetSeasonUri}/1390/seasons/1/info?extended=images", "Seasons\\season_minimal_images.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonUri}/1390/seasons/1/info?extended=full", "Seasons\\season_full.json")]
        [InlineData(TraktExtendedInfo.Episodes, $"{GetSeasonUri}/1390/seasons/1/info?extended=episodes", "Seasons\\season_full_episodes.json")]
        [InlineData(TraktExtendedInfo.Full | TraktExtendedInfo.Images, $"{GetSeasonUri}/1390/seasons/1/info?extended=full,images", "Seasons\\season_full_images.json")]
        [InlineData(TraktExtendedInfo.Episodes | TraktExtendedInfo.Images, $"{GetSeasonUri}/1390/seasons/1/info?extended=episodes,images", "Seasons\\season_full_episodes_images.json")]
        public async Task TestGetSeasonWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktSeason> response =
                await client.Seasons.GetSeasonAsync(TestConstants.Shows.ShowID, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktSeason season = response.Content!;
            season.Number.ShouldBe(SeasonNumber);
            season.IDs!.Trakt.ShouldBe(3963U);
        }

        [Theory]
        [InlineData(null, $"{GetSeasonUri}/game-of-thrones/seasons/1/info", "Seasons\\season_minimal.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetSeasonUri}/game-of-thrones/seasons/1/info", "Seasons\\season_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonUri}/game-of-thrones/seasons/1/info?extended=full", "Seasons\\season_full.json")]
        public async Task TestGetSeasonWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktSeason> response =
                await client.Seasons.GetSeasonAsync(TestConstants.Shows.ShowSlug, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktSeason season = response.Content!;
            season.Number.ShouldBe(SeasonNumber);
            season.IDs!.Trakt.ShouldBe(3963U);
        }

        [Theory]
        [InlineData(null, $"{GetSeasonUri}/game-of-thrones/seasons/1/info", "Seasons\\season_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonUri}/game-of-thrones/seasons/1/info?extended=full", "Seasons\\season_full.json")]
        public async Task TestGetSeasonWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktSeason> response =
                await client.Seasons.GetSeasonAsync(TestConstants.Shows.ShowIDs, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktSeason season = response.Content!;
            season.Number.ShouldBe(SeasonNumber);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetSeasonWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonUri}/1390/seasons/{SeasonNumber}/info", statusCode);

            try
            {
                await client.Seasons.GetSeasonAsync(TestConstants.Shows.ShowID, SeasonNumber,
                                                   cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetSeasonWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\season_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktSeason>>> act =
                () => client.Seasons.GetSeasonAsync(default(TraktShowIDs), SeasonNumber);
#pragma warning restore CS8625

            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Seasons.GetSeasonAsync(showIDs, SeasonNumber);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
