namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Users.OAuth")]
    public class UserHiddenItemsAddRequest_Tests
    {
        [Fact]
        public void Test_UserHiddenItemsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new UserHiddenItemsAddRequest();
            request.UriTemplate.Should().Be("users/hidden/{section}");
        }
    }
}
