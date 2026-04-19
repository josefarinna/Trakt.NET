using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdatePersonalListItemTests
    {
        private readonly string UpdatePersonalListItemUri = $"users/{Username}/lists/{ListID}/items/{ListItemID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55U;
        private const string ListSlug = "incredible-thoughts";
        private const string Notes = "This is a great movie!";
        private const uint ListItemID = 1U;

        [Fact]
        public async Task TestUpdatePersonalListItem()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, ListID, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithTraktID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, TraktListID, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithListIdsTraktID()
        {
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, listIds, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithListIdsSlug()
        {
            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/{ListItemID}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, listIds, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithListIds()
        {
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/{ListItemID}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, listIds, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/{ListItemID}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, list, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
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
        public async Task TestUpdatePersonalListItemThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdatePersonalListItemAsync(Username, ListID, ListItemID, Notes, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdatePersonalListItemAsync(Username, default(TraktListIDs)!, ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListItemAsync(Username, default(TraktList)!, ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListItemAsync(Username, new TraktListIDs(), ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdatePersonalListItemAsync(Username, 0, ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
