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

        [Fact]
        public async Task TestGetListComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);
            
            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, ListID, cancellationToken: TestContext.Current.CancellationToken);

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
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, responseContent, 1, 1, 10, ListCommentsItemCount);

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
        public async Task TestGetListCommentsWithListIdsTraktID()
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
        public async Task TestGetListCommentsWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}/comments", responseContent, 1, 1, 10, ListCommentsItemCount);

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
        public async Task TestGetListCommentsWithListIds()
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

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync(Username, ListID, cancellationToken: TestContext.Current.CancellationToken);

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

            TraktPagedResponse<TraktComment> response = await client.Users.GetListCommentsAsync("me", ListID, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}/{CommentSortOrder.ToURI()}", responseContent, 1, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListCommentsUri}?page={Page}", responseContent, Page, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrderAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}?limit={ListCommentsLimits}",
                responseContent, 1, 1, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, null, null, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithSortOrderAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?limit={ListCommentsLimits}",
                responseContent, 1, 1, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, null, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}?page={Page}&limit={ListCommentsLimits}",
                responseContent, Page, 1, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, null, Page, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}&limit={ListCommentsLimits}",
                responseContent, Page, 1, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, Page, ListCommentsLimits, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListCommentsItemCount);
            response.ItemCount.ShouldBe(ListCommentsItemCount);
            response.Limit.ShouldBe(ListCommentsLimits);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetListCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 5, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, 2U, ListCommentsLimits, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, 2U, ListCommentsLimits, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, 1U, ListCommentsLimits, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 1, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, 1U, ListCommentsLimits, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={ListCommentsLimits}",
                responseContent, 2, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, 2U, ListCommentsLimits, TestContext.Current.CancellationToken);

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
        public async Task TestGetListCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={ListCommentsLimits}",
                responseContent, 1, 2, ListCommentsLimits, ListCommentsItemCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetListCommentsAsync(Username, ListID, CommentSortOrder, 1U, ListCommentsLimits, TestContext.Current.CancellationToken);

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
            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetListCommentsAsync(Username, ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListCommentsThrowsArgumentExceptions()
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
