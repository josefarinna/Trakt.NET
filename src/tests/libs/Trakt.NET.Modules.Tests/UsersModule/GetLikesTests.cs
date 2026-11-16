using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetLikesTests
    {
        private const string GetLikesUri = $"users/{Username}/likes";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint LikesItemCount = 2U;
        private const uint LikesLimit = 4U;
        private const TraktUserLikeType LikeType = TraktUserLikeType.Comment;

        [Theory]
        [InlineData(null, null, null, GetLikesUri)]
        [InlineData(LikeType, null, null, $"{GetLikesUri}/comments")]
        [InlineData(null, Page, null, $"{GetLikesUri}?page=2")]
        [InlineData(null, null, LikesLimit, $"{GetLikesUri}?limit=4")]
        [InlineData(LikeType, Page, LikesLimit, $"{GetLikesUri}/comments?page=2&limit=4")]
        public async Task TestGetLikes(TraktUserLikeType? likeType, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, likeType, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetLikesUri, responseContent, 1, 1, 10, LikesItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/likes", responseContent, 1, 1, 10, LikesItemCount);
            
            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page=2&limit={LikesLimit}",
                responseContent, 2, 5, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, 2, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetLikesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page=2&limit={LikesLimit}",
                responseContent, 2, 2, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, 2, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetLikesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page=1&limit={LikesLimit}",
                responseContent, 1, 2, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, 1, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetLikesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page=1&limit={LikesLimit}",
                responseContent, 1, 1, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, 1, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetLikesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page=2&limit={LikesLimit}",
                responseContent, 2, 2, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, 2, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetLikesUri}/{LikeType.ToURI()}?page=1&limit={LikesLimit}",
                responseContent, 1, 2, LikesLimit, LikesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetLikesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page=1&limit={LikesLimit}",
                responseContent, 1, 2, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, 1, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetLikesUri}/{LikeType.ToURI()}?page=2&limit={LikesLimit}",
                responseContent, 2, 2, LikesLimit, LikesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetLikesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserLikeItem>>> act = () => client.Users.GetLikesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
