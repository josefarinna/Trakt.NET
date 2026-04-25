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

        [Fact]
        public async Task TestGetComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);

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
        public async Task TestGetCommentsWithCommentType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentsUri}/{CommentType.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithCommentTypeAndObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithCommentTypeAndObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithCommentTypeAndObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, null, null, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, null, null, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithCommentTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, ExtendedInfo, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, ExtendedInfo, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, null, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithCommentTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, null, null, null, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithObjectType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithObjectTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithObjectTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithObjectTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, ExtendedInfo, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithObjectTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, ExtendedInfo, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithObjectTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithObjectTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");
            
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, null, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithObjectTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{ObjectType.ToURI()}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, ObjectType, null, null, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?extended={ExtendedInfo.ToURI()}&limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, ExtendedInfo, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, ExtendedInfo, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?page={Page}",
                responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, null, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, null, null, null, null, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCommentsUri}/{CommentType.ToURI()}/{ObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsItemCount);

            TraktPagedResponse<TraktUserComment> response =
                await client.Users.GetCommentsAsync(Username, CommentType, ObjectType, null, ExtendedInfo, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
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
        public async Task TestGetCommentsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Users.GetCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
