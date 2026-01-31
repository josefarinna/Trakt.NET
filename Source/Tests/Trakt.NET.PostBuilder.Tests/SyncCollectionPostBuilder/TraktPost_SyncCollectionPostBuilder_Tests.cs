namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;

    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Trait("Category", "PostBuilder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_Empty_Build()
        {
            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
