namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System;

    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Syncs.OAuth")]
    public class SyncWatchlistUpdateRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncWatchlistUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncWatchlistUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistUpdateRequest();
            request.UriTemplate.Should().Be("sync/watchlist");
        }


        [Fact]
        public void Test_SyncWatchlistUpdateRequest_Validate_Throws_Exceptions()
        {
            // request body is null
            var requestMock = new SyncWatchlistUpdateRequest();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
