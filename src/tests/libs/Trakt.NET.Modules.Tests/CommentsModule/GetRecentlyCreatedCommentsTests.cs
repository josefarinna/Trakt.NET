using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetRecentlyCreatedCommentsTests
    {
        private const string GetRecentlyCreatedCommentsUri = "comments/recent";
        private const uint CommentsItemCount = 5U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktCommentType CommentType = TraktCommentType.Shout;
        private const TraktCommentObjectType ObjectType = TraktCommentObjectType.Episode;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetRecentlyCreatedComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyCreatedCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response = await client.Comments.GetRecentlyCreatedCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndObjectTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, true, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, true, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, true, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithCommentTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, true, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, true, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, true, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, true, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{ObjectType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, ObjectType, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithIncludeReplies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?include_replies=true",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithIncludeRepliesAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?include_replies=true&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithIncludeRepliesAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?include_replies=true&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithIncludeRepliesAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?include_replies=true&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType,
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
        public async Task TestGetRecentlyCreatedCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyCreatedCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
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
        public async Task TestGetRecentlyCreatedCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?include_replies=true&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(CommentType, ObjectType, true, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
                $"{GetRecentlyCreatedCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
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
        public async Task TestGetRecentlyCreatedCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyCreatedCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
