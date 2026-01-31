namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncWatchlistRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistRemoveRequest();
            request.UriTemplate.Should().Be("sync/watchlist/remove");
        }
    }
}
