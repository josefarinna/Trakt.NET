using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetCommentsTests
    {
        private const string GetCommentsUri = $"users/{Username}/comments";
        private const string Username = "sean";
        private const uint CommentsItemCount = 5U;
        private const uint Page = 2U;
        private const uint CommentsLimit = 6U;
        private const TraktCommentType CommentType = TraktCommentType.Shout;
        private const TraktCommentObjectType ObjectType = TraktCommentObjectType.Episode;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, GetCommentsUri)]
        [InlineData(CommentType, null, null, null, null, $"{GetCommentsUri}/shouts")]
        [InlineData(null, ObjectType, null, null, null, $"{GetCommentsUri}/episodes")]
        [InlineData(null, null, ExtendedInfo, null, null, $"{GetCommentsUri}?extended=full")]
        [InlineData(null, null, null, Page, null, $"{GetCommentsUri}?page=2")]
        [InlineData(null, null, null, null, CommentsLimit, $"{GetCommentsUri}?limit=6")]
        [InlineData(CommentType, ObjectType, ExtendedInfo, Page, CommentsLimit, $"{GetCommentsUri}/shouts/episodes" + $"?extended=full&page=2&limit=6")]
        public async Task TestGetComments(TraktCommentType? type, TraktCommentObjectType? objectType, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response = await client.Users.GetCommentsAsync(Username, type, objectType, null, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktUserComment> response = await client.Users.GetCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/comments", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response = await client.Users.GetCommentsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={CommentsLimit}",
                responseContent, 2, 5, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, null, ExtendedInfo, 2, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType,
                                                    null, ExtendedInfo, 2, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType,
                                                    null, ExtendedInfo, 1, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType,
                                                    null, ExtendedInfo, 1, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType,
                                                    null, ExtendedInfo, 2, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType,
                                                    null, ExtendedInfo, 1, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Users.GetCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
