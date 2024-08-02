using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the authorized user does not have VIP support.</summary>
    public sealed class TraktApiVIPValidationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                       string? responseContent = null, HttpResponseHeaders? headers = null,
                                                       HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.VIPValidationError), Constants.StatusCodes.VIPValidationError,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        /// <summary>URL where the user can sign up for Trakt VIP.</summary>
        public string? UpgradeURL { get; internal set; }
    }
}
