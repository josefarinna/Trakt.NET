using System.Net;

namespace TraktNET.ListsModule
{
    public sealed partial class GetListItemsTests
    {
        private const string ListID = "1248149";
        private const string GetListItemsUri = $"lists/1248149/items";

        [Theory]
        [InlineData(null, 1U, 10U, $"{GetListItemsUri}?page=1&limit=10")]
        [InlineData(TraktExtendedInfo.Full, 2U, 20U, $"{GetListItemsUri}?extended=full&page=2&limit=20")]
        public async Task TestGetListItems(TraktExtendedInfo? extendedInfo, uint page, uint limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(ListID, extendedInfo: extendedInfo, page: page, limit: limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);

            List<TraktListItem> items = [.. response.Content];

            // Item 1: Movie
            items[0].Rank.ShouldBe(1U);
            items[0].Type.ShouldBe(TraktListItemType.Movie);
            items[0].Movie.ShouldNotBeNull();
            items[0].Movie!.Title.ShouldBe("Star Wars: Episode IV - A New Hope");

            // Item 2: Show
            items[1].Rank.ShouldBe(2U);
            items[1].Type.ShouldBe(TraktListItemType.Show);
            items[1].Show.ShouldNotBeNull();
            items[1].Show!.Title.ShouldBe("The Walking Dead");

            // Item 3: Season
            items[2].Rank.ShouldBe(3U);
            items[2].Type.ShouldBe(TraktListItemType.Season);
            items[2].Season.ShouldNotBeNull();
            items[2].Season!.Number.ShouldBe(1U);

            // Item 4: Episode
            items[3].Rank.ShouldBe(4U);
            items[3].Type.ShouldBe(TraktListItemType.Episode);
            items[3].Episode.ShouldNotBeNull();
            items[3].Episode!.Title.ShouldBe("Wedding Day");
        }

        [Fact]
        public async Task TestGetListItemsPaging()
        {
            const uint page = 1;
            const uint limit = 4;
            string requestUri = $"{GetListItemsUri}?page={page}&limit={limit}";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 2, limit, 4);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(ListID, null, null, page, limit, TestContext.Current.CancellationToken);

            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            ModuleTestUtility.SetClient(client, $"{GetListItemsUri}?page=2&limit={limit}", responseContent, 2, 2, limit, 4);
            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.Page.ShouldBe(2U);
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
        public async Task TestGetListItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Lists.GetListItemsAsync(ListID, null, null, 1, 10, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListItemsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListItemsUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Lists.GetListItemsAsync(default(string), null, null, page: 1, limit: 10);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Lists.GetListItemsAsync(ListID, null, null, null, 10);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListItemsAsync(ListID, null, null, 1, null);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
