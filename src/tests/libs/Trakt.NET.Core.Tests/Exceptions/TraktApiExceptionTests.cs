using System.Net;

namespace TraktNET.Exceptions
{
    public class TraktApiExceptionTests
    {
        [Fact]
        public async Task TestTraktApiExceptionCreate()
        {
            // Test with a random unused status code
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                HttpStatusCode.UnavailableForLegalReasons, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(HttpStatusCode.UnavailableForLegalReasons);
            exception.ReasonPhrase.Should().Be("Response status code does not indicate success: 451");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Response status code does not indicate success: 451");
        }
    }
}
