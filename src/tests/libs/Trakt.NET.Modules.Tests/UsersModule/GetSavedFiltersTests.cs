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

        [Theory]
        [InlineData(null, null, null, GetSavedFiltersUri)]
        [InlineData(FilterSection, null, null, $"{GetSavedFiltersUri}?section=movies")]
        [InlineData(null, Page, null, $"{GetSavedFiltersUri}?page=1")]
        [InlineData(null, null, SavedFiltersLimit, $"{GetSavedFiltersUri}?limit=4")]
        [InlineData(FilterSection, Page, SavedFiltersLimit, $"{GetSavedFiltersUri}?section=movies" + $"&page=1&limit=4")]
        public async Task TestGetSavedFilters(TraktFilterSection? section, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\savedfilters.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, SavedFiltersCount);

            TraktPagedResponse<TraktUserSavedFilter> response = await client.Users.GetSavedFiltersAsync(section, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SavedFiltersCount);
            response.ItemCount.ShouldBe(SavedFiltersCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
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
        public async Task TestGetSavedFiltersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSavedFiltersUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserSavedFilter>>> act = () => client.Users.GetSavedFiltersAsync(FilterSection, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
