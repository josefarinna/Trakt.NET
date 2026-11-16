using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetStreamingShowsTests
    {
        private const string GetStreamingShowsUri = "shows/streaming";

        [Theory]
        [InlineData(null, null, null, null, GetStreamingShowsUri, "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktTimePeriod.Daily, null, null, null, $"{GetStreamingShowsUri}/daily", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetStreamingShowsUri}?extended=full", "Shows\\mostanticipatedshows.json")]
        [InlineData(null, null, 4U, null, $"{GetStreamingShowsUri}?page=4", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetStreamingShowsUri}?limit=20", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 4U, 20U, $"{GetStreamingShowsUri}/daily?extended=full&page=4&limit=20", "Shows\\mostanticipatedshows.json")]
        public async Task TestGetStreamingShows(TraktTimePeriod? timePeriod, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(timePeriod, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetStreamingShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetStreamingShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetStreamingShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetStreamingShowsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktStreamingShow>>> act = () => client.Shows.GetStreamingShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
