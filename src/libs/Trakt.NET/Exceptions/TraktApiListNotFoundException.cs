using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a list was not found.</summary>
    public sealed class TraktApiListNotFoundException(string listId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                      string? responseContent = null, HttpResponseHeaders? headers = null,
                                                      HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiObjectNotFoundException(listId, "List Not Found - method exists, but no record found", httpMethod, requestMessage,
                                          responseContent, headers, contentHeaders, innerException)
    {
    }
}
