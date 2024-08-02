using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>
    /// Exception, that will be thrown, if there is a conflict on the server.
    /// For example, if a resource, e.g. a comment, already exists.
    /// </summary>
    public sealed class TraktApiConflictException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                  string? responseContent = null, HttpResponseHeaders? headers = null,
                                                  HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Conflict), Constants.StatusCodes.Conflict,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
