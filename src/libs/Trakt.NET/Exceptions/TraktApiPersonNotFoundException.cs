using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a person was not found.</summary>
    public sealed class TraktApiPersonNotFoundException(string personId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent = null, HttpResponseHeaders? headers = null,
                                                        HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiObjectNotFoundException(personId, "Person Not Found - method exists, but no record found", httpMethod, requestMessage,
                                          responseContent, headers, contentHeaders, innerException)
    {
    }
}
