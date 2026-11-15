using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetListCommentsTests
    {
        private const string GetListCommentsUri = $"users/{Username}/lists/{ListID}/comments";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const uint ListCommentsItemCount = 2U;
        private const uint ListCommentsLimits = 4;
        private const uint Page = 2U;
        private const TraktCommentSortOrder CommentSortOrder = TraktCommentSortOrder.Likes;

        [Theory]
        [InlineData(null, null, null, GetListCommentsUri)]
        [InlineData(CommentSortOrder, null, null, $"{GetListCommentsUri}/likes")]
        [InlineData(null, Page, null, $"{GetListCommentsUri}?page=2")]
        [InlineData(null, null, ListCommentsLimits, $"{GetListCommentsUri}?limit=4")]
        [InlineData(CommentSortOrder, Page, ListCommentsLimits, $"{GetListCommentsUri}/likes?page=2&limit=4")]
        public async Task TestGetListCommentsWithID(TraktCommentSortOrder? commentSortOrder, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, TraktListID, commentSortOrder, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, listIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID
                }
            };

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, list, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, TraktListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/lists/{ListID}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync("me", TraktListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 5, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, TraktListID, CommentSortOrder, 2U, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, TraktListID, CommentSortOrder, 2U, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, TraktListID, CommentSortOrder, 1U, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 1, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, TraktListID, CommentSortOrder, 1U, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, TraktListID, CommentSortOrder, 2U, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 2, ListCommentsLimits, ListCommentsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, TraktListID, CommentSortOrder, 1U, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 2, ListCommentsLimits, ListCommentsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetListCommentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetListCommentsAsync(Username, TraktListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetListCommentsAsync(Username, default(TraktListIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListCommentsAsync(Username, default(TraktList)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListCommentsAsync(Username, new TraktListIDs());
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetListCommentsAsync(Username, 0);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
