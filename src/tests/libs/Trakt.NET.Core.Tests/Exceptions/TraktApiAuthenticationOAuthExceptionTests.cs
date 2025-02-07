#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiAuthenticationOAuthExceptionTests
    {
        [Fact]
        public async Task TestTraktApiAuthenticationOAuthExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.NotFound, HttpMethod.Get);

            var exception = new TraktApiAuthenticationOAuthException("Resource not found", parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.ShouldBe("Resource not found");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Resource not found");
        }
    }
}
