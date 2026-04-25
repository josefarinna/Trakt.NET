using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSavedFiltersTests
    {
        private const string GetSavedFiltersUri = "users/saved_filters";
        private const uint Page = 1U;
        private const uint SavedFiltersLimit = 4U;
        private const uint SavedFiltersCount = 2U;
        private const TraktFilterSection FilterSection = TraktFilterSection.Movies;

        [Fact]
        public async Task TestGetSavedFilters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSavedFiltersUri,
                responseContent, 1, 1, 10, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response = await client.Users.GetSavedFiltersAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersWithSection()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}",
                responseContent, 1, 1, 10, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?page={Page}",
                responseContent, Page, 1, 10, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?limit={SavedFiltersLimit}",
                responseContent, 1, 1, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(null, null, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersWithSectionAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersWithSectionAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}&limit={SavedFiltersLimit}",
                responseContent, 1, 1, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, null, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page={Page}&limit={SavedFiltersLimit}",
                responseContent, Page, 1, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, Page, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSavedFiltersPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=2&limit={SavedFiltersLimit}",
                responseContent, 2, 5, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, 2, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSavedFiltersPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=2&limit={SavedFiltersLimit}",
                responseContent, 2, 2, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, 2, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSavedFiltersPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=1&limit={SavedFiltersLimit}",
                responseContent, 1, 2, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, 1, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSavedFiltersPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=1&limit={SavedFiltersLimit}",
                responseContent, 1, 1, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, 1, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSavedFiltersPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=2&limit={SavedFiltersLimit}",
                responseContent, 2, 2, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, 2, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=1&limit={SavedFiltersLimit}",
                responseContent, 1, 2, SavedFiltersLimit, SavedFiltersCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSavedFiltersPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=1&limit={SavedFiltersLimit}",
                responseContent, 1, 2, SavedFiltersLimit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FilterSection, 1, SavedFiltersLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetSavedFiltersUri}?section={FilterSection.ToURI()}" +
                $"&page=2&limit={SavedFiltersLimit}",
                responseContent, 2, 2, SavedFiltersLimit, SavedFiltersCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(SavedFiltersLimit);
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
        public async Task TestGetSavedFiltersThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSavedFiltersUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserSavedFilter>>> act = () => client.Users.GetSavedFiltersAsync(FilterSection, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
