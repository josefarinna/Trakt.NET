using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchedProgressTests
    {
        private const string GetShowWatchedProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/watched";
        private const string GetShowWatchedProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/watched";

        [Fact]
        public async Task TestGetShowWatchedProgressWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, null, null, GetShowWatchedProgressUri)]
        [InlineData(true, null, null, $"{GetShowWatchedProgressUri}?hidden=true")]
        [InlineData(null, true, null, $"{GetShowWatchedProgressUri}?specials=true")]
        [InlineData(null, null, true, $"{GetShowWatchedProgressUri}?count_specials=true")]
        [InlineData(true, true, true, $"{GetShowWatchedProgressUri}?hidden=true&specials=true&count_specials=true")]
        public async Task TestGetShowWatchedProgressWithID(bool? hidden, bool? specials, bool? countSpecials, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(TestConstants.Shows.TraktShowID, hidden, specials, countSpecials, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowWatchedProgressWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUri, statusCode);

            Func<Task<TraktResponse<TraktShowWatchedProgress>>> act = () => client.Shows.GetShowWatchedProgressAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShowWatchedProgress>>> act = () => client.Shows.GetShowWatchedProgressAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowWatchedProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
