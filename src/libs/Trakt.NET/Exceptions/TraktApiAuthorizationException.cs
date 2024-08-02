using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an access token is required, but was not provided.</summary>
    public sealed class TraktApiAuthorizationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                       string? responseContent = null, HttpResponseHeaders? headers = null,
                                                       HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Unauthorized), Constants.StatusCodes.Unauthorized,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
