using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an error on the Cloudflare server side.</summary>
    public sealed class TraktApiCloudflareException(HttpStatusCode httpStatusCode, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent = null, HttpResponseHeaders? headers = null,
                                                    HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(httpStatusCode), httpStatusCode, httpMethod, requestMessage, responseContent,
                                                   headers, contentHeaders, innerException)
    {
    }
}
