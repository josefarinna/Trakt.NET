using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonTests
    {
        private readonly string GetSeasonUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/info";
        private const uint SeasonNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowID}/seasons/1/info")]
        [InlineData(ExtendedInfo, $"shows/{TestConstants.Shows.ShowID}/seasons/1/info?extended=full")]
        public async Task TestGetSeasonWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\season_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktSeason> response = await client.Seasons.GetSeasonAsync(TestConstants.Shows.TraktShowID, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            TraktSeason responseValue = response.Content!;
            responseValue.Number.ShouldBe(SeasonNr);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(3963U);
        }

        [Fact]
        public async Task TestGetSeasonWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\season_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/info", responseContent);
            
            TraktResponse<TraktSeason> response = await client.Seasons.GetSeasonAsync(TestConstants.Shows.ShowSlug, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\season_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/info", responseContent);
            
            TraktResponse<TraktSeason> response = await client.Seasons.GetSeasonAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\season_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/info", responseContent);
            
            TraktResponse<TraktSeason> response = await client.Seasons.GetSeasonAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonUri, statusCode);

            Func<Task<TraktResponse<TraktSeason>>> act = () => client.Seasons.GetSeasonAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSeason>>> act =
                () => client.Seasons.GetSeasonAsync(default(TraktShowIDs)!, SeasonNr);

            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonAsync(default(TraktShow)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonAsync(new TraktShowIDs(), SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonAsync(0, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
