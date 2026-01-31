namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncLastActivitiesRequest_Tests
    {
        [Fact]
        public void Test_SyncLastActivitiesRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncLastActivitiesRequest();
            request.UriTemplate.Should().Be("sync/last_activities");
        }
    }
}
