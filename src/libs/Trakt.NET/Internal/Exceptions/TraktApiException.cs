using Microsoft.VisualBasic;
using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    public partial class TraktApiException
    {
        internal static TraktApiException Create(HttpStatusCode httpStatusCode, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                 string? responseContent = null, HttpResponseHeaders? headers = null, HttpContentHeaders? contentHeaders = null,
                                                 Exception? innerException = null)
            => httpStatusCode switch
            {
                Constants.StatusCodes.BadRequest => new TraktApiBadRequestException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.Unauthorized => new TraktApiAuthorizationException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.Forbidden => new TraktApiForbiddenException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.NotFound => new TraktApiNotFoundException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.MethodNotFound => new TraktApiMethodNotFoundException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.Conflict => new TraktApiConflictException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.Denied => new TraktApiDeniedException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.PreconditionFailed => new TraktApiPreconditionFailedException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.AccountLimitExceeded => new TraktApiAccountLimitException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ValidationError => new TraktApiValidationException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.LockedUserAccount => new TraktApiLockedUserAccountException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.VIPValidationError => new TraktApiVIPValidationException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.RateLimitExceeded => new TraktApiRateLimitException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServerError => new TraktApiServerException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServiceUnavailableBadGateway => new TraktApiBadGatewayException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServiceUnavailable => new TraktApiServerUnavailableException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServiceUnavailableGatewayTimeout => new TraktApiGatewayTimeoutException(httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError520 => new TraktApiCloudflareException(httpStatusCode, httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError521 => new TraktApiCloudflareException(httpStatusCode, httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError522 => new TraktApiCloudflareException(httpStatusCode, httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException),
                _ => new TraktApiException(CreateExceptionMessage(httpStatusCode), httpStatusCode, httpMethod, requestMessage, responseContent,
                                           headers, contentHeaders, innerException),
            };

        protected TraktApiException(string exceptionMessage, HttpStatusCode httpStatusCode, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                    string? responseContent = null, HttpResponseHeaders? headers = null, HttpContentHeaders? contentHeaders = null,
                                    Exception? innerException = null)
            : base(exceptionMessage, innerException)
        {
            StatusCode = httpStatusCode;
            ReasonPhrase = CreateReasonPhrase(httpStatusCode);
            HttpMethod = httpMethod;
            RequestMessage = requestMessage;
            ResponseContent = responseContent;
            Headers = headers;
            ContentHeaders = contentHeaders;
        }

        protected static string CreateExceptionMessage(HttpStatusCode httpStatusCode) => $"Trakt API request failed. {CreateReasonPhrase(httpStatusCode)}";

        protected static string CreateReasonPhrase(HttpStatusCode httpStatusCode)
            => httpStatusCode switch
            {
                Constants.StatusCodes.BadRequest => "Bad Request - request couldn't be parsed",
                Constants.StatusCodes.Unauthorized => "Unauthorized - OAuth must be provided",
                Constants.StatusCodes.Forbidden => "Forbidden - invalid API key or unapproved app",
                Constants.StatusCodes.NotFound => "Not Found - method exists, but no record found",
                Constants.StatusCodes.MethodNotFound => "Method Not Found - method doesn't exist",
                Constants.StatusCodes.Conflict => "Conflict - resource already created",
                Constants.StatusCodes.Denied => "Denied - user explicitly denied this code",
                Constants.StatusCodes.PreconditionFailed => "Precondition Failed - use application/json content type",
                Constants.StatusCodes.AccountLimitExceeded => "Account Limit Exceeded - list count, item count, etc",
                Constants.StatusCodes.ValidationError => "Unprocessable Entity - validation errors",
                Constants.StatusCodes.LockedUserAccount => "Locked User Account - have the user contact support",
                Constants.StatusCodes.VIPValidationError => "VIP Only - user must upgrade to VIP",
                Constants.StatusCodes.RateLimitExceeded => "Rate Limit Exceeded",
                Constants.StatusCodes.ServerError => "Server Error - please open a support ticket",
                Constants.StatusCodes.ServiceUnavailableBadGateway => "Service Unavailable - server overloaded (try again in 30s) - Bad Gateway",
                Constants.StatusCodes.ServiceUnavailable => "Service Unavailable - server overloaded (try again in 30s)",
                Constants.StatusCodes.ServiceUnavailableGatewayTimeout => "Service Unavailable - server overloaded (try again in 30s) - Gateway Timeout",
                Constants.StatusCodes.ServiceUnavailableCloudflareError520 => "Service Unavailable - Cloudflare error - Status Code 520",
                Constants.StatusCodes.ServiceUnavailableCloudflareError521 => "Service Unavailable - Cloudflare error - Status Code 521",
                Constants.StatusCodes.ServiceUnavailableCloudflareError522 => "Service Unavailable - Cloudflare error - Status Code 522",
                _ => $"Response status code does not indicate success: {(int)httpStatusCode}"
            };
    }
}
