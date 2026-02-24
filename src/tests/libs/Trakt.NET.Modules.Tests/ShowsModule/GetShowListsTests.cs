using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowListsTests
    {
        private const string GetShowListsUriPrefix = "shows";
        private const string GetShowListsUriSuffix = "lists";
        private const string GetShowListsUriWithSlug = GetShowListsUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + GetShowListsUriSuffix;
        private static readonly string GetShowListsUri = $"{GetShowListsUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowListsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, null, GetShowListsUriWithSlug, "Shows\\showlists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, GetShowListsUriWithSlug, "Shows\\showlists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetShowListsUriWithSlug}?extended=full", "Shows\\showlists.json")]
        [InlineData(null, null, null, 4U, null, $"{GetShowListsUriWithSlug}?page=4", "Shows\\showlists.json")]
        [InlineData(null, null, null, null, 20U, $"{GetShowListsUriWithSlug}?limit=20", "Shows\\showlists.json")]
        [InlineData(TraktListType.Personal, TraktListSortOrder.Popular, TraktExtendedInfo.Full, 4U, 20U, $"{GetShowListsUriWithSlug}/personal/popular?extended=full&page=4&limit=20", "Shows\\showlists.json")]
        public async Task TestGetShowLists(TraktListType? type, TraktListSortOrder? sortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, type, sortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1U, limit ?? 10U);
        }

        [Fact]
        public async Task TestGetShowListsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUri, responseContent);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        [Fact]
        public async Task TestGetShowListsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, responseContent);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktList> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2); // El mock tiene 2 listas
            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            IReadOnlyList<TraktList> lists = response.Content!;

            // Primera lista: IMDB Top Rated
            lists[0].ShouldNotBeNull();
            lists[0].Name.ShouldBe("IMDB: Top Rated TV Shows");
            lists[0].Description.ShouldStartWith("Top 250 TV shows");
            lists[0].Likes.ShouldBe(3464u);
            lists[0].IDs!.Trakt.ShouldBe(2143363U);
            lists[0].User!.Username.ShouldBe("justin");

            // Segunda lista: Trending Shows
            lists[1].ShouldNotBeNull();
            lists[1].Name.ShouldBe("Trending Shows");
            lists[1].Type.ShouldBe(TraktListType.Personal);
            lists[1].UpdatedAt.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowListsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.HasNextPage.ShouldBe(true);

            ModuleTestUtility.SetClient(client, $"{GetShowListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.Page.ShouldBe(2U);
            ValidateResponse(response, 2U, 10U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowListsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Shows.GetShowListsAsync(default(TraktShowIDs));
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowListsAsync(showIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
