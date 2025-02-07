using System.Net;

#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiExceptionTests
    {
        [Fact]
        public async Task TestTraktApiExceptionCreate()
        {
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
            var httpStatusCode = (HttpStatusCode)451;
#else
            HttpStatusCode httpStatusCode = HttpStatusCode.UnavailableForLegalReasons;
#endif

            // Test with a random unused status code
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                httpStatusCode, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(httpStatusCode);
            exception.ReasonPhrase.ShouldBe("Response status code does not indicate success: 451");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Response status code does not indicate success: 451");
        }
    }
}
