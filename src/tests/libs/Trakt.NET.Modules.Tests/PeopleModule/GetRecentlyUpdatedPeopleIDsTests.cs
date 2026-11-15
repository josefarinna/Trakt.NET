using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetRecentlyUpdatedPeopleIDsTests
    {
        private const string GetRecentlyUpdatedPeopleIdsUri = "people/updates/id";
        private const uint UpdatedIdsCount = 4U;
        private const string StartDate = "2026-02-22T17:00:00.000Z";

        [Theory]
        [InlineData(null, null, null, GetRecentlyUpdatedPeopleIdsUri)]
        [InlineData(StartDate, null, null, $"{GetRecentlyUpdatedPeopleIdsUri}/2026-02-22T17:00:00Z")]
        [InlineData(null, 2U, null, $"{GetRecentlyUpdatedPeopleIdsUri}?page=2")]
        [InlineData(null, null, 4U, $"{GetRecentlyUpdatedPeopleIdsUri}?limit=4")]
        [InlineData(StartDate, 2U, 4U, $"{GetRecentlyUpdatedPeopleIdsUri}/2026-02-22T17:00:00Z?page=2&limit=4")]
        public async Task TestGetRecentlyUpdatedPeopleIDs(string? startDate, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdatedids.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, UpdatedIdsCount);

            TraktPagedResponse<uint> response = await client.People.GetRecentlyUpdatedPeopleIDsAsync(
                startDate is not null ? TestUtility.ParseUTCDateTime(startDate) : null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedIdsCount);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
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
        public async Task TestGetRecentlyUpdatedPeopleIdsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedPeopleIdsUri, statusCode);

            Func<Task<TraktPagedResponse<uint>>> act = () => client.People.GetRecentlyUpdatedPeopleIDsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
