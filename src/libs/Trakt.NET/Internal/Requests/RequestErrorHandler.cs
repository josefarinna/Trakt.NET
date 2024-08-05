using System.Text;

namespace TraktNET
{
    internal sealed partial class RequestHandler
    {
        private static async Task HandleErrorAsync(RequestBase request, HttpResponseMessage responseMessage, TraktResponseHeaders traktHeaders,
                                                   bool isInAuthorizationPolling, CancellationToken cancellationToken = default)
        {
            ExceptionParameters parameters = await ExceptionParameters.CreateAsync(request, responseMessage, traktHeaders,
                                                                                   isInAuthorizationPolling, cancellationToken).ConfigureAwait(false);

            switch (parameters.StatusCode)
            {
                case Constants.StatusCodes.NotFound:
                    HandleNotFoundError(parameters);
                    break;
                case Constants.StatusCodes.Conflict:
                    await HandleConflictErrorAsync(parameters, cancellationToken).ConfigureAwait(false);
                    break;
                case Constants.StatusCodes.BadRequest:
                    if (!parameters.IsInAuthorizationPolling)
                    {
                        throw new TraktApiBadRequestException(parameters);
                    }

                    break;
                case Constants.StatusCodes.Unauthorized:
                    if (!parameters.Flags.IsAuthorizationRequest && !parameters.Flags.IsAuthorizationRevokeRequest)
                    {
                        throw new TraktApiAuthorizationException(parameters);
                    }

                    break;
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
                    throw new TraktApiVIPValidationException(parameters);
                case Constants.StatusCodes.RateLimitExceeded:
                    await HandleRateLimitErrorAsync(parameters, cancellationToken).ConfigureAwait(false);
                    break;
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

        private static void HandleNotFoundError(ExceptionParameters parameters)
        {
            if (parameters.Flags.IsDeviceRequest || parameters.IsInAuthorizationPolling)
            {
                throw new TraktApiAuthenticationDeviceException("Not Found - invalid device code", parameters);
            }
            else if (parameters.Flags.IsAuthorizationRequest)
            {
                throw new TraktApiAuthenticationOAuthException("Resource not found", parameters);
            }
            else if (parameters.Flags.IsAuthorizationRevokeRequest)
            {
                throw new TraktApiAuthenticationException("Resource not found", parameters);
            }
            else if (parameters.RequestObjectType != TraktRequestObjectType.None)
            {
                HandleNotFoundObjectError(parameters);
            }

            string message = "Resource not found";

            if (string.IsNullOrWhiteSpace(parameters.ReasonPhrase))
            {
                message = $"Resource not found - Reason Phrase: {parameters.ReasonPhrase}";
            }

            throw new TraktApiNotFoundException(message, parameters);
        }

        private static void HandleNotFoundObjectError(ExceptionParameters parameters)
            => throw parameters.RequestObjectType switch
            {
                TraktRequestObjectType.Movie => new TraktApiMovieNotFoundException(parameters),
                TraktRequestObjectType.Show => new TraktApiShowNotFoundException(parameters),
                TraktRequestObjectType.Season => new TraktApiSeasonNotFoundException(parameters),
                TraktRequestObjectType.Episode => new TraktApiEpisodeNotFoundException(parameters),
                TraktRequestObjectType.Person => new TraktApiPersonNotFoundException(parameters),
                TraktRequestObjectType.Comment => new TraktApiCommentNotFoundException(parameters),
                TraktRequestObjectType.List => new TraktApiListNotFoundException(parameters),
                TraktRequestObjectType.User => new TraktApiUserNotFoundException(parameters),
                TraktRequestObjectType.None => new TraktApiObjectNotFoundException(parameters),
                _ => new TraktApiObjectNotFoundException(parameters),
            };

        private static async Task HandleConflictErrorAsync(ExceptionParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters.Flags.IsCheckinRequest)
            {
                if (!string.IsNullOrWhiteSpace(parameters.ResponseContent))
                {
                    try
                    {
                        using var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(parameters.ResponseContent));
                        parameters.CheckinErrorResponse = await contentStream.ReadAsJsonAsync<TraktCheckinErrorResponse>(cancellationToken).ConfigureAwait(false);
                    }
                    catch
                    {
                    }
                }

                throw new TraktApiCheckinException(parameters);
            }
            else if (parameters.IsInAuthorizationPolling)
            {
                throw new TraktApiAuthenticationDeviceException("Already Used - user already approved this code", parameters);
            }

            throw new TraktApiConflictException(parameters);
        }

        private static async Task HandleRateLimitErrorAsync(ExceptionParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters.IsInAuthorizationPolling)
            {
                throw new TraktApiAuthenticationDeviceException("Slow Down - your app is polling too quickly", parameters);
            }

            if (!string.IsNullOrWhiteSpace(parameters.ResponseContent))
            {
                try
                {
                    using var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(parameters.ResponseContent));
                    parameters.RateLimitInfo = await contentStream.ReadAsJsonAsync<TraktRateLimitInfo>(cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                }
            }

            throw new TraktApiRateLimitException(parameters);
        }
    }
}
