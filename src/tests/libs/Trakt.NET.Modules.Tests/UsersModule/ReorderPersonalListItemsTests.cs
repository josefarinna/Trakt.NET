using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ReorderPersonalListItemsTests
    {
        private readonly string ReorderPersonalListItemsUri = $"users/{Username}/lists/{ListID}/items/reorder";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private readonly List<uint> ReorderedCustomListItems = [923, 324, 98768, 456456, 345, 12, 990];

        [Fact]
        public async Task TestReorderPersonalListItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, responseContent, null, null, null, null);
            TraktResponse<TraktListItemsReorderPostResponse> response = await client.Users.ReorderPersonalListItemsAsync(Username, ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktListItemsReorderPostResponse responseValue = response.Content;

            responseValue.Updated.ShouldBe(6U);
            responseValue.SkippedIDs.ShouldNotBeNull();
            responseValue.SkippedIDs.Count.ShouldBe(1);
            responseValue.SkippedIDs.ShouldBeEquivalentTo(new List<uint> { 12 });
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, TraktListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithListIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, listIds, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/reorder",
                responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, listIds, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithListIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/reorder",
                responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, listIds, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/reorder",
                responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, list, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestReorderPersonalListItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, statusCode);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListItemsAsync(Username, ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsExceptions()
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListItemsAsync(null!, ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(string.Empty, ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("user name", ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", default(string)!, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", string.Empty, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", "list id", ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, ListID, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsThrowsArgumentExceptions()
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act =
                () => client.Users.ReorderPersonalListItemsAsync(Username, default(TraktListIDs)!, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, default(TraktList)!, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, new TraktListIDs(), ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, 0, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
