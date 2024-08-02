using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if sent data is not valid.</summary>
    public sealed class TraktApiValidationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent = null, HttpResponseHeaders? headers = null,
                                                    HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ValidationError), Constants.StatusCodes.ValidationError,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
