using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchedProgressTests
    {
        private const string GetShowWatchedProgressUriPrefix = "shows";
        private const string GetShowWatchedProgressUriSuffix = "progress/watched";
        private static readonly string GetShowWatchedProgressUri = $"{GetShowWatchedProgressUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowWatchedProgressUriSuffix}";
        private const string GetShowWatchedProgressUriWithSlug = $"{GetShowWatchedProgressUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowWatchedProgressUriSuffix}";

        [Theory]
        [InlineData(null, null, null, GetShowWatchedProgressUriWithSlug, "Shows\\showwatchedprogress.json")]
        [InlineData(true, null, null, $"{GetShowWatchedProgressUriWithSlug}?hidden=true", "Shows\\showwatchedprogress.json")]
        [InlineData(null, true, null, $"{GetShowWatchedProgressUriWithSlug}?specials=true", "Shows\\showwatchedprogress.json")]
        [InlineData(null, null, true, $"{GetShowWatchedProgressUriWithSlug}?count_specials=true", "Shows\\showwatchedprogress.json")]
        [InlineData(true, true, true, $"{GetShowWatchedProgressUriWithSlug}?hidden=true&specials=true&count_specials=true", "Shows\\showwatchedprogress.json")]
        public async Task TestGetShowWatchedProgress(bool? hidden, bool? specials, bool? countSpecials, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, hidden, specials, countSpecials, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUri, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktShowWatchedProgress> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktShowWatchedProgress progress = response.Content!;

            progress.Aired.ShouldBe(73U);
            progress.Completed.ShouldBe(73U);
            progress.LastWatchedAt.ShouldBe(DateTime.Parse("2019-05-20T11:45:00.000Z").ToUniversalTime());

            progress.LastEpisode.ShouldNotBeNull();
            progress.LastEpisode.Title.ShouldBe("The Iron Throne");
            progress.LastEpisode.Season.ShouldBe(8U);
            progress.LastEpisode.Number.ShouldBe(6U);
            progress.LastEpisode.IDs!.Trakt.ShouldBe(3465698U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowWatchedProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktShowWatchedProgress>>> act = () => client.Shows.GetShowWatchedProgressAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowWatchedProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
