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

        [Theory]
        [InlineData(null, null, null, null, GetListCommentsUri)]
        [InlineData(CommentSortOrder, null, null, null, $"{GetListCommentsUri}/likes")]
        [InlineData(null, ExtendedInfo, null, null, $"{GetListCommentsUri}?extended=full")]
        [InlineData(null, null, Page, null, $"{GetListCommentsUri}?page=2")]
        [InlineData(null, null, null, ListCommentsLimit, $"{GetListCommentsUri}?limit=4")]
        [InlineData(CommentSortOrder, ExtendedInfo, Page, ListCommentsLimit, $"{GetListCommentsUri}/likes?extended=full&page=2&limit=4")]
        public async Task TestGetListCommentsWithID(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(TraktListID, commentSortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

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
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(ListSlug, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDs()
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
        public async Task TestGetListCommentsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 5, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(TraktListID, CommentSortOrder, null, 2, ListCommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(TraktListID, CommentSortOrder, null, 2, ListCommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(TraktListID, CommentSortOrder, null, 1, ListCommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 1, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(TraktListID, CommentSortOrder, null, 1, ListCommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimit}",
                responseContent, 2, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(TraktListID, CommentSortOrder, null, 2, ListCommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimit}",
                responseContent, 1, 2, ListCommentsLimit, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Lists.GetListCommentsAsync(TraktListID, CommentSortOrder, null, 1, ListCommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Lists.GetListCommentsAsync(TraktListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListCommentsWithIDsThrowsArgumentException()
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
