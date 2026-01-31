namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncCollectionRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionRemoveRequest();
            request.UriTemplate.Should().Be("sync/collection/remove");
        }
    }
}
