using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there are too many requests during a specific time period.</summary>
    public sealed class TraktApiRateLimitException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                   string? responseContent = null, HttpResponseHeaders? headers = null,
                                                   HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.RateLimitExceeded), Constants.StatusCodes.RateLimitExceeded,
                            httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        // TODO
        ///// <summary>Additional information parameters about the rate limit.</summary>
        //public ITraktRateLimitInfo RateLimitInfo { get; internal set; }

        /// <summary>Amount of time in seconds after which a retry is possible.</summary>
        public int? RetryAfter { get; internal set; }
    }
}
