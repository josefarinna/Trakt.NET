namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using TraktNet.Exceptions;
    using Xunit;

    [Trait("Category", "Exceptions")]
    public class TraktRateLimitException_Tests
    {
        [Fact]
        public void Test_TraktRateLimitException_DefaultConstructor()
        {
            var exception = new TraktRateLimitException();

            exception.Message.Should().Be("Slow Down - your app is polling too quickly");
            exception.StatusCode.Should().Be((HttpStatusCode)429);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktRateLimitException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktRateLimitException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be((HttpStatusCode)429);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
