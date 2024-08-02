using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the request is forbidden.</summary>
    public sealed class TraktApiForbiddenException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                   string? responseContent = null, HttpResponseHeaders? headers = null,
                                                   HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Forbidden), Constants.StatusCodes.Forbidden,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
