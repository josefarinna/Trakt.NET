using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a show was not found.</summary>
    public class TraktApiShowNotFoundException(string showId, string message, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                               string? responseContent = null, HttpResponseHeaders? headers = null,
                                               HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiObjectNotFoundException(showId, message, httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        public TraktApiShowNotFoundException(string showId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                             string? responseContent = null, HttpResponseHeaders? headers = null,
                                             HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
            : this(showId, "Show Not Found - method exists, but no record found", httpMethod, requestMessage,
                   responseContent, headers, contentHeaders, innerException)
        {
        }
    }
}
