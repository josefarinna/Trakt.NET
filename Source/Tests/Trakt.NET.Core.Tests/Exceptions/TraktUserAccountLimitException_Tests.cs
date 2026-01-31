namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using TraktNet.Exceptions;
    using Xunit;

    [Trait("Category", "Exceptions")]
    public class TraktUserAccountLimitException_Tests
    {
        [Fact]
        public void Test_TraktUserAccountLimitException_DefaultConstructor()
        {
            var exception = new TraktUserAccountLimitException();

            exception.Message.Should().Be("Exceeded account limit - user has exceeded their account limit");
            exception.StatusCode.Should().Be((HttpStatusCode)420);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktUserAccountLimitException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktUserAccountLimitException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be((HttpStatusCode)420);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
