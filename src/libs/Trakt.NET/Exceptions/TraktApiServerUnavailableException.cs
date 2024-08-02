using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the server is unavailable.</summary>
    public sealed class TraktApiServerUnavailableException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                           string? responseContent = null, HttpResponseHeaders? headers = null,
                                                           HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailable), Constants.StatusCodes.ServiceUnavailable,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
