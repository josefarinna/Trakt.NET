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

        [Fact]
        public async Task TestGetTrendingComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentsTrendingUri, responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response = await client.Comments.GetTrendingCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentsTrendingUri}/{CommentType.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndObjectTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, true, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, true, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithCommentTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, true, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, true, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, true, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{ObjectType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, ObjectType, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, true, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, true, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsTrendingUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetTrendingCommentsAsync(CommentType, ObjectType,
                                                    true, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
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
        public async Task TestGetTrendingCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentsTrendingUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Comments.GetTrendingCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
