#if !NETSTANDARD2_0
using System.Net.Mime;
#endif
using System.Text;

namespace TraktNET
{
    /// <summary>
    /// Provides access to OAuth and device authentication and authorization.<para />
    /// This module contains all methods of the <a href="https://docs.trakt.tv/reference/authentication#user-content-authentication">"Trakt API Documentation - Authentication - OAuth"</a> section
    /// and the <a href="https://docs.trakt.tv/reference/authentication#user-content-device-code-flow">"Trakt API Documentation - Authentication - Devices"</a> section.
    /// </summary>
    public sealed partial class TraktAuthModule(TraktContext context) : BaseModule(context)
    {
        public string CreateAuthorizationUrlCore(string clientId, string redirectUri, string? state = null, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => RequestHandler.CreateAuthorizationUrl(_context, clientId, redirectUri, state, showSignupPage, forceLoginPrompt);

        public string CreateAuthorizationUrlWithDefaultStateCore(string clientId, string redirectUri, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => RequestHandler.CreateAuthorizationUrl(_context, clientId, redirectUri, _context.AntiForgeryToken, showSignupPage, forceLoginPrompt);

        private Task<TraktResponse<TraktAuthorization>> GetAuthorizationImplAsync(string code, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
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
#if NETSTANDARD2_0
                Content = new StringContent(content.ToJson(), Encoding.UTF8, Constants.MediaTypeNames.ApplicationJson)
#else
                Content = new StringContent(content.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json)
#endif
            };

            return RequestHandler.GetAuthorizationAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationImplAsync(string refreshToken, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
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
#if NETSTANDARD2_0
                Content = new StringContent(content.ToJson(), Encoding.UTF8, Constants.MediaTypeNames.ApplicationJson)
#else
                Content = new StringContent(content.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json)
#endif
            };

            return RequestHandler.RefreshAuthorizationAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> RevokeAuthorizationImplAsync(string accessToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
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
#if NETSTANDARD2_0
                Content = new StringContent(content.ToJson(), Encoding.UTF8, Constants.MediaTypeNames.ApplicationJson),
#else
                Content = new StringContent(content.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json),
#endif
                Flags = new RequestFlags { IsAuthorizationRevokeRequest = true }
            };

            return RequestHandler.RevokeAuthorizationAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktDevice>> GenerateDeviceImplAsync(string clientId, CancellationToken cancellationToken = default)
        {
            var content = new DeviceRequestBody
            {
                ClientId = clientId
            };
            content.Validate();

            var request = new DeviceRequest
            {
#if NETSTANDARD2_0
                Content = new StringContent(content.ToJson(), Encoding.UTF8, Constants.MediaTypeNames.ApplicationJson),
#else
                Content = new StringContent(content.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json),
#endif
                Flags = new RequestFlags { IsDeviceRequest = true }
            };

            return RequestHandler.GetDeviceAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktAuthorization>> PollForAuthorizationImplAsync(TraktDevice device, string clientId, string clientSecret, CancellationToken cancellationToken = default)
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
#if NETSTANDARD2_0
                Content = new StringContent(content.ToJson(), Encoding.UTF8, Constants.MediaTypeNames.ApplicationJson)
#else
                Content = new StringContent(content.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json)
#endif
            };

            return RequestHandler.PollForAuthorizationAsync(_context, request, device, cancellationToken);
        }
    }
}
