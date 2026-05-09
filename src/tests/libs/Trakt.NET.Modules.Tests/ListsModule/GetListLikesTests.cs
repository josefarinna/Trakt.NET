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

        [Fact]
        public async Task TestGetListLikes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri,
                responseContent, 1, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{TraktListID}/likes",
                responseContent, 1, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(TraktListID, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesWithListIDsTraktID()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{TraktListID}/likes",
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
        public async Task TestGetListLikesWithListIDsSlug()
        {
            var listIDs = new TraktListIDs
            {
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
        public async Task TestGetListLikesWithListIDs()
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
        public async Task TestGetListLikesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page={Page}",
                responseContent, Page, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?limit={Limit}",
                responseContent, 1, 1, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListLikesCount);
            response.ItemCount.ShouldBe(ListLikesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListLikesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListLikesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListLikesCount);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListLikesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Lists.GetListLikesAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListLikesThrowsArgumentExceptions()
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
