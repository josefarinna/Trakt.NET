using System.Net;

namespace TraktNET.SmartListsModule
{
    public sealed class GetSmartListTests
    {
        private readonly string GetSmartListUri = $"smart-lists/{ListID}";
        private const string ListSlug = "sci-fi-movies";
        private const uint ListID = 123456U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetSmartListWithoutExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithListIDsTraktID()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = ListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithListIDsSlug()
        {
            var listIDs = new TraktListIDs
            {
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithListIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = ListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithList()
        {
            var list = new TraktSmartList
            {
                IDs = new TraktListIDs
                {
                    Trakt = ListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(list, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(ListSlug, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSmartList responseValue = response.Content;

            responseValue.ShouldNotBeNull();
            responseValue.Name.ShouldBe("Sci-Fi Movies");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.Source.ShouldBe(TraktSmartListSource.Popular);
            responseValue.MediaType.ShouldBe(TraktSmartListMediaType.Movies);

            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(123456U);
            responseValue.IDs.Slug.ShouldBe("sci-fi-movies");
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
        public async Task TestGetSmartListThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, statusCode);

            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.SmartLists.GetSmartListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.SmartLists.GetSmartListAsync(default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.SmartLists.GetSmartListAsync(default(TraktSmartList)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.SmartLists.GetSmartListAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.SmartLists.GetSmartListAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
