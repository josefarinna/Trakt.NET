using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the request parameters are not valid.</summary>
    public sealed class TraktApiPreconditionFailedException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                            string? responseContent = null, HttpResponseHeaders? headers = null,
                                                            HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.PreconditionFailed), Constants.StatusCodes.PreconditionFailed,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
    }
}
