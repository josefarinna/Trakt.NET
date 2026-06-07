using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentRepliesTests
    {
        private readonly string GetCommentRepliesUri = $"comments/{CommentID}/replies";
        private const uint CommentID = 190U;
        private const uint CommentRepliesItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetCommentReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentRepliesUri, responseContent, 1, 1, 10, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?extended={ExtendedInfo.ToURI()}", responseContent, Page, 1, 10, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page={Page}", responseContent, Page, 1, 10, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?limit={Limit}", responseContent, 1, 1, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetCommentRepliesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentRepliesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=1&limit={Limit}",
                                                           responseContent, 1, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentRepliesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
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
        public async Task TestGetCommentRepliesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentRepliesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
