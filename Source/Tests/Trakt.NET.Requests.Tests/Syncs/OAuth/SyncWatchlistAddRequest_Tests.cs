namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncWatchlistAddRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistAddRequest();
            request.UriTemplate.Should().Be("sync/watchlist");
        }
    }
}
