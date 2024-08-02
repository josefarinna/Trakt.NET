using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a method is not allowed or not existing.</summary>
    public sealed class TraktApiMethodNotFoundException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent = null, HttpResponseHeaders? headers = null,
                                                        HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.MethodNotFound), Constants.StatusCodes.MethodNotFound,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
