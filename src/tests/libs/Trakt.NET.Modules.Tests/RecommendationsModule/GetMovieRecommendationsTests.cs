using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class GetMovieRecommendationsTests
    {
        private const string GetMovieRecommendationsUri = "recommendations/movies";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint MovieRecommendationsCount = 3U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, GetMovieRecommendationsUri)]
        [InlineData(null, null, null, Page, null, $"{GetMovieRecommendationsUri}?page=2")]
        [InlineData(null, null, null, null, Limit, $"{GetMovieRecommendationsUri}?limit=4")]
        [InlineData(true, null, null, null, null, $"{GetMovieRecommendationsUri}?ignore_collected=true")]
        [InlineData(null, true, null, null, null, $"{GetMovieRecommendationsUri}?ignore_watchlisted=true")]
        [InlineData(null, null, ExtendedInfo, null, null, $"{GetMovieRecommendationsUri}?extended=full")]
        [InlineData(true, true, ExtendedInfo, Page, Limit, $"{GetMovieRecommendationsUri}" + $"?ignore_collected=true&ignore_watchlisted=true&extended=full&page=2&limit=4")]
        public async Task TestGetMovieRecommendations(bool? ignoreCollected, bool? ignoreWatchlisted, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MovieRecommendationsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\recommendedmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MovieRecommendationsCount);

            TraktPagedResponse<TraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetMovieRecommendationsUri}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MovieRecommendationsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MovieRecommendationsCount);
            response.ItemCount.ShouldBe(MovieRecommendationsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMovieRecommendationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMovieRecommendationsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecommendedMovie>>> act = () => client.Recommendations.GetMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
