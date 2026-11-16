using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetAnticipatedRecommendationsTests
    {
        private const string GetAnticipatedRecommendationsUri = "shows/recommendations/anticipated";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemsCount = 2U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, GetAnticipatedRecommendationsUri)]
        [InlineData(null, Page, null, $"{GetAnticipatedRecommendationsUri}?page=2")]
        [InlineData(null, null, Limit, $"{GetAnticipatedRecommendationsUri}?limit=4")]
        [InlineData(null, Page, Limit, $"{GetAnticipatedRecommendationsUri}?page=2&limit=4")]
        [InlineData(ExtendedInfo, null, null, $"{GetAnticipatedRecommendationsUri}?extended=full")]
        public async Task TestGetAnticipatedRecommendations(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Shows.GetAnticipatedRecommendationsAsync(extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
            TraktAnticipatedShowRecommendation item = response.Content[0];
            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Euphoria");
            item.Score.ShouldBe(0.4f);
            item.Released.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAnticipatedRecommendationsUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Shows.GetAnticipatedShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Shows.GetAnticipatedRecommendationsAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetAnticipatedRecommendationsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetAnticipatedRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetAnticipatedRecommendationsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Shows.GetAnticipatedRecommendationsAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetAnticipatedRecommendationsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetAnticipatedRecommendationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAnticipatedRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktAnticipatedShowRecommendation>>> act = () => client.Shows.GetAnticipatedRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
