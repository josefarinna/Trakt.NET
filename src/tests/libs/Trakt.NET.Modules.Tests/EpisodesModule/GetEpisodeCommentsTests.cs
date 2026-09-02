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

        [Fact]
        public async Task TestGetEpisodeCommments()
        {
			string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);
            
            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeCommentsUri, responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/comments",
                responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithShowIds()
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
        public async Task TestGetEpisodeCommentsWithSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?page={Page}", responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithSortOrderAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsWithSortOrderAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}", responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithSortOrderAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, ExtendedInfo, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, ExtendedInfo, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithSortOrderAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}&limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, null, ExtendedInfo, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, ExtendedInfo, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsItemCount);
            response.ItemCount.ShouldBe(CommentsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 5, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 1, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetEpisodeCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentsItemCount);

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, CommentSortOrder, null, null, 1, Limit, TestContext.Current.CancellationToken);

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

            TraktPagedResponse<TraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, language: language, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
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
        public async Task TestGetEpisodeCommentsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodecomments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Episodes.GetEpisodeCommentsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeCommentsThrowsArgumentExceptions()
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
