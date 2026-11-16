using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetTrendingCommentsTests
    {
        private const string GetCommentsTrendingUri = "comments/trending";
		private const uint CommentsItemCount = 5;
		private const uint Page = 2U;
		private const uint Limit = 4U;
		private const TraktCommentType CommentType = TraktCommentType.Shout;
        private const TraktCommentObjectType ObjectType = TraktCommentObjectType.Episode;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, null, GetCommentsTrendingUri)]
        [InlineData(CommentType, null, null, null, null, null, $"{GetCommentsTrendingUri}/shouts")]
        [InlineData(null, ObjectType, null, null, null, null, $"{GetCommentsTrendingUri}/episodes")]
        [InlineData(null, null, true, null, null, null, $"{GetCommentsTrendingUri}?include_replies=true")]
        [InlineData(null, null, null, ExtendedInfo, null, null, $"{GetCommentsTrendingUri}?extended=full")]
        [InlineData(null, null, null, null, Page, null, $"{GetCommentsTrendingUri}?page=2")]
        [InlineData(null, null, null, null, null, Limit, $"{GetCommentsTrendingUri}?limit=4")]
        [InlineData(CommentType, ObjectType, true, ExtendedInfo, Page, Limit, $"{GetCommentsTrendingUri}/shouts/episodes" + $"?include_replies=true&extended=full&page=2&limit=4")]
        public async Task TestGetTrendingComments(TraktCommentType? commentType, TraktCommentObjectType? type, bool? includeReplies, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response = await client.Comments.GetTrendingCommentsAsync(commentType, type, includeReplies, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTrendingCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetTrendingCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTrendingCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetTrendingCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTrendingCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestGetTrendingCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentsTrendingUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Comments.GetTrendingCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
