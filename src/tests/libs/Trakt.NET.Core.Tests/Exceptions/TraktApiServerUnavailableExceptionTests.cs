namespace TraktNET.Exceptions
{
    public class TraktApiServerUnavailableExceptionTests
    {
        [Fact]
        public async Task TestTraktApiServerUnavailableExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.ServiceUnavailable, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailable);
            exception.ReasonPhrase.Should().Be("Service Unavailable - server overloaded (try again in 30s)");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - server overloaded (try again in 30s)");
        }
    }
}
