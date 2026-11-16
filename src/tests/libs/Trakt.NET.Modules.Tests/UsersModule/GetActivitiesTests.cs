using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetActivitiesTests
    {
        private const string Username = "sean";
        private const TraktUserSocialActivityType ActivityType = TraktUserSocialActivityType.Friends;
        private const string GetActivitiesUri = $"users/{Username}/friends/activities";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const uint Page = 2;
        private const uint Limit = 4;
        private const uint ItemCount = 1;

        [Theory]
        [InlineData(null, null, null, null, GetActivitiesUri)]
        [InlineData(ExtendedInfo, null, null, null, $"{GetActivitiesUri}?extended=full")]
        [InlineData(TraktExtendedInfo.Full | TraktExtendedInfo.Images | TraktExtendedInfo.Colors | TraktExtendedInfo.StreamingIDs | TraktExtendedInfo.Rating, null, null, null,
                    $"{GetActivitiesUri}?extended=full,images,colors,streaming_ids,rating")]
        [InlineData(null, "breaking", null, null, $"{GetActivitiesUri}?query=breaking")]
        [InlineData(null, null, Page, null, $"{GetActivitiesUri}?page=2")]
        [InlineData(null, null, null, Limit, $"{GetActivitiesUri}?limit=4")]
        [InlineData(ExtendedInfo, null, Page, Limit, $"{GetActivitiesUri}?extended=full&page=2&limit=4")]
        public async Task TestGetActivities(TraktExtendedInfo? extendedInfo, string? query, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, ItemCount);

            TraktFilter? filter = query is not null ? new TraktFilter { Query = query } : null;

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, extendedInfo, filter: filter, page: page, limit: limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1u);

            TraktUserActivity item = response.Content[0];
            item.ShouldNotBeNull();
            item.ID.ShouldBe(123456UL);
            item.Action.ShouldBe("scrobble");
            item.Type.ShouldBe(TraktSyncItemType.Episode);
            item.User.ShouldNotBeNull();
            item.User.Username.ShouldBe("sean");
            item.Episode.ShouldNotBeNull();
            item.Episode.Title.ShouldBe("Pilot");
            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Breaking Bad");
        }

        [Fact]
        public async Task TestGetActivitiesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetActivitiesUri, responseContent, 1, 1, 10, ItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1u);
        }

        [Fact]
        public async Task TestGetActivitiesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/friends/activities", responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                "me", ActivityType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1u);
        }

        [Fact]
        public async Task TestGetActivitiesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetActivitiesUri}?page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetActivitiesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetActivitiesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetActivitiesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetActivitiesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetActivitiesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetActivitiesUri}?page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetActivitiesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetActivitiesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetActivitiesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetActivitiesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\activities.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetActivitiesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserActivity> response = await client.Users.GetActivitiesAsync(
                Username, ActivityType, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetActivitiesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetActivitiesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetActivitiesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserActivity>>> act = () => client.Users.GetActivitiesAsync(
                Username, ActivityType, cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
