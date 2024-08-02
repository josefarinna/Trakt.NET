using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an user was not found.</summary>
    public sealed class TraktApiUserNotFoundException(string userId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                      string? responseContent = null, HttpResponseHeaders? headers = null,
                                                      HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiObjectNotFoundException(userId, "User Not Found - method exists, but no record found", httpMethod, requestMessage,
                                          responseContent, headers, contentHeaders, innerException)
    {
    }
}
