using System.Net;

namespace TraktNET
{
    public partial class TraktApiException
    {
        internal static TraktApiException Create(ExceptionParameters parameters, Exception? innerException = null)
            => parameters.StatusCode switch
            {
                Constants.StatusCodes.BadRequest => new TraktApiBadRequestException(parameters, innerException),
                Constants.StatusCodes.Unauthorized => new TraktApiAuthorizationException(parameters, innerException),
                Constants.StatusCodes.Forbidden => new TraktApiForbiddenException(parameters, innerException),
                Constants.StatusCodes.NotFound => new TraktApiNotFoundException(parameters, innerException),
                Constants.StatusCodes.MethodNotFound => new TraktApiMethodNotFoundException(parameters, innerException),
                Constants.StatusCodes.Conflict => new TraktApiConflictException(parameters, innerException),
                Constants.StatusCodes.Denied => new TraktApiDeniedException(parameters, innerException),
                Constants.StatusCodes.PreconditionFailed => new TraktApiPreconditionFailedException(parameters, innerException),
                Constants.StatusCodes.AccountLimitExceeded => new TraktApiAccountLimitException(parameters, innerException),
                Constants.StatusCodes.ValidationError => new TraktApiValidationException(parameters, innerException),
                Constants.StatusCodes.LockedUserAccount => new TraktApiLockedUserAccountException(parameters, innerException),
                Constants.StatusCodes.VIPValidationError => new TraktApiVIPValidationException(parameters, innerException),
                Constants.StatusCodes.RateLimitExceeded => new TraktApiRateLimitException(parameters, innerException),
                Constants.StatusCodes.ServerError => new TraktApiServerException(parameters, innerException),
                Constants.StatusCodes.ServiceUnavailableBadGateway => new TraktApiBadGatewayException(parameters, innerException),
                Constants.StatusCodes.ServiceUnavailable => new TraktApiServerUnavailableException(parameters, innerException),
                Constants.StatusCodes.ServiceUnavailableGatewayTimeout => new TraktApiGatewayTimeoutException(parameters, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError520 => new TraktApiCloudflareException(parameters, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError521 => new TraktApiCloudflareException(parameters, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError522 => new TraktApiCloudflareException(parameters, innerException),
                _ => new TraktApiException(parameters, innerException),
            };

        internal TraktApiException(ExceptionParameters parameters, Exception? innerException = null)
            : base(CreateExceptionMessage(parameters.StatusCode), innerException)
        {
            StatusCode = parameters.StatusCode;
            ReasonPhrase = CreateReasonPhrase(parameters.StatusCode);
            HttpMethod = parameters.Method;
            RequestMessage = parameters.Request;
            ResponseContent = parameters.ResponseContent;
            Headers = parameters.Headers;
            ContentHeaders = parameters.ContentHeaders;
        }

        internal TraktApiException(string exceptionMessage, ExceptionParameters parameters, Exception? innerException = null)
            : base(CreateExceptionMessage(exceptionMessage), innerException)
        {
            StatusCode = parameters.StatusCode;
            ReasonPhrase = exceptionMessage;
            HttpMethod = parameters.Method;
            RequestMessage = parameters.Request;
            ResponseContent = parameters.ResponseContent;
            Headers = parameters.Headers;
            ContentHeaders = parameters.ContentHeaders;
        }

        protected static string CreateExceptionMessage(string message) => $"Trakt API request failed. {message}";

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
