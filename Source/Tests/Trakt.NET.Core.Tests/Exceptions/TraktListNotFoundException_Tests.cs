namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using TraktNet.Exceptions;
    using Xunit;

    [Trait("Category", "Exceptions")]
    public class TraktListNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktListNotFoundException_DefaultConstructor()
        {
            const string listId = "list id";

            var exception = new TraktListNotFoundException(listId);

            exception.Message.Should().Be("List Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(listId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktListNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string listId = "list id";

            var exception = new TraktListNotFoundException(message, listId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(listId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
