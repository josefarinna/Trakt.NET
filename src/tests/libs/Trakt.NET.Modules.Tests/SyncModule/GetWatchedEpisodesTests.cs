using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchedEpisodesTests
    {
        private const string GetWatchedEpisodesUri = "sync/watched/episodes";
        private const uint Page = 1U;
        private const uint Limit = 10U;
        private const uint EpisodesCount = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, $"{GetWatchedEpisodesUri}?page=1&limit=10")]
        [InlineData(ExtendedInfo, $"{GetWatchedEpisodesUri}?extended=full&page=1&limit=10")]
        public async Task TestGetWatchedEpisodes(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, Page, 1, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response = await client.Sync.GetWatchedEpisodesAsync(extendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Sync.GetWatchedEpisodesAsync(ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Sync.GetWatchedEpisodesAsync(ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Sync.GetWatchedEpisodesAsync(ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Sync.GetWatchedEpisodesAsync(ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Sync.GetWatchedEpisodesAsync(ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetOAuthClient(client,
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, EpisodesCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Sync.GetWatchedEpisodesAsync(ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetOAuthClient(client,
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, EpisodesCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetWatchedEpisodesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedEpisodesUri}?page={Page}&limit={Limit}", statusCode);

            Func<Task<TraktPagedResponse<TraktWatchedEpisode>>> act = () => client.Sync.GetWatchedEpisodesAsync(null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedEpisodesUri}?page={Page}&limit={Limit}", HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktWatchedEpisode>>> act = () => client.Sync.GetWatchedEpisodesAsync(null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetWatchedEpisodesAsync(null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
