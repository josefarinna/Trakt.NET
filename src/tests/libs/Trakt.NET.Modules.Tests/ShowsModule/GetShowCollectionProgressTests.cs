using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowCollectionProgressTests
    {
        private const string GetShowCollectionProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/collection";
        private const string GetShowCollectionProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/collection";

        [Fact]
        public async Task TestGetShowCollectionProgressWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithHidden()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUri}?hidden=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, hidden: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUri}?specials=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, specials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithCountSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUri}?count_specials=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, countSpecials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithLastActivity()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUri}?last_activity=collected", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, lastActivity: TraktLastActivity.Collected, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUri}?last_activity=aired", responseContent);

            response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, lastActivity: TraktLastActivity.Aired, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUri}?hidden=true&specials=true&count_specials=true&last_activity=collected", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, hidden: true, specials: true, countSpecials: true, lastActivity: TraktLastActivity.Collected,
                cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUri, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowCollectionProgressWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUri, statusCode);

            Func<Task<TraktResponse<TraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowCollectionProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
