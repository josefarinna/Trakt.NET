namespace TraktNET
{
    /// <summary>
    /// Provides access to OAuth and device authentication and authorization.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/authentication-oauth">"Trakt API Documentation - Authentication - OAuth"</a> section
    /// and the <a href="https://trakt.docs.apiary.io/#reference/authentication-devices">"Trakt API Documentation - Authentication - Devices"</a> section.
    /// </summary>
    public sealed partial class TraktAuthModule(TraktContext context) : BaseModule(context)
    {
        public string CreateAuthorizationUrlCore(string clientId, string redirectUri, string? state = null, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => RequestHandler.CreateAuthorizationUrl(_context, clientId, redirectUri, state, showSignupPage, forceLoginPrompt);

        public string CreateAuthorizationUrlWithDefaultStateCore(string clientId, string redirectUri, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => RequestHandler.CreateAuthorizationUrl(_context, clientId, redirectUri, _context.AntiForgeryToken, showSignupPage, forceLoginPrompt);

        public Task<TraktResponse<TraktAuthorization>> GetAuthorizationImplAsync(string code, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var content = new AuthorizationRequestBody
            {
                Code = code,
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUri = redirectUri
            };
            content.Validate();

            var request = new AuthorizationRequest
            {
                Content = new StringContent(content.ToJson())
                //Flags = new RequestFlags { IsAuthorizationRequest = true }
            };

            return RequestHandler.GetAuthorizationAsync(_context, request, cancellationToken);
        }

        public Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationImplAsync(string refreshToken, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var content = new AuthorizationRefreshRequestBody
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUri = redirectUri,
                RefreshToken = refreshToken
            };
            content.Validate();

            var request = new AuthorizationRefreshRequest
            {
                Content = new StringContent(content.ToJson())
            };

            return RequestHandler.RefreshAuthorizationAsync(_context, request, cancellationToken);
        }

        public Task<TraktResponse> RevokeAuthorizationImplAsync(string accessToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var content = new AuthorizationRevokeRequestBody
            {
                AccessToken = accessToken,
                ClientId = clientId,
                ClientSecret = clientSecret
            };
            content.Validate();

            var request = new AuthorizationRevokeRequest
            {
                Content = new StringContent(content.ToJson()),
                Flags = new RequestFlags { IsAuthorizationRevokeRequest = true }
            };

            return RequestHandler.RevokeAuthorizationAsync(_context, request, cancellationToken);
        }

        public Task<TraktResponse<TraktDevice>> GenerateDeviceImplAsync(string clientId, CancellationToken cancellationToken = default)
        {
            var content = new DeviceRequestBody
            {
                ClientId = clientId
            };
            content.Validate();

            var request = new DeviceRequest
            {
                Content = new StringContent(content.ToJson()),
                Flags = new RequestFlags { IsDeviceRequest = true }
            };

            return RequestHandler.GetDeviceAsync(_context, request, cancellationToken);
        }

        public Task<TraktResponse<TraktAuthorization>> PollForAuthorizationImplAsync(TraktDevice device, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var content = new AuthorizationPollRequestBody
            {
                Device = device,
                ClientId = clientId,
                ClientSecret = clientSecret
            };
            content.Validate();

            var request = new AuthorizationPollRequest
            {
                Content = new StringContent(content.ToJson())
            };

            return RequestHandler.PollForAuthorizationAsync(_context, request, device, cancellationToken);
        }
    }
}
