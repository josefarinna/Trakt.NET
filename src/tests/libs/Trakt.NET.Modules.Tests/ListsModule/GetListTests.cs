using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class GetListTests
    {
        private readonly string GetListUri = $"lists/{ListID}";
        private const uint ListID = 1248149U;
        private const string ListSlug = "marvel-cinematic-universe";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetListWithoutExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListUri, responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.ShouldNotBeNull();
            responseValue.Name.ShouldBe("MARVEL Cinematic Universe");
            responseValue.Description.ShouldBe("MCU Shows and Movies in chronological order.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(true);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-07-16T14:59:57.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T06:47:38.000Z"));
            responseValue.ItemCount.ShouldBe(218U);
            responseValue.CommentCount.ShouldBe(33U);
            responseValue.Likes.ShouldBe(4668U);

            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(1248149U);
            responseValue.IDs.Slug.ShouldBe("marvel-cinematic-universe");

            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("Donxy");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Donxy");
            responseValue.User.VIP.ShouldBe(false);
            responseValue.User.VIPEP.ShouldBe(true);
            responseValue.User.IDs.ShouldNotBeNull();
            responseValue.User.IDs.Slug.ShouldBe("donxy");
        }

        [Fact]
        public async Task TestGetListWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListUri, responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithListIDsTraktID()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = ListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListUri, responseContent);
            
            TraktResponse<TraktList> response = await client.Lists.GetListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithListIDsSlug()
        {
            var listIDs = new TraktListIDs
            {
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Lists.GetListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithListIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = ListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Lists.GetListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.ShouldNotBeNull();
            responseValue.Name.ShouldBe("MARVEL Cinematic Universe");
            responseValue.Description.ShouldBe("MCU Shows and Movies in chronological order.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(true);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-07-16T14:59:57.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T06:47:38.000Z"));
            responseValue.ItemCount.ShouldBe(218U);
            responseValue.CommentCount.ShouldBe(33U);
            responseValue.Likes.ShouldBe(4668U);

            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(1248149U);
            responseValue.IDs.Slug.ShouldBe("marvel-cinematic-universe");

            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("Donxy");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Donxy");
            responseValue.User.VIP.ShouldBe(false);
            responseValue.User.VIPEP.ShouldBe(true);
            responseValue.User.IDs.ShouldNotBeNull();
            responseValue.User.IDs.Slug.ShouldBe("donxy");
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

            Func<Task<TraktResponse<TraktList>>> act = () => client.Lists.GetListAsync(default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

        }
    }
}
