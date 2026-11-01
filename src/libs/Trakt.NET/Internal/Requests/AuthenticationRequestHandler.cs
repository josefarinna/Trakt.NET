using System.Net;

namespace TraktNET
{
    internal static partial class RequestHandler
    {
        internal static string CreateAuthorizationUrl(TraktContext context, string clientId, string redirectUri,
            string? state = null, bool? showSignupPage = null, bool? forceLoginPrompt = null,
            string? codeChallenge = null, string? codeChallengeMethod = null)
        {
            ValidateAuthorizationUrlArguments(clientId, redirectUri, state, codeChallenge, codeChallengeMethod);
            return BuildAuthorizationUrl(context, clientId, redirectUri, state, showSignupPage, forceLoginPrompt, codeChallenge, codeChallengeMethod);
        }

        internal static async Task<TraktResponse<TraktDevice>> GetDeviceAsync(TraktContext context, DeviceRequest request,
            CancellationToken cancellationToken = default)
        {
            TraktResponse<TraktDevice> response = await ExecuteSingleItemRequestAsync<TraktDevice>(context, request, cancellationToken).ConfigureAwait(false);
            context.Device = response.Content;

            return response;
        }

        internal static async Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(TraktContext context,
            AuthorizationRequest request, CancellationToken cancellationToken = default)
        {
            TraktResponse<TraktAuthorization> response = await ExecuteSingleItemRequestAsync<TraktAuthorization>(context, request, cancellationToken).ConfigureAwait(false);
            context.Authorization = response.Content;

            // The PKCE code verifier is single-use, so it must not be reused for later exchanges.
            if (request.TraktAuthorizationPost.CodeVerifier != null)
                context.CodeVerifier = null;

            return response;
        }

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
            request.Validate();

            uint totalExpiredSeconds = 0;

            while (totalExpiredSeconds < device.ExpiresInSeconds)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var requestMessageBuilder = new AuthorizationPollRequest
                {
                    TraktAuthorizationPollPost = request.TraktAuthorizationPollPost,
                    Flags = request.Flags
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

                // Unsuccessful status codes are already handled while executing the request,
                // so only unexpected successful status codes remain here.
                throw new TraktApiAuthenticationDeviceException("Device authorization polling failed - unexpected response status code",
                    await ExceptionParameters.CreateAsync(request, response.ResponseMessage, response.TraktHeaders, true, cancellationToken).ConfigureAwait(false));
            }

            throw new TraktApiAuthenticationDeviceException("Device authorization polling timed out.",
                await ExceptionParameters.CreateAsync(request, new HttpResponseMessage(), new TraktResponseHeaders(), true, cancellationToken).ConfigureAwait(false));
        }

        private static async Task<RequestResponse> ExecutePollingRequestAsync(TraktContext context, RequestBase request,
            CancellationToken cancellationToken = default)
        {
            request.Validate();
            request.BuildUri();
            AddRequestMessageHeaders(context, request);

            HttpClient httpClient = context.GetHttpClient(request.Flags.IsAuthorizationRequest);

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
            bool? showSignupPage = null, bool? forceLoginPrompt = null, string? codeChallenge = null, string? codeChallengeMethod = null)
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

            if (!string.IsNullOrEmpty(codeChallenge))
            {
                uriParams.Add("code_challenge", codeChallenge!);
                uriParams.Add("code_challenge_method", !string.IsNullOrEmpty(codeChallengeMethod) ? codeChallengeMethod! : "S256");
            }

            var encodedUriContent = new FormUrlEncodedContent(uriParams!);
            string encodedUri = encodedUriContent.ReadAsStringAsync().Result;

            return $"?{encodedUri}";
        }

        private static string BuildAuthorizationUrl(TraktContext context, string clientId, string redirectUri, string? state = null,
            bool? showSignupPage = null, bool? forceLoginPrompt = null, string? codeChallenge = null, string? codeChallengeMethod = null)
        {
            string encodedUriParams = CreateEncodedAuthorizationUriParameters(clientId, redirectUri, state, showSignupPage, forceLoginPrompt, codeChallenge, codeChallengeMethod);
            return $"{context.BaseAuthorizationUri}oauth/authorize{encodedUriParams}";
        }

        private static void ValidateAuthorizationUrlArguments(string clientId, string redirectUri)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", nameof(redirectUri));
        }

        private static void ValidateAuthorizationUrlArguments(string clientId, string redirectUri, string? state,
            string? codeChallenge = null, string? codeChallengeMethod = null)
        {
            ValidateAuthorizationUrlArguments(clientId, redirectUri);

            if (state != null && (state.Length == 0 || state.ContainsSpace()))
                throw new ArgumentException("state not valid", nameof(state));

            if (codeChallenge != null && (codeChallenge.Length == 0 || codeChallenge.ContainsSpace()))
                throw new ArgumentException("code challenge not valid", nameof(codeChallenge));

            if (codeChallengeMethod != null && (codeChallengeMethod.Length == 0 || codeChallengeMethod.ContainsSpace()))
                throw new ArgumentException("code challenge method not valid", nameof(codeChallengeMethod));

            if (codeChallenge == null && codeChallengeMethod != null)
                throw new ArgumentException("code challenge method cannot be set without code challenge", nameof(codeChallengeMethod));
        }
    }
}
