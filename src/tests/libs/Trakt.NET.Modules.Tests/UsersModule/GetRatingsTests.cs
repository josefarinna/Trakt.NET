using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetRatingsTests
    {
        private const string GetRatingsUri = $"users/{Username}/ratings";
        private const string Username = "sean";
        private const uint RatingsItemCount = 5U;
        private const uint Page = 2;
        private const uint Limit = 4;
        private const TraktRatingsItemType RatingsItemType = TraktRatingsItemType.Movie;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, GetRatingsUri)]
        [InlineData(RatingsItemType, null, null, null, null, $"{GetRatingsUri}/movies")]
        [InlineData(RatingsItemType, new uint[] { 1 }, null, null, null, $"{GetRatingsUri}/movies/1")]
        [InlineData(RatingsItemType, new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, null, null, null, $"{GetRatingsUri}/movies/1,2,3,4,5,6,7,8,9,10")]
        [InlineData(RatingsItemType, new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, null, null, null, $"{GetRatingsUri}/movies")]
        [InlineData(RatingsItemType, new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, null, null, null, $"{GetRatingsUri}/movies")]
        [InlineData(RatingsItemType, new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 }, null, null, null, $"{GetRatingsUri}/movies")]
        [InlineData(RatingsItemType, new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null, null, null, $"{GetRatingsUri}/movies")]
        [InlineData(null, new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null, null, null, GetRatingsUri)]
        [InlineData(null, null, ExtendedInfo, null, null, $"{GetRatingsUri}?extended=full")]
        [InlineData(null, null, null, Page, null, $"{GetRatingsUri}?page=2")]
        [InlineData(null, null, null, null, Limit, $"{GetRatingsUri}?limit=4")]
        [InlineData(RatingsItemType, new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, ExtendedInfo, Page, Limit, $"{GetRatingsUri}/movies/1,2,3,4,5,6,7,8,9,10?extended=full&page=2&limit=4")]
        public async Task TestGetRatings(TraktRatingsItemType? ratingsItemType, uint[]? ratingsFilter, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response = await client.Users.GetRatingsAsync(Username, ratingsItemType, ratingsFilter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetRatingsUri, responseContent, 1, 1, 10, RatingsItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktRatingsItem> response = await client.Users.GetRatingsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/ratings", responseContent, 1, 1, 10, RatingsItemCount);
            
            TraktPagedResponse<TraktRatingsItem> response = await client.Users.GetRatingsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsPagingHasPreviousPageAndHasNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingOnlyHasPreviousPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetRatingsPagingOnlyHasNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingNotHasPreviousPageOrHasNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetRatingsPagingGetPreviousPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, RatingsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingGetNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, RatingsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetRatingsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRatingsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        private static string BuildRatingsFilterString(uint[] ratings) => string.Join(",", ratings);
    }
}
