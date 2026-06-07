using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetRecentlyUpdatedCommentsTests
    {
        private const string GetRecentlyUpdatedCommentsUri = "comments/updates";
        private const uint CommentsItemCount = 5U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktCommentType CommentType = TraktCommentType.Shout;
        private const TraktCommentObjectType ObjectType = TraktCommentObjectType.Episode;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetRecentlyUpdatedComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response = await client.Comments.GetRecentlyUpdatedCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndObjectTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, true, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, true, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithCommentTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, true, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, true, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, true, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{ObjectType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, ObjectType, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, true, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, true, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType,
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
        public async Task TestGetRecentlyUpdatedCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
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
        public async Task TestGetRecentlyUpdatedCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyUpdatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
                $"{GetRecentlyUpdatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
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
        public async Task TestGetRecentlyUpdatedCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Comments.GetRecentlyUpdatedCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
