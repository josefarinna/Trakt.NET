namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;

    using TraktNet.Requests.Comments;
    using Xunit;

    [Trait("Category", "Requests.Comments")]
    public class CommentsRecentRequest_Tests
    {
        [Fact]
        public void Test_CommentsRecentRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentsRecentRequest();
            request.UriTemplate.Should().Be("comments/recent{/comment_type}{/object_type}{?include_replies,extended,page,limit}");
        }
    }
}
