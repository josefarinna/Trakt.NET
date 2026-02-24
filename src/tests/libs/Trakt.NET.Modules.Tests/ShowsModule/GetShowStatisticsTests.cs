using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowStatisticsTests
    {
        private const string GetShowStatisticsUriPrefix = "shows";
        private const string GetShowStatisticsUriSuffix = "stats";
        private static readonly string GetShowStatisticsUri = $"{GetShowStatisticsUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowStatisticsUriSuffix}";
        private static readonly string GetShowStatisticsUriWithSlug = $"{GetShowStatisticsUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowStatisticsUriSuffix}";

        [Fact]
        public async Task TestGetShowStatisticsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUri, responseContent);

            TraktResponse<TraktShowStatistics> response = await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowStatisticsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktShowStatistics> response = await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowStatisticsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktShowStatistics> response = await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktShowStatistics> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktShowStatistics showStatistics = response.Content!;

            showStatistics.Watchers.ShouldBe(343626U);
            showStatistics.Plays.ShouldBe(26909587U);
            showStatistics.Collectors.ShouldBe(1778445U);
            showStatistics.CollectedEpisodes.ShouldBe(1853440U);
            showStatistics.Comments.ShouldBe(449U);
            showStatistics.Lists.ShouldBe(368247U);
            showStatistics.Votes.ShouldBe(145026U);
            showStatistics.Favorited.ShouldBe(13892U);
            showStatistics.Recommended.ShouldBe(13892U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUri, statusCode);

            try
            {
                await client.Shows.GetShowStatisticsAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowStatisticsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStatisticsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktShowStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowStatisticsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
