namespace TraktNET.Exceptions
{
    public class TraktApiValidationExceptionTests
    {
        [Fact]
        public void TestTraktApiValidationExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ValidationError, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ValidationError);
            exception.ReasonPhrase.Should().Be("Unprocessable Entity - validation errors");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Unprocessable Entity - validation errors");
        }
    }
}
