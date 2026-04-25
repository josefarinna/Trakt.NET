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

        [Fact]
        public async Task TestGetLikes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetLikesUri, responseContent, 1, 1, 10, LikesItemCount);
            
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
        public async Task TestGetLikesWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}", responseContent, 1, 1, 10, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetLikesWithTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page={Page}", responseContent, Page, 1, 10, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesWithTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?limit={LikesLimit}", responseContent, 1, 1, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, null, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}?page={Page}", responseContent, Page, 1, 10, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}?limit={LikesLimit}", responseContent, 1, 1, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, null, null, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}?page={Page}&limit={LikesLimit}", responseContent, Page, 1, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, null, Page, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetLikesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetLikesUri}/{LikeType.ToURI()}?page={Page}&limit={LikesLimit}",
                responseContent, Page, 1, LikesLimit, LikesItemCount);

            TraktPagedResponse<TraktUserLikeItem> response = await client.Users.GetLikesAsync(Username, LikeType, Page, LikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)LikesItemCount);
            response.ItemCount.ShouldBe(LikesItemCount);
            response.Limit.ShouldBe(LikesLimit);
            response.Page.ShouldBe(Page);
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetLikesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\likes.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserLikeItem>>> act = () => client.Users.GetLikesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
