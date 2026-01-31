namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryAddRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryAddRequest();
            request.UriTemplate.Should().Be("sync/history");
        }
    }
}
