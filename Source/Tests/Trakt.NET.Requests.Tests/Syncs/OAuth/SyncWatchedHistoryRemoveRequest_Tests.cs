namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryRemoveRequest();
            request.UriTemplate.Should().Be("sync/history/remove");
        }
    }
}
