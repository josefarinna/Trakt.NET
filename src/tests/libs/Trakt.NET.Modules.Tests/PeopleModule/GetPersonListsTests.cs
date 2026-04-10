using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetPersonListsTests
    {
        private const string GetPersonListsUri = "people/297737/lists";
        private const uint PersonID = 297737U;
        private const string PersonSlug = "bryan-cranston";
        private const uint ListItemCount = 1U;
        private const uint Limit = 4U;
        private const TraktListSortOrder ListSortOrder = TraktListSortOrder.Comments;
        private const TraktListType ListType = TraktListType.Official;

        [Theory]
        // type | sortOrder | useExtended | page | limit | expectedUri
        [InlineData(null, null, null, null, null, GetPersonListsUri)]
        [InlineData(TraktListType.Official, null, null, null, null, $"{GetPersonListsUri}/official")]
        [InlineData(null, TraktListSortOrder.Comments, null, null, null, $"{GetPersonListsUri}/comments")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetPersonListsUri}?extended=full")]
        [InlineData(null, null, null, 2U, null, $"{GetPersonListsUri}?page=2")]
        [InlineData(null, null, null, null, 4U, $"{GetPersonListsUri}?limit=4")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Comments, null, null, null, $"{GetPersonListsUri}/official/comments")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, null, $"{GetPersonListsUri}/official?extended=full")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Comments, TraktExtendedInfo.Full, 2U, 4U, $"{GetPersonListsUri}/official/comments?extended=full&page=2&limit=4")]
        public async Task TestGetPersonListsParametrized(TraktListType? type, TraktListSortOrder? sortOrder, TraktExtendedInfo? extendedInfo,
            uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, type, sortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(expectedPage);
            response.Limit.ShouldBe(expectedLimit);
        }

        [Fact]
        public async Task TestGetPersonListsWithPersonIds()
        {
            var personIds = new TraktPersonIDs { Trakt = PersonID, Slug = PersonSlug };
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");
            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/lists", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithPerson()
        {
            var person = new TraktPerson { IDs = new TraktPersonIDs { Trakt = PersonID, Slug = PersonSlug } };
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");
            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/lists", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(person, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(PersonID, ListType, ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetPersonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPersonListsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(PersonID, ListType, ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetPersonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiPersonNotFoundException))]
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
        public async Task TestGetPersonListsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonListsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.People.GetPersonListsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonListsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonListsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.People.GetPersonListsAsync(default(TraktPersonIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonListsAsync(default(TraktPerson)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonListsAsync(new TraktPersonIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonListsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
