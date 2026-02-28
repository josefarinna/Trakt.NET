using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonListsTests
    {
        private const string GetSeasonListsUriPrefix = "shows";
        private const string GetSeasonListsUriSuffix = "lists";
        private const uint SeasonNumber = 1U;
        private const string GetSeasonListsUriWithSlug = GetSeasonListsUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/seasons/1/" + GetSeasonListsUriSuffix;
        private static readonly string GetSeasonListsUri = $"{GetSeasonListsUriPrefix}/{TestConstants.Shows.ShowID}/seasons/1/{GetSeasonListsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, null, GetSeasonListsUriWithSlug, "Seasons\\seasonlists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, GetSeasonListsUriWithSlug, "Seasons\\seasonlists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetSeasonListsUriWithSlug}?extended=full", "Seasons\\seasonlists.json")]
        [InlineData(null, null, null, 4U, null, $"{GetSeasonListsUriWithSlug}?page=4", "Seasons\\seasonlists.json")]
        [InlineData(null, null, null, null, 20U, $"{GetSeasonListsUriWithSlug}?limit=20", "Seasons\\seasonlists.json")]
        [InlineData(TraktListType.Personal, TraktListSortOrder.Popular, TraktExtendedInfo.Full, 4U, 20U, $"{GetSeasonListsUriWithSlug}/personal/popular?extended=full&page=4&limit=20", "Seasons\\seasonlists.json")]
        public async Task TestGetSeasonLists(TraktListType? type, TraktListSortOrder? sortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowSlug, SeasonNumber, type, sortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1U, limit ?? 10U);
        }

        [Fact]
        public async Task TestGetSeasonListsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonListsUri, responseContent);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowID, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonListsUriWithSlug, responseContent);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktList> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            IReadOnlyList<TraktList> lists = response.Content!;

            lists[0].ShouldNotBeNull();
            lists[0].Name.ShouldBe("IMDB: Top Rated TV Shows");
            lists[0].Description.ShouldStartWith("Top 250 TV Shows");
            lists[0].Likes.ShouldBe(3464u);
            lists[0].IDs!.Trakt.ShouldBe(2143363U);
            lists[0].User!.Username.ShouldBe("justin");

            lists[1].ShouldNotBeNull();
            lists[1].Name.ShouldBe("Trending Shows");
            lists[1].Type.ShouldBe(TraktListType.Personal);
            lists[1].UpdatedAt.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonListsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowSlug, SeasonNumber, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.HasNextPage.ShouldBe(true);

            ModuleTestUtility.SetClient(client, $"{GetSeasonListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.Page.ShouldBe(2U);
            ValidateResponse(response, 2U, 10U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonListsUriWithSlug, statusCode);

            try
            {
                await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonListsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Seasons.GetSeasonListsAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonListsAsync(ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
