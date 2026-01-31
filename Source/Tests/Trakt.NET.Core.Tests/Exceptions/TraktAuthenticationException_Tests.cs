namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using TraktNet.Exceptions;
    using Xunit;

    [Trait("Category", "Exceptions")]
    public class TraktAuthenticationException_Tests
    {
        [Fact]
        public void Test_TraktAuthenticationException_DefaultConstructor()
        {
            const string message = "exception message";

            var exception = new TraktAuthenticationException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
