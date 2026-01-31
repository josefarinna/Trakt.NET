namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;

    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Trait("Category", "PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_Empty_Build()
        {
            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
