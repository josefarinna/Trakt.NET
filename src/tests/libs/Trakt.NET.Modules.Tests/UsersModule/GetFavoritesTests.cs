using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFavoritesTests
    {
        private const string GetFavoritesUri = $"users/{Username}/favorites";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint FavoritesItemCount = 2U;
        private const TraktFavoriteObjectType FavoriteType = TraktFavoriteObjectType.Movie;
        private const TraktSortBy SortBy = TraktSortBy.Rank;
        private const TraktSortHow SortHow = TraktSortHow.Ascending;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetFavorites()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/favorites?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync("me", null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}/{FavoriteType.ToURI()}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSort()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSortAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, FavoritesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, FavoritesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
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
        public async Task TestGetFavoritesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetFavoritesThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Users.GetFavoritesAsync(Username, null, null, null, null, null, Limit, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
