namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncCollectionAddRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionAddRequest();
            request.UriTemplate.Should().Be("sync/collection");
        }
    }
}
