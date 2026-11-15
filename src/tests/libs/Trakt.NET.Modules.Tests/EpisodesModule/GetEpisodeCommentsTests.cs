using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeCommentsTests
    {
        private const string GetEpisodeCommentsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/comments";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint CommentsItemCount = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const TraktCommentSortOrder CommentSortOrder = TraktCommentSortOrder.Likes;

        [Theory]
        [InlineData(null, null, null, null, GetEpisodeCommentsUri)]
        [InlineData(CommentSortOrder, null, null, null, $"{GetEpisodeCommentsUri}/likes")]
        [InlineData(null, ExtendedInfo, null, null, $"{GetEpisodeCommentsUri}?extended=full")]
        [InlineData(null, null, Page, null, $"{GetEpisodeCommentsUri}?page=2")]
        [InlineData(null, null, null, Limit, $"{GetEpisodeCommentsUri}?limit=4")]
        [InlineData(CommentSortOrder, ExtendedInfo, Page, Limit, $"{GetEpisodeCommentsUri}/likes?extended=full&page=2&limit=4")]
        public async Task TestGetEpisodeCommentsWithID(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/comments",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/comments",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/comments",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 5, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData("es", $"{GetEpisodeCommentsUri}?language=es", "Episodes\\episodecomments.json")]
        [InlineData("en", $"{GetEpisodeCommentsUri}?language=en", "Episodes\\episodecomments.json")]
        public async Task TestGetEpisodeCommentsWithLanguage(string language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, language: language, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeCommentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeCommentsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Episodes.GetEpisodeCommentsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeCommentsAsync(default(TraktShow)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeCommentsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeCommentsAsync(0, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
