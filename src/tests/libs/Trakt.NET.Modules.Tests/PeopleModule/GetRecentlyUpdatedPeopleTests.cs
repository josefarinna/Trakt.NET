using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetRecentlyUpdatedPeopleTests
    {
        private const string GetRecentlyUpdatedPeopleUri = "people/updates";
        private const uint UpdatedPeopleCount = 2U;
        private static readonly DateTime Today = DateTime.UtcNow;

        [Fact]
        public async Task TestGetRecentlyUpdatedPeople()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedPeopleUri, responseContent, 1U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithStartDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string expectedUri = $"people/updates/{Today:yyyy-MM-ddTHH:00:00Z}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                Today, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleUri}?extended=full", responseContent, 1U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                extendedInfo: TraktExtendedInfo.Full, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleUri}?page=2", responseContent, 2U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleUri}?limit=4", responseContent, 1U, 1, 4U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithStartDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string expectedUri = $"people/updates/{Today:yyyy-MM-ddTHH:00:00Z}?extended=full";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                Today, extendedInfo: TraktExtendedInfo.Full, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithStartDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string expectedUri = $"people/updates/{Today:yyyy-MM-ddTHH:00:00Z}?page=2";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                Today, page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithStartDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string expectedUri = $"people/updates/{Today:yyyy-MM-ddTHH:00:00Z}?limit=4";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1U, 1, 4U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                Today, limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleUri}?extended=full&page=2", responseContent, 2U, 1, 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                extendedInfo: TraktExtendedInfo.Full, page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleUri}?extended=full&limit=4", responseContent, 1U, 1, 4U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                extendedInfo: TraktExtendedInfo.Full, limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedPeopleUri}?page=2&limit=4", responseContent, 2U, 1, 4U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                page: 2U, limit: 4U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleWithStartDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string expectedUri = $"people/updates/{Today:yyyy-MM-ddTHH:00:00Z}?extended=full&page=2&limit=4";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2U, 1, 4U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                Today, TraktExtendedInfo.Full, 2U, 4U, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeoplePagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string uriPage2 = $"{GetRecentlyUpdatedPeopleUri}?page=2&limit=10";
            string uriPage1 = $"{GetRecentlyUpdatedPeopleUri}?page=1&limit=10";

            TraktClient client = ModuleTestUtility.GetClient(uriPage2, responseContent, 2, 1, 10, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                null, null, 2, 10, TestContext.Current.CancellationToken);

            response.HasPreviousPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, uriPage1, responseContent, 1, 1, 10, UpdatedPeopleCount);
            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.Page.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeoplePagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");
            string uriPage1 = $"{GetRecentlyUpdatedPeopleUri}?page=1&limit=10";
            string uriPage2 = $"{GetRecentlyUpdatedPeopleUri}?page=2&limit=10";

            TraktClient client = ModuleTestUtility.GetClient(uriPage1, responseContent, 1, 2, 10, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                null, null, 1, 10, TestContext.Current.CancellationToken);

            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, uriPage2, responseContent, 2, 2, 10, UpdatedPeopleCount);
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
        public async Task TestGetRecentlyUpdatedPeopleThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedPeopleUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecentlyUpdatedPerson>>> act = () => client.People.GetRecentlyUpdatedPeopleAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
