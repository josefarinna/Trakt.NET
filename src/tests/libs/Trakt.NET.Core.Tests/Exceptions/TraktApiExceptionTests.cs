using System.Net;

#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiExceptionTests
    {
        [Fact]
        public async Task TestTraktApiExceptionCreate()
        {
#if TRAKT_OLDER_NET_TARGETS
            var httpStatusCode = (HttpStatusCode)451;
#else
            HttpStatusCode httpStatusCode = HttpStatusCode.UnavailableForLegalReasons;
#endif

            // Test with a random unused status code
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                httpStatusCode, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(httpStatusCode);
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
