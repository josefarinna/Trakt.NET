namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncFavoritesAddRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritesAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritesAddRequest();
            request.UriTemplate.Should().Be("sync/favorites");
        }
    }
}
