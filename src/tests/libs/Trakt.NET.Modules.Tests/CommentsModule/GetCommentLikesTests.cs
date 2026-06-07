using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentLikesTests
    {
        private readonly string GetCommentLikesUri = $"comments/{CommentID}/likes";
        private const uint CommentID = 190U;
        private const uint ItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetCommentLikes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentLikesUri, responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page={Page}", responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                                                           responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentLikesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentLikesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentLikesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentLikesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentLikesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetCommentLikesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentLikesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCommentLikesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
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
        public async Task TestGetCommentLikesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
