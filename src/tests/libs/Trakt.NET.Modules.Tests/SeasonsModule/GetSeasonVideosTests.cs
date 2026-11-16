using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonVideosVideosTests
    {
        private readonly string GetSeasonVideosUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/videos";
        private const uint SeasonNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowID}/seasons/1/videos")]
        [InlineData(ExtendedInfo, $"shows/{TestConstants.Shows.ShowID}/seasons/1/videos?extended=full")]
        public async Task TestGetSeasonVideosWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.TraktShowID, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetSeasonVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowSlug, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetSeasonVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetSeasonVideosWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Seasons.GetSeasonVideosAsync(default(TraktShowIDs)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonVideosAsync(default(TraktShow)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonVideosAsync(new TraktShowIDs(), SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonVideosAsync(0, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
