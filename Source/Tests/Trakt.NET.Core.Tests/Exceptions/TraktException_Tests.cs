namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using TraktNet.Exceptions;
    using Xunit;

    [Trait("Category", "Exceptions")]
    public class TraktException_Tests
    {
        [Fact]
        public void Test_TraktException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
            exception.ServerReasonPhrase.Should().BeNullOrEmpty();
        }
    }
}
