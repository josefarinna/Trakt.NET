namespace TraktNET
{
    /// <summary>
    /// Provides access to OAuth and device authentication and authorization.
    /// <para>This module contains all methods of the <see href="https://docs.trakt.tv/reference/auth">Trakt API Documentation - Authentication</see> section</para>
    /// </summary>
    public sealed partial class TraktAuthModule(TraktContext context) : BaseModule(context)
    {
        public string CreateAuthorizationUrlCore(string clientId, string redirectUri, string? state = null, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => RequestHandler.CreateAuthorizationUrl(_context, clientId, redirectUri, state, showSignupPage, forceLoginPrompt);

        public string CreateAuthorizationUrlWithDefaultStateCore(string clientId, string redirectUri, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => RequestHandler.CreateAuthorizationUrl(_context, clientId, redirectUri, _context.AntiForgeryToken, showSignupPage, forceLoginPrompt);

        private Task<TraktResponse<TraktAuthorization>> GetAuthorizationImplAsync(string code, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var traktAuthorizationPost = new TraktAuthorizationPost
            {
                Code = code,
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUri = redirectUri
            };

            var request = new AuthorizationRequest
            {
                TraktAuthorizationPost = traktAuthorizationPost
            };

            return RequestHandler.GetAuthorizationAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationImplAsync(string refreshToken, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var traktAuthorizationRefreshPost = new TraktAuthorizationRefreshPost
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUri = redirectUri,
                RefreshToken = refreshToken
            };

            var request = new AuthorizationRefreshRequest
            {
                TraktAuthorizationRefreshPost = traktAuthorizationRefreshPost
            };

            return RequestHandler.RefreshAuthorizationAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> RevokeAuthorizationImplAsync(string accessToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var traktAuthorizationRevokePost = new TraktAuthorizationRevokePost
            {
                Token = accessToken,
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var request = new AuthorizationRevokeRequest
            {
                TraktAuthorizationRevokePost = traktAuthorizationRevokePost,
                Flags = new RequestFlags { IsAuthorizationRevokeRequest = true }
            };

            return RequestHandler.RevokeAuthorizationAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktDevice>> GenerateDeviceImplAsync(string clientId, CancellationToken cancellationToken = default)
        {
            var traktDevicePost = new TraktDevicePost
            {
                ClientId = clientId
            };

            var request = new DeviceRequest
            {
                TraktDevicePost = traktDevicePost,
                Flags = new RequestFlags { IsDeviceRequest = true }
            };

            return RequestHandler.GetDeviceAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktAuthorization>> PollForAuthorizationImplAsync(TraktDevice device, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var traktAuthorizationPollPost = new TraktAuthorizationPollPost
            {
                Device = device,
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var request = new AuthorizationPollRequest
            {
                TraktAuthorizationPollPost = traktAuthorizationPollPost
            };

            return RequestHandler.PollForAuthorizationAsync(_context, request, device, cancellationToken);
        }
    }
}

