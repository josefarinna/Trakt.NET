using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a comment was not found.</summary>
    public sealed class TraktApiCommentNotFoundException(string commentId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                         string? responseContent = null, HttpResponseHeaders? headers = null,
                                                         HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiObjectNotFoundException(commentId, "Comment Not Found - method exists, but no record found", httpMethod, requestMessage,
                                          responseContent, headers, contentHeaders, innerException)
    {
    }
}
