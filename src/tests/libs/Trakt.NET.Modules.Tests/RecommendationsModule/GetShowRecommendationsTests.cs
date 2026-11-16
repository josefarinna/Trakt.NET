using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class GetShowRecommendationsTests
    {
        private const string GetShowRecommendationsUri = "recommendations/shows";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ShowRecommendationsCount = 3U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, GetShowRecommendationsUri)]
        [InlineData(null, null, null, Page, null, $"{GetShowRecommendationsUri}?page=2")]
        [InlineData(null, null, null, null, Limit, $"{GetShowRecommendationsUri}?limit=4")]
        [InlineData(true, null, null, null, null, $"{GetShowRecommendationsUri}?ignore_collected=true")]
        [InlineData(null, true, null, null, null, $"{GetShowRecommendationsUri}?ignore_watchlisted=true")]
        [InlineData(null, null, ExtendedInfo, null, null, $"{GetShowRecommendationsUri}?extended=full")]
        [InlineData(true, true, ExtendedInfo, Page, Limit, $"{GetShowRecommendationsUri}" + $"?ignore_collected=true&ignore_watchlisted=true&extended=full&page=2&limit=4")]
        public async Task TestGetShowRecommendations(bool? ignoreCollected, bool? ignoreWatchlisted, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ShowRecommendationsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetShowRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ShowRecommendationsCount);

            TraktPagedResponse<TraktRecommendedShow> response = await client.Recommendations.GetShowRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetShowRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ShowRecommendationsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ShowRecommendationsCount);
            response.ItemCount.ShouldBe(ShowRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetShowRecommendationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetShowRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecommendedShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
