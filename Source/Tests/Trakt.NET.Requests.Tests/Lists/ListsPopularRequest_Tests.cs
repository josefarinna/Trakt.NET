namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;

    using TraktNet.Requests.Lists;
    using Xunit;

    [Trait("Category", "Requests.Lists")]
    public class ListsPopularRequest_Tests
    {
        [Fact]
        public void Test_ListsPopularRequest_Has_Valid_UriTemplate()
        {
            var request = new ListsPopularRequest();
            request.UriTemplate.Should().Be("lists/popular{?extended,page,limit}");
        }
    }
}
