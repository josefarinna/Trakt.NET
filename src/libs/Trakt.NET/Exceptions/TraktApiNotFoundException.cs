using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if no result(s) was(were) found for a request.</summary>
    public class TraktApiNotFoundException(string message, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                           string? responseContent = null, HttpResponseHeaders? headers = null,
                                           HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(message, Constants.StatusCodes.NotFound,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        public TraktApiNotFoundException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                         string? responseContent = null, HttpResponseHeaders? headers = null,
                                           HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
            : this(CreateExceptionMessage(Constants.StatusCodes.NotFound), httpMethod, requestMessage, responseContent, headers,
                                          contentHeaders, innerException)
        {
        }
    }
}
