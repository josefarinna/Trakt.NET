using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetRecentlyUpdatedPeopleIDsTests
    {
        private const string GetRecentlyUpdatedPeopleIdsUri = "people/updates/id";
        private const uint UpdatedIdsCount = 4U;
        private static readonly DateTime Today = DateTime.UtcNow;

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedPeopleIdsUri, responseContent, 1U, 1, 10U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithStartDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");
            string expectedUri = $"{GetRecentlyUpdatedPeopleIdsUri}/{Today:yyyy-MM-ddTHH:00:00Z}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1U, 1, 10U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                Today, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleIdsUri}?page=2", responseContent, 2U, 1, 10U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleIdsUri}?limit=4", responseContent, 1U, 1, 4U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithStartDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");
            string expectedUri = $"{GetRecentlyUpdatedPeopleIdsUri}/{Today:yyyy-MM-ddTHH:00:00Z}?page=2";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2U, 1, 10U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                Today, page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithStartDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");
            string expectedUri = $"{GetRecentlyUpdatedPeopleIdsUri}/{Today:yyyy-MM-ddTHH:00:00Z}?limit=4";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1U, 1, 4U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                Today, limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleIdsUri}?page=2&limit=4", responseContent, 2U, 1, 4U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                page: 2U, limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsWithStartDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");
            string expectedUri = $"{GetRecentlyUpdatedPeopleIdsUri}/{Today:yyyy-MM-ddTHH:00:00Z}?page=2&limit=4";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2U, 1, 4U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                Today, 2U, 4U, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");
            string uriPage2 = $"{GetRecentlyUpdatedPeopleIdsUri}?page=2&limit=10";
            string uriPage1 = $"{GetRecentlyUpdatedPeopleIdsUri}?page=1&limit=10";

            TraktClient client = ModuleTestUtility.GetClient(uriPage2, responseContent, 2, 2, 10, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                null, 2, 10, TestContext.Current.CancellationToken);

            response.HasPreviousPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, uriPage1, responseContent, 1, 2, 10, UpdatedIdsCount);
            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.Page.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");
            string uriPage1 = $"{GetRecentlyUpdatedPeopleIdsUri}?page=1&limit=10";
            string uriPage2 = $"{GetRecentlyUpdatedPeopleIdsUri}?page=2&limit=10";

            TraktClient client = ModuleTestUtility.GetClient(uriPage1, responseContent, 1, 2, 10, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                null, 1, 10, TestContext.Current.CancellationToken);

            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, uriPage2, responseContent, 2, 2, 10, UpdatedIdsCount);
            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.Page.ShouldBe(2U);
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
        public async Task TestGetRecentlyUpdatedPeopleIdsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedPeopleIdsUri, statusCode);

            Func<Task<TraktPagedResponse<uint>>> act = () => client.People.GetRecentlyUpdatedPeopleIDsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
