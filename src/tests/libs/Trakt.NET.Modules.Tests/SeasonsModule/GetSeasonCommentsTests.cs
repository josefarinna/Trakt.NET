using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonCommentsTests
    {
        private const string GetSeasonCommentsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/comments";
        private const uint SeasonNr = 1U;
        private const uint ItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private readonly TraktCommentSortOrder CommentSortOrder = TraktCommentSortOrder.Likes;

        [Theory]
        [InlineData(null, null, null, null, GetSeasonCommentsUri)]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetSeasonCommentsUri}/likes")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetSeasonCommentsUri}?extended=full")]
        [InlineData(null, null, Page, null, $"{GetSeasonCommentsUri}?page=2")]
        [InlineData(null, null, null, Limit, $"{GetSeasonCommentsUri}?limit=4")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, Page, Limit, $"{GetSeasonCommentsUri}/likes?extended=full&page=2&limit=4")]
        public async Task TestGetSeasonCommentsWithID(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, commentSortOrder, extendedInfo,
                null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/comments", responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.ShowSlug, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/comments", responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/comments", responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetSeasonCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData("es", $"{GetSeasonCommentsUri}?language=es", "Seasons\\seasoncomments.json")]
        [InlineData("en", $"{GetSeasonCommentsUri}?language=en", "Seasons\\seasoncomments.json")]
        public async Task TestGetSeasonCommentsWithLanguage(string language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, language: language, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonCommentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonCommentsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(default(TraktShowIDs)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonCommentsAsync(default(TraktShow)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonCommentsAsync(new TraktShowIDs(), SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonCommentsAsync(0, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
