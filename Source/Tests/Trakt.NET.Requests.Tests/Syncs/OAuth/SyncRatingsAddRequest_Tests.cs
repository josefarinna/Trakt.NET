namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncRatingsAddRequest_Tests
    {
        [Fact]
        public void Test_SyncRatingsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRatingsAddRequest();
            request.UriTemplate.Should().Be("sync/ratings");
        }
    }
}
