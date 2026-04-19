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

        [Fact]
        public async Task TestGetListLikes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, responseContent, 1, 1, 10, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{TraktListID}/likes",
                responseContent, 1, 1, 10, ListLikesItemCount);

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
        public async Task TestGetListLikesWithListIdsTraktID()
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
        public async Task TestGetListLikesWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}/likes",
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
        public async Task TestGetListLikesWithListIds()
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
            //client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, cancellationToken: TestContext.Current.CancellationToken);

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
            
            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync("me", ListID, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page={Page}",
                responseContent, Page, 1, 10, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?limit={ListLikesLimit}",
                responseContent, 1, 1, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, null, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page={Page}&limit={ListLikesLimit}",
                responseContent, Page, 1, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, Page, ListLikesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesItemCount);
            response.ItemCount.ShouldBe(ListLikesItemCount);
            response.Limit.ShouldBe(ListLikesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 5, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, 2, ListLikesLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, 2, ListLikesLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, 1U, ListLikesLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 1, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, 1U, ListLikesLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={ListLikesLimit}",
                responseContent, 2, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, 2U, ListLikesLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={ListLikesLimit}",
                responseContent, 1, 2, ListLikesLimit, ListLikesItemCount);

            TraktPagedResponse<TraktListLike> response = await client.Users.GetListLikesAsync(Username, ListID, 1U, ListLikesLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetListLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Users.GetListLikesAsync(Username, ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListLikesThrowsArgumentExceptions()
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
