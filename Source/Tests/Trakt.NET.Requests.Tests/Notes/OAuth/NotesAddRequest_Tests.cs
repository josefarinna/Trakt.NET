namespace TraktNet.Requests.Tests.Notes.OAuth
{
    using FluentAssertions;

    using TraktNet.Requests.Base;
    using TraktNet.Requests.Notes.OAuth;
    using Xunit;

    [Trait("Category", "Requests.Notes.OAuth")]
    public class NotesAddRequest_Tests
    {
        [Fact]
        public void Test_NotesAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new NotesAddRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_NotesAddRequest_Has_Valid_UriTemplate()
        {
            var request = new NotesAddRequest();
            request.UriTemplate.Should().Be("notes");
        }

        [Fact]
        public void Test_NotesAddRequest_Returns_Valid_UriPathParameters()
        {
            var request = new NotesAddRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
