using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetListLikesTests
    {
        private const string GetListLikesUri = $"users/{Username}/lists/{ListID}/likes";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const uint ListLikesItemCount = 2U;
        private const uint ListLikesLimit = 3U;
        private const uint Page = 2U;

        [Theory]
        [InlineData(null, null, GetListLikesUri)]
        [InlineData(Page, null, $"{GetListLikesUri}?page=2")]
        [InlineData(null, ListLikesLimit, $"{GetListLikesUri}?limit=3")]
        [InlineData(Page, ListLikesLimit, $"{GetListLikesUri}?page=2&limit=3")]
        public async Task TestGetListLikesWithID(uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}/likes",
                responseContent, 1, 1, 10, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{TraktListID}/likes",
                responseContent, 1, 1, 10, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, listIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID
                }
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{TraktListID}/likes",
                responseContent, 1, 1, 10, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, list, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetListLikesUri, responseContent, 1, 1, 10, ListLikesItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/lists/{ListID}/likes", responseContent, 1, 1, 10, ListLikesItemCount);
            
            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync("me", TraktListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 5, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, 2, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, 2, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, 1U, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 1, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, 1U, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, 2U, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 2, ListLikesLimit, ListLikesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetListLikesWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, TraktListID, 1U, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 2, ListLikesLimit, ListLikesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetListLikesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetListLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Users.GetListLikesAsync(Username, TraktListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListLikesWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetListLikesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Users.GetListLikesAsync(Username, default(TraktListIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListLikesAsync(Username, default(TraktList)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListLikesAsync(Username, new TraktListIDs());
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync(Username, 0);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
