using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the user denied the OAuth authentication.</summary>
    public sealed class TraktApiDeniedException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                string? responseContent = null, HttpResponseHeaders? headers = null,
                                                HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Denied), Constants.StatusCodes.Denied,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
