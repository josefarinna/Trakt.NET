using System.Net;

namespace TraktNET
{
    internal static partial class RequestHandler
    {
        internal static string CreateAuthorizationUrl(TraktContext context, string clientId, string redirectUri,
            string? state = null, bool? showSignupPage = null, bool? forceLoginPrompt = null)
        {
            ValidateAuthorizationUrlArguments(clientId, redirectUri, state);
            return BuildAuthorizationUrl(context, clientId, redirectUri, state, showSignupPage, forceLoginPrompt);
        }

        internal static async Task<TraktResponse<TraktDevice>> GetDeviceAsync(TraktContext context, DeviceRequest request,
            CancellationToken cancellationToken = default)
        {
            TraktResponse<TraktDevice> response = await ExecuteSingleItemRequestAsync<TraktDevice>(context, request, cancellationToken).ConfigureAwait(false);
            context.Device = response.Content;

            return response;
        }

        internal static Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(TraktContext context,
            AuthorizationRequest request, CancellationToken cancellationToken = default)
            => ExecuteSingleItemRequestAsync<TraktAuthorization>(context, request, cancellationToken);

        internal static async Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationAsync(TraktContext context,
            AuthorizationRefreshRequest request, CancellationToken cancellationToken = default)
        {
            TraktResponse<TraktAuthorization> response = await ExecuteSingleItemRequestAsync<TraktAuthorization>(context, request, cancellationToken);
            context.Authorization = response.Content;

            return response;
        }

        internal static async Task<TraktResponse> RevokeAuthorizationAsync(TraktContext context,
            AuthorizationRevokeRequest request, CancellationToken cancellationToken = default)
        {
            TraktResponse response = await ExecuteNoContentRequestAsync(context, request, cancellationToken).ConfigureAwait(false);
            context.Authorization = TraktAuthorization.CreateWith(string.Empty, string.Empty);

            return response;
        }

        internal static async Task<TraktResponse<TraktAuthorization>> PollForAuthorizationAsync(TraktContext context,
            AuthorizationPollRequest request, TraktDevice device, CancellationToken cancellationToken = default)
        {
            uint totalExpiredSeconds = 0;

            var responseMessage = new HttpResponseMessage();
            var traktHeaders = new TraktResponseHeaders();

#if NETSTANDARD2_0 || NETSTANDARD2_1
            string content = await request.Content.ReadAsStringAsync();
#else
            string content = await request.Content!.ReadAsStringAsync(cancellationToken);
#endif

            while (totalExpiredSeconds < device.ExpiresInSeconds)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var requestMessageBuilder = new AuthorizationPollRequest
                {
                    Content = new StringContent(content)
                };

                using RequestResponse response = await ExecutePollingRequestAsync(context, requestMessageBuilder, cancellationToken).ConfigureAwait(false);

                if (response.ResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var contentResponse = (ContentRequestResponse)response;
                    TraktAuthorization? auth = await contentResponse.ResponseContentStream.ReadAsJsonAsync<TraktAuthorization>(cancellationToken).ConfigureAwait(false);

                    return TraktResponse<TraktAuthorization>.Create(
                        response.ResponseMessage.StatusCode, auth, response.TraktHeaders,
                        response.ResponseMessage.Headers, response.ResponseMessage.Content.Headers);
                }

                if (response.ResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    await Task.Delay((int)device.IntervalInMilliseconds, cancellationToken).ConfigureAwait(false);
                    totalExpiredSeconds += device.IntervalInSeconds;

                    continue;
                }

                responseMessage = response.ResponseMessage;
                traktHeaders = response.TraktHeaders;

                break;
            }

            throw new TraktApiAuthenticationDeviceException("Device authorization polling timed out.", await ExceptionParameters.CreateAsync(request, responseMessage, traktHeaders, true, cancellationToken));
        }

        private static async Task<RequestResponse> ExecutePollingRequestAsync(TraktContext context, RequestBase request,
            CancellationToken cancellationToken = default)
        {
            request.Validate();
            request.BuildUri();
            AddRequestMessageHeaders(context, request);

            HttpClient httpClient = context.GetHttpClient();

            HttpResponseMessage responseMessage = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken).ConfigureAwait(false);

            TraktResponseHeaders traktHeaders = await ParseTraktResponseHeadersAsync(responseMessage.Headers, cancellationToken).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
            {
                await HandleErrorAsync(request, responseMessage, traktHeaders, true, cancellationToken).ConfigureAwait(false);
            }
            else 
            {
#if NET5_0_OR_GREATER
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage, cancellationToken).ConfigureAwait(false);
#else
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
#endif

                return new ContentRequestResponse
                {
                    ResponseMessage = responseMessage,
                    ResponseContentStream = responseContentStream,
                    TraktHeaders = traktHeaders
                };
            }

            return new RequestResponse
            {
                ResponseMessage = responseMessage,
                TraktHeaders = traktHeaders
            };
        }

        private static string CreateEncodedAuthorizationUriParameters(string clientId, string redirectUri, string? state = null,
            bool? showSignupPage = null, bool? forceLoginPrompt = null)
        {
            var uriParams = new Dictionary<string, string>
            {
                ["response_type"] = "code",
                ["client_id"] = clientId,
                ["redirect_uri"] = redirectUri
            };

            if (!string.IsNullOrEmpty(state))
                uriParams["state"] = state!;

            if (showSignupPage.HasValue)
                uriParams.Add("signup", showSignupPage.Value.ToString().ToLowerInvariant());

            if (forceLoginPrompt.HasValue && forceLoginPrompt.Value)
                uriParams.Add("prompt", "login");

            var encodedUriContent = new FormUrlEncodedContent(uriParams!);
            string encodedUri = encodedUriContent.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(encodedUri))
                throw new ArgumentException("authorization uri not valid");

            return $"?{encodedUri}";
        }

        private static string BuildAuthorizationUrl(TraktContext context, string clientId, string redirectUri, string? state = null,
            bool? showSignupPage = null, bool? forceLoginPrompt = null)
        {
            string encodedUriParams = CreateEncodedAuthorizationUriParameters(clientId, redirectUri, state, showSignupPage, forceLoginPrompt);
            return $"{context.BaseAuthorizationUri}oauth/authorize{encodedUriParams}";
        }

        private static void ValidateAuthorizationUrlArguments(string clientId, string redirectUri)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", nameof(redirectUri));
        }

        private static void ValidateAuthorizationUrlArguments(string clientId, string redirectUri, string? state)
        {
            ValidateAuthorizationUrlArguments(clientId, redirectUri);

            if (state != null && (state.Length == 0 || state.ContainsSpace()))
                throw new ArgumentException("state not valid", nameof(state));
        }
    }
}
