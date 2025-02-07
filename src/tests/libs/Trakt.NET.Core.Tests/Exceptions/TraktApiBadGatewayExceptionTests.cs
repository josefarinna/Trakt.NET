#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiBadGatewayExceptionTests
    {
        [Fact]
        public async Task TestTraktApiBadGatewayExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.ServiceUnavailableBadGateway, HttpMethod.Get);
            
            var exception = TraktApiException.Create(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.ServiceUnavailableBadGateway);
            exception.ReasonPhrase.ShouldBe("Service Unavailable - server overloaded (try again in 30s) - Bad Gateway");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Service Unavailable - server overloaded (try again in 30s) - Bad Gateway");
        }
    }
}
