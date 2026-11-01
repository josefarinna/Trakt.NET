using System.Text;

namespace TraktNET
{
    internal static partial class RequestHandler
    {
        private static async Task HandleErrorAsync(RequestBase request, HttpResponseMessage responseMessage, TraktResponseHeaders traktHeaders,
                                                   bool isInAuthorizationPolling, CancellationToken cancellationToken = default)
        {
            ExceptionParameters parameters = await ExceptionParameters.CreateAsync(request, responseMessage, traktHeaders,
                                                                                   isInAuthorizationPolling, cancellationToken).ConfigureAwait(false);

            if (parameters.Flags.IsAuthorizationTokenRequest && !parameters.IsInAuthorizationPolling)
            {
                HandleAuthorizationTokenError(parameters);
            }

            switch (parameters.StatusCode)
            {
                case Constants.StatusCodes.NotFound:
                    throw CreateNotFoundException(parameters);
                case Constants.StatusCodes.Conflict:
                    throw await CreateConflictExceptionAsync(parameters, cancellationToken).ConfigureAwait(false);
                case Constants.StatusCodes.BadRequest:
                    if (!parameters.IsInAuthorizationPolling)
                    {
                        throw new TraktApiBadRequestException(parameters);
                    }

                    break;
                case Constants.StatusCodes.Unauthorized:
                    throw new TraktApiAuthorizationException(parameters);
                case Constants.StatusCodes.Gone:
                    if (parameters.IsInAuthorizationPolling)
                    {
                        // Authorization Polling - Expired
                        throw new TraktApiAuthenticationDeviceException("Expired - the token has expired, restart the process", parameters);
                    }

                    break;
                case Constants.StatusCodes.Denied:
                    if (parameters.IsInAuthorizationPolling)
                    {
                        // Authorization Polling - Denied
                        throw new TraktApiAuthenticationDeviceException("Denied - user explicitly denied this code", parameters);
                    }

                    break;
                case Constants.StatusCodes.AccountLimitExceeded:
                    throw new TraktApiAccountLimitException(parameters);
                case Constants.StatusCodes.VIPValidationError:
                    throw new TraktApiVipValidationException(parameters);
                case Constants.StatusCodes.RateLimitExceeded:
                    throw await CreateRateLimitExceptionAsync(parameters, cancellationToken).ConfigureAwait(false);
                case Constants.StatusCodes.Forbidden:
                case Constants.StatusCodes.MethodNotFound:
                case Constants.StatusCodes.ServerError:
                case Constants.StatusCodes.ServiceUnavailableBadGateway:
                case Constants.StatusCodes.PreconditionFailed:
                case Constants.StatusCodes.ValidationError:
                case Constants.StatusCodes.LockedUserAccount:
                case Constants.StatusCodes.ServiceUnavailable:
                case Constants.StatusCodes.ServiceUnavailableGatewayTimeout:
                case Constants.StatusCodes.ServiceUnavailableCloudflareError520:
                case Constants.StatusCodes.ServiceUnavailableCloudflareError521:
                case Constants.StatusCodes.ServiceUnavailableCloudflareError522:
                default:
                    throw TraktApiException.Create(parameters);
            }
        }

        /// <summary>
        /// Maps errors of <c>oauth/token</c> requests (code exchange and refresh) to <see cref="TraktApiAuthenticationOAuthException" />.
        /// Per RFC 6749, an invalid/expired code, refresh token or PKCE verifier (<c>invalid_grant</c>) is reported as 400,
        /// invalid client credentials (<c>invalid_client</c>) as 401. Other status codes use the general handling.
        /// </summary>
        private static void HandleAuthorizationTokenError(ExceptionParameters parameters)
        {
            switch (parameters.StatusCode)
            {
                case Constants.StatusCodes.BadRequest:
                    throw new TraktApiAuthenticationOAuthException("Invalid grant - the code, refresh token or code verifier is invalid, expired or revoked", parameters);
                case Constants.StatusCodes.Unauthorized:
                    throw new TraktApiAuthenticationOAuthException("Invalid client - client authentication failed", parameters);
                case Constants.StatusCodes.NotFound:
                    throw new TraktApiAuthenticationOAuthException("Resource not found", parameters);
            }
        }

        private static TraktApiException CreateNotFoundException(ExceptionParameters parameters)
        {
            if (parameters.Flags.IsDeviceRequest || parameters.IsInAuthorizationPolling)
                return new TraktApiAuthenticationDeviceException("Not Found - invalid device code", parameters);

            if (parameters.Flags.IsAuthorizationRevokeRequest)
                return new TraktApiAuthenticationException("Resource not found", parameters);

            return parameters.RequestObjectType switch
            {
                TraktRequestObjectType.Movie => new TraktApiMovieNotFoundException(parameters),
                TraktRequestObjectType.Show => new TraktApiShowNotFoundException(parameters),
                TraktRequestObjectType.Season => new TraktApiSeasonNotFoundException(parameters),
                TraktRequestObjectType.Episode => new TraktApiEpisodeNotFoundException(parameters),
                TraktRequestObjectType.Person => new TraktApiPersonNotFoundException(parameters),
                TraktRequestObjectType.Comment => new TraktApiCommentNotFoundException(parameters),
                TraktRequestObjectType.List => new TraktApiListNotFoundException(parameters),
                TraktRequestObjectType.User => new TraktApiUserNotFoundException(parameters),
                _ => new TraktApiNotFoundException(GetNotFoundMessage(parameters.ReasonPhrase), parameters)
            };
        }

        private static string GetNotFoundMessage(string reasonPhrase)
            => string.IsNullOrWhiteSpace(reasonPhrase) ? $"Resource not found - Reason Phrase: {reasonPhrase}" : "Resource not found";

        private static async Task<TraktApiException> CreateConflictExceptionAsync(ExceptionParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters.Flags.IsCheckinRequest)
            {
                parameters.CheckinErrorResponse = await TryReadJsonAsync<TraktCheckinErrorResponse>(parameters.ResponseContent, cancellationToken).ConfigureAwait(false);
                return new TraktApiCheckinException(parameters);
            }

            if (parameters.IsInAuthorizationPolling)
                return new TraktApiAuthenticationDeviceException("Already Used - user already approved this code", parameters);

            return new TraktApiConflictException(parameters);
        }

        private static async Task<TraktApiException> CreateRateLimitExceptionAsync(ExceptionParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters.IsInAuthorizationPolling)
                return new TraktApiAuthenticationDeviceException("Slow Down - your app is polling too quickly", parameters);

            parameters.RateLimitInfo = await TryReadJsonAsync<TraktRateLimitInfo>(parameters.ResponseContent, cancellationToken).ConfigureAwait(false);
            return new TraktApiRateLimitException(parameters);
        }

        /// <summary>Reads the given JSON content, returning null if it is empty or not valid.</summary>
        private static async Task<T?> TryReadJsonAsync<T>(string? json, CancellationToken cancellationToken) where T : class
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                using var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                return await contentStream.ReadAsJsonAsync<T>(cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // Invalid content (e.g. a JsonException while reading it) is ignored.
                return null;
            }
        }
    }
}
