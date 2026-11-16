using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class GetListLikesTests
    {
        private const string GetListLikesUri = $"lists/{ListID}/likes";
        private const string ListID = "1248149";
        private const uint TraktListID = 1248149U;
        private const string ListSlug = "incredible-thoughts";
        private const uint ListLikesCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private readonly TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, GetListLikesUri)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetListLikesUri}?extended=full")]
        [InlineData(null, Page, null, $"{GetListLikesUri}?page=2")]
        [InlineData(null, null, Limit, $"{GetListLikesUri}?limit=4")]
        [InlineData(TraktExtendedInfo.Full, Page, Limit, $"{GetListLikesUri}?extended=full&page=2&limit=4")]
        public async Task TestGetListLikesWithID(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/likes",
                responseContent, 1, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/likes",
                responseContent, 1, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/likes",
                responseContent, 1, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(list, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListLikesCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListLikesCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestGetListLikesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Lists.GetListLikesAsync(TraktListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListLikesWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Lists.GetListLikesAsync(default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListLikesAsync(default(TraktList)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListLikesAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListLikesAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
