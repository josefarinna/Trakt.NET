using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetAllSeasonTests
    {
        private const string GetSeasonUri = "shows";
        private static readonly string GetAllSeasonsUriWithSlug = $"{GetSeasonUri}/{TestConstants.Shows.ShowSlug}/seasons";

        [Theory]
        [InlineData(null, "shows/1390/seasons", "Seasons\\allseasons.json")]
        [InlineData(TraktExtendedInfo.None, "shows/1390/seasons", "Seasons\\allseasons.json")]
        [InlineData(TraktExtendedInfo.Episodes, "shows/1390/seasons?extended=episodes", "Seasons\\allseasons.json")]
        [InlineData(TraktExtendedInfo.Full, "shows/1390/seasons?extended=full", "Seasons\\allseasons.json")]
        public async Task TestGetSeasonWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktSeason> response =
                await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowID, extendedInfo, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            var seasons = response.Content!.ToList();
            seasons.Count.ShouldBe(8);

            seasons[0].Number.ShouldBe(1U);
            seasons[0].Title.ShouldBe("Season 1");
            seasons[0].IDs!.Trakt.ShouldBe(3963U);
        }

        [Theory]
        [InlineData(null, "shows/game-of-thrones/seasons", "Seasons\\allseasons.json")]
        [InlineData(TraktExtendedInfo.None, "shows/game-of-thrones/seasons", "Seasons\\allseasons.json")]
        [InlineData(TraktExtendedInfo.Episodes, "shows/game-of-thrones/seasons?extended=episodes", "Seasons\\allseasons.json")]
        public async Task TestGetSeasonWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktSeason> response =
                await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowSlug, extendedInfo, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            var seasons = response.Content!.ToList();
            seasons.Count.ShouldBe(8);
            seasons[4].Number.ShouldBe(5U);
            seasons[4].Title.ShouldBe("Season 5");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetSeasonWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"shows/1390/seasons", statusCode);

            try
            {
                await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);
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
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");
            TraktClient client = ModuleTestUtility.GetClient(GetAllSeasonsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktSeason>>> act =
                () => client.Seasons.GetAllSeasonsAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625

            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Seasons.GetAllSeasonsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
