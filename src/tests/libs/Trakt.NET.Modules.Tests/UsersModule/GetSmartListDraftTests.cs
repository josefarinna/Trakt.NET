using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSmartListDraftTests
    {
        private const string GetSmartListDraftUri = $"users/{Username}/lists/{ListID}/smart-list-draft";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestGetSmartListDraft()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_draft.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListDraftUri, responseContent);

            TraktResponse<TraktSmartListDraft> response = await client.Users.GetSmartListDraftAsync(Username, ListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSmartListDraft responseValue = response.Content;

            responseValue.List.ShouldNotBeNull();
            responseValue.List!.IDs.ShouldNotBeNull();
            responseValue.List!.IDs!.Trakt.ShouldBe(1248149U);
            responseValue.List!.IDs!.Slug.ShouldBe("marvel-cinematic-universe");

            responseValue.OriginUrl.ShouldBe("https://mdblist.com/lists/trakt/mcu");
            responseValue.Source.ShouldBe(TraktSmartListSource.Popular);
            responseValue.MediaType.ShouldBe(TraktSmartListMediaType.Movies);

            responseValue.Filters.ShouldNotBeNull();
            responseValue.Filters!.Genres.ShouldNotBeNull();
            responseValue.Filters!.Genres.Length.ShouldBe(2);
            responseValue.Filters!.Genres[0].ShouldBe("action");
            responseValue.Filters!.Genres[1].ShouldBe("adventure");
            responseValue.Filters!.Years.ShouldNotBeNull();
            responseValue.Filters!.Years.Length.ShouldBe(2);
            responseValue.Filters!.Years![0].ShouldBe(2008U);
            responseValue.Filters!.Years![1].ShouldBe(2024U);

            responseValue.Unsupported.ShouldNotBeNull();
            responseValue.Unsupported.Count.ShouldBe(1);
            responseValue.Unsupported[0].ShouldBe("custom_rank");

            responseValue.Confidence.ShouldBe(0.95f);

            responseValue.Converted.ShouldNotBeNull();
            responseValue.Converted!.SmartListId.ShouldBe(99999);
            responseValue.Converted!.ConvertedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-10-12T12:00:00.000Z"));
        }

        [Fact]
        public async Task TestGetSmartListDraftWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_draft.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{TraktListID}/smart-list-draft", responseContent);

            TraktResponse<TraktSmartListDraft> response = await client.Users.GetSmartListDraftAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListDraftWithListIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_draft.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{TraktListID}/smart-list-draft", responseContent);

            TraktResponse<TraktSmartListDraft> response = await client.Users.GetSmartListDraftAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListDraftWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_draft.json");

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft", responseContent);

            TraktResponse<TraktSmartListDraft> response = await client.Users.GetSmartListDraftAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListDraftWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_draft.json");

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft", responseContent);

            TraktResponse<TraktSmartListDraft> response = await client.Users.GetSmartListDraftAsync(Username, list, TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListDraftThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListDraftUri, statusCode);
            Func<Task<TraktResponse<TraktSmartListDraft>>> act = () => client.Users.GetSmartListDraftAsync(Username, ListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListDraftArgumentExceptions()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            Func<Task<TraktResponse<TraktSmartListDraft>>> act = () => client.Users.GetSmartListDraftAsync(null!, ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftAsync(string.Empty, ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftAsync("username with spaces", ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, default(string)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, "list id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, 0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, default(TraktListIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, new TraktListIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetSmartListDraftAsync(Username, default(TraktList)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
