using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeListsTests
    {
        private readonly string GetEpisodeListsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/lists";
        private readonly string ShowID = $"{TestConstants.Shows.ShowID}";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ListItemCount = 10U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const TraktListSortOrder ListSortOrder = TraktListSortOrder.Comments;
        private const TraktListType ListType = TraktListType.Official;

        [Fact]
        public async Task TestGetEpisodeLists()
        {
			string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeListsUri, responseContent, 1, 1, 10, ListItemCount);

			TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/lists",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/lists",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/lists",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithShowIds()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/lists",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/lists",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}",
                                                           responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithSortOrderAndWithoutType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListSortOrder.ToURI()}",
                                                           responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, ListSortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}?extended={ExtendedInfo.ToURI()}",
                                                           responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}?page={Page}",
                                                           responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}?limit={Limit}",
                                                           responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}",
                                                           responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}/{ListType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}?page={Page}",
                                                           responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}?limit={Limit}",
                                                           responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}?page={Page}&limit={Limit}",
                                                           responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithSortOrderAndExtendedInfoAndWithoutType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListSortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}",
                                                           responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, ListSortOrder, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithSortOrderAndPageAndWithoutType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListSortOrder.ToURI()}?page={Page}",
                                                           responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, ListSortOrder, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithSortOrderAndLimitAndWithoutType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListSortOrder.ToURI()}?limit={Limit}",
                                                           responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, ListSortOrder, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithSortOrderPageAndLimitAndWithoutType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListSortOrder.ToURI()}?page={Page}&limit={Limit}",
                                                           responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, ListSortOrder, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}?page={Page}&limit={Limit}",
                                                           responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrderAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrderAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page={Page}",
                                                           responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrderAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?limit={Limit}",
                                                           responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrderAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrderAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsWithTypeAndSortOrderAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType, ListSortOrder, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetEpisodeListsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}",
                                                           responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType,
                                                                                                 ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetEpisodeListsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}",
                                                           responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType,
                                                                                                 ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetEpisodeListsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}",
                                                           responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType,
                                                                                                 ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetEpisodeListsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}",
                                                           responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType,
                                                                                                 ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetEpisodeListsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}",
                                                           responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType,
                                                                                                 ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}",
                                        responseContent, 1, 2, Limit, ListItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetEpisodeListsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodelists.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}",
                                                           responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, ListType,
                                                                                                 ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetEpisodeListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}",
                                        responseContent, 2, 2, Limit, ListItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
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
        public async Task TestGetEpisodeListsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeListsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeListsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeListsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeListsAsync(default(TraktShow)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeListsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeListsAsync(0, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
