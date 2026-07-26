using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchedEpisodesTests
    {
        private const string GetWatchedEpisodesUri = $"users/{Username}/watched/episodes";
        private const string Username = "sean";
        private const uint Page = 1U;
        private const uint Limit = 10U;
        private const uint EpisodesCount = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetWatchedEpisodes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchedEpisodesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, EpisodesCount);
            TraktPagedResponse<TraktWatchedEpisode> response = await client.Users.GetWatchedEpisodesAsync(Username, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, EpisodesCount);
            TraktPagedResponse<TraktWatchedEpisode> response = await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchedEpisodesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktWatchedEpisode>>> act = () => client.Users.GetWatchedEpisodesAsync(Username, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetWatchedEpisodesAsync(Username, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
