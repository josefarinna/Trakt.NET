using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetRecentlyUpdatedPeopleIDsTests
    {
        private const string GetRecentlyUpdatedPeopleIdsUri = "people/updates/id";
        private const uint UpdatedIdsCount = 4U;
        private static readonly DateTime Today = DateTime.UtcNow;

        [Theory]
        // useStartDate | page | limit | expectedUri
        [InlineData(false, null, null, GetRecentlyUpdatedPeopleIdsUri)]
        [InlineData(true, null, null, "people/updates/id/today")]
        [InlineData(false, 2U, null, $"{GetRecentlyUpdatedPeopleIdsUri}?page=2")]
        [InlineData(false, null, 4U, $"{GetRecentlyUpdatedPeopleIdsUri}?limit=4")]
        [InlineData(true, 2U, null, "people/updates/id/today?page=2")]
        [InlineData(true, null, 4U, "people/updates/id/today?limit=4")]
        [InlineData(false, 2U, 4U, $"{GetRecentlyUpdatedPeopleIdsUri}?page=2&limit=4")]
        [InlineData(true, 2U, 4U, "people/updates/id/today?page=2&limit=4")]
        public async Task TestGetRecentlyUpdatedPeopleIdsParametrized(bool useStartDate, uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personrecentlyupdatedids.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            DateTime? startDate = null;
            string finalExpectedUri = expectedUri;

            if (useStartDate)
            {
                startDate = Today;
                finalExpectedUri = expectedUri.Replace("today", $"{Today:yyyy-MM-ddTHH:00:00Z}");
            }

            TraktClient client = ModuleTestUtility.GetClient(finalExpectedUri, responseContent, expectedPage, 1, expectedLimit, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                startDate, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(expectedPage);
            response.Limit.ShouldBe(expectedLimit);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedPeopleIdsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personrecentlyupdatedids.json");
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
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personrecentlyupdatedids.json");
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
