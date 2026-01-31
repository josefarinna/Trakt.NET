namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncFavoritesRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritesRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritesRemoveRequest();
            request.UriTemplate.Should().Be("sync/favorites/remove");
        }
    }
}
