using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is a bad response at an intermediate proxy server.</summary>
    public sealed class TraktApiBadGatewayException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent = null, HttpResponseHeaders? headers = null,
                                                    HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailableBadGateway), Constants.StatusCodes.ServiceUnavailableBadGateway,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
