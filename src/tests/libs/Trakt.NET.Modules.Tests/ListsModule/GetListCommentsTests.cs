using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class GetListCommentsTests
    {
        private const string GetListCommentsUri = $"lists/{ListID}/comments";
        private const string ListID = "1248149";
        private const uint TraktListID = 1248149U;
        private const string ListSlug = "incredible-thoughts";
        private const uint ListCommentsItemCount = 2U;
        private const uint Page = 2U;
        private const uint ListCommentsLimit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const TraktCommentSortOrder CommentSortOrder = TraktCommentSortOrder.Likes;

        [Fact]
        public async Task TestGetListComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(TraktListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithListIDsTraktID()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithListIDsSlug()
        {
            var listIDs = new TraktListIDs
            {
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithListIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(list, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}/{CommentSortOrder.ToURI()}", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}?page={Page}", responseContent, Page, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}?limit={ListCommentsLimit}", responseContent, 1, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, null, null, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrderAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrderAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}", responseContent, Page, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrderAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?limit={ListCommentsLimit}",
                responseContent, 1, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, null, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}?extended={ExtendedInfo.ToURI()}&limit={ListCommentsLimit}",
                responseContent, 1, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, ExtendedInfo, null, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrderAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}&limit={ListCommentsLimit}",
                responseContent, Page, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, Page, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={ListCommentsLimit}",
                responseContent, Page, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, ExtendedInfo, Page, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}?page={Page}&limit={ListCommentsLimit}",
                responseContent, Page, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, null, null, Page, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={ListCommentsLimit}",
                responseContent, Page, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, ExtendedInfo, Page, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 5, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, 2, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, 2, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, 1, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, 1, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, 2, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 2, ListCommentsLimit, ListCommentsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(ListID, CommentSortOrder, null, 1, ListCommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 2, ListCommentsLimit, ListCommentsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
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
        public async Task TestGetListCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Lists.GetListCommentsAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListCommentsThrowsArgumentExceptions()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Lists.GetListCommentsAsync(default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListCommentsAsync(default(TraktList)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListCommentsAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListCommentsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
