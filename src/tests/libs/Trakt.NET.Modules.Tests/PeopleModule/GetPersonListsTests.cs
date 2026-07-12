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

        [Fact]
        public async Task TestGetPersonLists()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonListsUri, responseContent, 1U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListType.ToURI()}", responseContent, 1U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, listType: ListType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListSortOrder.ToURI()}", responseContent, 1U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, listSortOrder: ListSortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}?extended=full", responseContent, 1U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, extendedInfo: TraktExtendedInfo.Full, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}?page=2", responseContent, 2U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}?limit=4", responseContent, 1U, 1, 4U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetPersonListsWithTypeAndSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}", responseContent, 1U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, ListType, ListSortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListType.ToURI()}?extended=full", responseContent, 1U, 1, 10U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, listType: ListType, extendedInfo: TraktExtendedInfo.Full, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetPersonListsWithTypeAndSortOrderAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?extended=full&page=2&limit=4", responseContent, 2U, 1, 4U, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.People.GetPersonListsAsync(
                PersonID, ListType, ListSortOrder, TraktExtendedInfo.Full, 2U, 4U, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
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
