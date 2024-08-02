using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an timed out intermediate proxy server while waiting for a response.</summary>
    public sealed class TraktApiGatewayTimeoutException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent = null, HttpResponseHeaders? headers = null,
                                                        HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailableGatewayTimeout), Constants.StatusCodes.ServiceUnavailableGatewayTimeout,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
