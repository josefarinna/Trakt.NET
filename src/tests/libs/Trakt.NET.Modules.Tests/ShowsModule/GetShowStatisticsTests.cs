using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowStatisticsTests
    {
        private const string GetShowStatisticsUri = $"shows/{TestConstants.Shows.ShowID}/stats";
        private const string GetShowStatisticsUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/stats";

        [Fact]
        public async Task TestGetShowStatisticsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUri, responseContent);

            TraktResponse<TraktShowStatistics> response = await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowStatisticsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktShowStatistics> response = await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowStatisticsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktShowStatistics> response = await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUri, statusCode);

            Func<Task<TraktResponse<TraktShowStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowStatisticsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShowStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowStatisticsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
