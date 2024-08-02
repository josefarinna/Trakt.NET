using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a user has exceeded their account limits.</summary>
    public sealed class TraktApiAccountLimitException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                      string? responseContent = null, HttpResponseHeaders? headers = null,
                                                      HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.AccountLimitExceeded), Constants.StatusCodes.AccountLimitExceeded,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        /// <summary>URL where the user can sign up for Trakt VIP.</summary>
        public string? UpgradeURL { get; internal set; }

        /// <summary>User's VIP status.</summary>
        public bool? IsVIPUser { get; internal set; }

        /// <summary>User's account limit.</summary>
        public int? AccountLimit { get; internal set; }
    }
}
