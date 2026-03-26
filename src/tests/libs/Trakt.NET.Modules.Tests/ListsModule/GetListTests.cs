using System.Net;

namespace TraktNET.ListsModule
{
    public sealed partial class GetListTests
    {
        private const uint ListID = 1248149U;
        private const string ListSlug = "marvel-cinematic-universe";
        private readonly string GetListUri = $"lists/{ListID}";

        [Fact]
        public async Task TestGetListWithoutExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");
            TraktClient client = ModuleTestUtility.GetClient(GetListUri, responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList list = response.Content;

            list.Name.ShouldBe("MARVEL Cinematic Universe");
            list.Description.ShouldBe("MCU Shows and Movies in chronological order.");
            list.Privacy.ShouldBe(TraktListPrivacy.Public);
            list.ShareLink.ShouldBe("https://trakt.tv/lists/1248149");
            list.Type.ShouldBe(TraktListType.Personal);
            list.DisplayNumbers.ShouldBe(true);
            list.AllowComments.ShouldBe(true);
            list.SortBy.ShouldBe(TraktSortBy.Rank);
            list.SortHow.ShouldBe(TraktSortHow.Ascending);
            list.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-07-16T14:59:57.000Z"));
            list.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T06:47:38.000Z"));
            list.ItemCount.ShouldBe(218U);
            list.CommentCount.ShouldBe(33U);
            list.Likes.ShouldBe(4668U);

            list.IDs.ShouldNotBeNull();
            list.IDs!.Trakt.ShouldBe(1248149U);
            list.IDs!.Slug.ShouldBe("marvel-cinematic-universe");

            list.User.ShouldNotBeNull();
            list.User!.Username.ShouldBe("Donxy");
            list.User!.Private.ShouldBe(false);
            list.User!.Name.ShouldBe("Donxy");
            list.User!.VIP.ShouldBe(false);
            list.User!.VIPEP.ShouldBe(true);
            list.User!.IDs.ShouldNotBeNull();
            list.User!.IDs!.Slug.ShouldBe("donxy");
        }

        [Fact]
        public async Task TestGetListWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");
            TraktClient client = ModuleTestUtility.GetClient(GetListUri, responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");
            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}", responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListSlug, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");
            var extendedInfo = TraktExtendedInfo.Full;
            TraktClient client = ModuleTestUtility.GetClient($"{GetListUri}?extended={extendedInfo}".ToLowerInvariant(), responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            // Minimal validation to ensure the object mapped correctly
            response.Content.Name.ShouldBe("MARVEL Cinematic Universe");
            response.Content.ItemCount.ShouldBe(218U);
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
        public async Task TestGetListThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Lists.GetListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktList>>> act = () => client.Lists.GetListAsync(default(string), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Lists.GetListAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
