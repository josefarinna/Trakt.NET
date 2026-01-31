namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;

    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Trait("Category", "PostBuilder")]
    public partial class TraktPost_SyncRatingsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
