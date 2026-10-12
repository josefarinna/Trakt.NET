using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ConvertListToSmartListTests
    {
        private readonly string ConvertListToSmartListUri = $"users/{Username}/lists/{ListID}/smart-list-draft/convert";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const string SmartListName = "converted smart list";

        [Fact]
        public async Task TestConvertListToSmartList()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, ListID, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.IDs.ShouldNotBeNull();
            response.Content.IDs.Trakt.ShouldBe(123U);
            response.Content.IDs.Slug.ShouldBe("abc");
        }

        [Fact]
        public async Task TestConvertListToSmartListWithTraktID()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, TraktListID, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithListIdsTraktID()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, listIds, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithListIdsSlug()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft/convert", responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, listIds, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithListIds()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft/convert", responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, listIds, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithList()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft/convert", responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, list, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestConvertListToSmartListThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, statusCode);

            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.ConvertListToSmartListAsync(Username, ListID, smartListPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListThrowsArgumentExceptions()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.ConvertListToSmartListAsync(null!, ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(string.Empty, ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync("username with spaces", ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, default(string)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, string.Empty, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, "list id with spaces", smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, ListID, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, default(TraktListIDs)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, default(TraktList)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, new TraktListIDs(), smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, 0, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
