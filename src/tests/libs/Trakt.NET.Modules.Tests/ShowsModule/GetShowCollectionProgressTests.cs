using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowCollectionProgressTests
    {
        private const string GetShowCollectionProgressUriPrefix = "shows";
        private const string GetShowCollectionProgressSuffix = "progress/collection";

        private static readonly string GetShowCollectionProgressUri = $"{GetShowCollectionProgressUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowCollectionProgressSuffix}";
        private const string GetShowCollectionProgressUriWithSlug = $"{GetShowCollectionProgressUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowCollectionProgressSuffix}";

        [Theory]
        [InlineData(null, null, null, GetShowCollectionProgressUriWithSlug, "Shows\\showcollectionprogress.json")]
        [InlineData(true, null, null, $"{GetShowCollectionProgressUriWithSlug}?hidden=true", "Shows\\showcollectionprogress.json")]
        [InlineData(null, true, null, $"{GetShowCollectionProgressUriWithSlug}?specials=true", "Shows\\showcollectionprogress.json")]
        [InlineData(null, null, true, $"{GetShowCollectionProgressUriWithSlug}?count_specials=true", "Shows\\showcollectionprogress.json")]
        [InlineData(true, true, true, $"{GetShowCollectionProgressUriWithSlug}?hidden=true&specials=true&count_specials=true", "Shows\\showcollectionprogress.json")]
        public async Task TestGetShowCollectionProgress(bool? hidden, bool? specials, bool? countSpecials, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, hidden, specials, countSpecials, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUri, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktShowCollectionProgress> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktShowCollectionProgress progress = response.Content!;

            progress.Aired.ShouldBe(73U);
            progress.Completed.ShouldBe(0U);
            progress.LastCollectedAt.ShouldBeNull();

            progress.NextEpisode.ShouldNotBeNull();
            progress.NextEpisode.Title.ShouldBe("Winter Is Coming");
            progress.NextEpisode.Season.ShouldBe(1U);
            progress.NextEpisode.Number.ShouldBe(1U);
            progress.NextEpisode.IDs!.Trakt.ShouldBe(73640U);

            progress.Seasons.ShouldNotBeNull();
            progress.Seasons.Count.ShouldBeGreaterThan(0);
            progress.Seasons[0].Number.ShouldBe(1U);
            progress.Seasons[0].Aired.ShouldBe(10U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        public async Task TestGetShowCollectionProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowCollectionProgressAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowCollectionProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
