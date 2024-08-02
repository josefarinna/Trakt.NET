using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an object was not found.</summary>
    public class TraktApiObjectNotFoundException(string objectId, string message, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                 string? responseContent = null, HttpResponseHeaders? headers = null,
                                                 HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiNotFoundException(message, httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        public TraktApiObjectNotFoundException(string objectId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                               string? responseContent = null, HttpResponseHeaders? headers = null,
                                               HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
            : this(objectId, "Object Not Found - method exists, but no record found", httpMethod, requestMessage,
                   responseContent, headers, contentHeaders, innerException)
        {
        }

        public string ObjectId { get; } = objectId;
    }
}
