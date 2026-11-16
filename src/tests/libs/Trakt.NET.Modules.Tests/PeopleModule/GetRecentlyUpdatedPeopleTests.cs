using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetRecentlyUpdatedPeopleTests
    {
        private const string GetRecentlyUpdatedPeopleUri = "people/updates";
        private const uint UpdatedPeopleCount = 2U;
        private const string StartDate = "2026-02-22T17:00:00.000Z";

        [Theory]
        [InlineData(null, null, null, null, GetRecentlyUpdatedPeopleUri)]
        [InlineData(StartDate, null, null, null, $"{GetRecentlyUpdatedPeopleUri}/2026-02-22T17:00:00Z")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetRecentlyUpdatedPeopleUri}?extended=full")]
        [InlineData(null, null, 2U, null, $"{GetRecentlyUpdatedPeopleUri}?page=2")]
        [InlineData(null, null, null, 4U, $"{GetRecentlyUpdatedPeopleUri}?limit=4")]
        [InlineData(StartDate, TraktExtendedInfo.Full, 2U, 4U, $"{GetRecentlyUpdatedPeopleUri}/2026-02-22T17:00:00Z?extended=full&page=2&limit=4")]
        public async Task TestGetRecentlyUpdatedPeople(string? startDate, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\peoplerecentlyupdated.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, UpdatedPeopleCount);

            TraktPagedResponse<TraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(
                startDate is not null ? TestUtility.ParseUTCDateTime(startDate) : null, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)UpdatedPeopleCount);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
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
        public async Task TestGetRecentlyUpdatedPeopleThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedPeopleUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRecentlyUpdatedPerson>>> act = () => client.People.GetRecentlyUpdatedPeopleAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
