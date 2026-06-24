using System.Net;

namespace TraktNET
{
    /// <summary>
    /// Provides access to OAuth and device authentication and authorization.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/authentication-oauth">"Trakt API Documentation - Authentication - OAuth"</a> section
    /// and the <a href="https://trakt.docs.apiary.io/#reference/authentication-devices">"Trakt API Documentation - Authentication - Devices"</a> section.
    /// </summary>
    public sealed partial class TraktAuthModule
    {
        /// <summary>Gets or sets the Trakt redirect URI for OAuth authentication.</summary>
        public string RedirectUri
        {
            get => _context.RedirectUri;
            set => _context.RedirectUri = value;
        }

        /// <summary>Creates a new OAuth authorization URL. Uses the current <see cref="TraktContext.ClientID" /> and <see cref="RedirectUri" /> to build the authorization URL.</summary>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrl(bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrl(_context.ClientID, showSignupPage, forceLoginPrompt);

        /// <summary>Creates a new OAuth authorization URL. Uses the current <see cref="RedirectUri" /> to build the authorization URL.</summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrl(string clientId, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrl(clientId, RedirectUri, showSignupPage, forceLoginPrompt);

        /// <summary>Creates a new OAuth authorization URL.</summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrl(string clientId, string redirectUri, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlCore(clientId, redirectUri, null, showSignupPage, forceLoginPrompt);

        /// <summary>Creates a new OAuth authorization URL.</summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL.</param>
        /// <param name="state">
        /// The state variable, which will be used to build the authorization URL. See also <see cref="TraktContext.AntiForgeryToken" />.
        /// This parameter is optional and will not be used if it's null or empty.
        /// </param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrl(string clientId, string redirectUri, string state, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlCore(clientId, redirectUri, state, showSignupPage, forceLoginPrompt);

        /// <summary>Creates a new OAuth authorization URL. Uses the current <see cref="TraktContext.ClientID" />, <see cref="RedirectUri" /> and <see cref="TraktContext.AntiForgeryToken" /> as state variable to build the authorization URL.</summary>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrlWithDefaultState(bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlWithDefaultState(_context.ClientID, showSignupPage, forceLoginPrompt);

        /// <summary>Creates a new OAuth authorization URL. Uses the current <see cref="RedirectUri" /> and <see cref="TraktContext.AntiForgeryToken" /> as state variable to build the authorization URL.</summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrlWithDefaultState(string clientId, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlWithDefaultState(clientId, RedirectUri, showSignupPage, forceLoginPrompt);

        /// <summary>Creates a new OAuth authorization URL. Uses the <see cref="TraktContext.AntiForgeryToken" /> as state variable to build the authorization URL.</summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>The created authorization URL.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/authorize/authorize-application">
        /// Trakt API Documentation: OAuth: Authorize
        /// </see></para>
        /// </remarks>
        public string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlWithDefaultStateCore(clientId, redirectUri, showSignupPage, forceLoginPrompt);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="TraktContext.OAuthAuthorizationCode" /> for the request, which has to be set before a call to this method.
        /// Also uses the current <see cref="TraktContext.ClientID" />, <see cref="TraktContext.ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationOAuthException">Thrown if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the current OAuth authorization code is null, empty or contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(_context.OAuthAuthorizationCode!, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="TraktContext.ClientID" />, <see cref="TraktContext.ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationOAuthException">Thrown if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(string code, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, _context.ClientID, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="TraktContext.ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationOAuthException">Thrown if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(string code, string clientId, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, clientId, _context.ClientSecret, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationOAuthException">Thrown if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the given client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(string code, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, clientId, clientSecret, RedirectUri, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationOAuthException">Thrown if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the given client secret is null, empty or contains spaces.
        /// Thrown if the given redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> GetAuthorizationAsync(string code, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
            => GetAuthorizationImplAsync(code, clientId, clientSecret, redirectUri, cancellationToken);

        /// <summary>
        /// Generates a new Trakt device and starts the device authentication process. Uses the current <see cref="TraktContext.ClientID" /> for the request.
        /// Assigns the returned <see cref="TraktDevice" /> instance to <see cref="TraktContext.Device" /> if successful.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried device.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktDevice" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">
        /// Trakt API Documentation: Devices: Device Code
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown if the current client id is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        public Task<TraktResponse<TraktDevice>> GenerateDeviceAsync(CancellationToken cancellationToken = default)
            => GenerateDeviceAsync(_context.ClientID, cancellationToken);

        /// <summary>
        /// Generates a new Trakt device and starts the device authentication process.
        /// Assigns the returned <see cref="TraktDevice" /> instance to <see cref="TraktContext.Device" /> if successful.
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried device.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktDevice" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">
        /// Trakt API Documentation: Devices: Device Code
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown if the given client id is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        public Task<TraktResponse<TraktDevice>> GenerateDeviceAsync(string clientId, CancellationToken cancellationToken = default)
            => GenerateDeviceImplAsync(clientId, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktContext.Authorization" />'s refresh token, <see cref="TraktContext.ClientID" />,
        /// <see cref="TraktContext.ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the current refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if the current refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the current refresh token is null, empty or contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationAsync(CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(_context.Authorization?.RefreshToken!, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktContext.ClientID" />, <see cref="TraktContext.ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given refresh token is null, empty or contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, _context.ClientID, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktContext.ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given refresh token is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, clientId, _context.ClientSecret, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given refresh token is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the given client secret is null, empty or contains spaces.
        /// Thrown if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, _context.RedirectUri, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">
        /// Trakt API Documentation: OAuth: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given refresh token is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the given client secret is null, empty or contains spaces.
        /// Thrown if the given redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
            => RefreshAuthorizationImplAsync(refreshToken, clientId, clientSecret, redirectUri, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="TraktContext.Authorization" />'s access token, <see cref="TraktContext.ClientID" /> and <see cref="TraktContext.ClientSecret" /> for the request.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/revoke-token/revoke-an-access_token">
        /// Trakt API Documentation: OAuth: Revoke Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the current access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if revoking the current access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the current access token is null, empty or contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse> RevokeAuthorizationAsync(CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(_context.Authorization!.AccessToken!, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="TraktContext.ClientID" /> and <see cref="TraktContext.ClientSecret" /> for the request.
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/revoke-token/revoke-an-access_token">
        /// Trakt API Documentation: OAuth: Revoke Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if revoking the given access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given access token is null, empty or contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse> RevokeAuthorizationAsync(string accessToken, CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(accessToken, _context.ClientID, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="TraktContext.ClientSecret" /> for the request.
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/revoke-token/revoke-an-access_token">
        /// Trakt API Documentation: OAuth: Revoke Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if revoking the given access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given access token is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse> RevokeAuthorizationAsync(string accessToken, string clientId, CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(accessToken, clientId, _context.ClientSecret, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-oauth/revoke-token/revoke-an-access_token">
        /// Trakt API Documentation: OAuth: Revoke Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthorizationException">
        /// Thrown if the current <see cref="TraktClient" /> instance is not authorized and the given access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktApiAuthenticationException">Thrown if revoking the given access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given access token is null, empty or contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the given client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse> RevokeAuthorizationAsync(string accessToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => RevokeAuthorizationImplAsync(accessToken, clientId, clientSecret, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="TraktContext.Device" />, <see cref="TraktContext.ClientID" /> and <see cref="TraktContext.ClientSecret" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">
        /// Trakt API Documentation: Devices: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationDeviceException">
        /// Thrown if the current device has an invalid device code.
        /// Thrown if the user code of the current device was already approved by the user.
        /// Thrown if the current device code is already expired unused.
        /// Thrown if the user explicitly denied the user code of the current device.
        /// </exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the current device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> PollForAuthorizationAsync(CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(_context.Device!, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="TraktContext.ClientID" /> and <see cref="TraktContext.ClientSecret" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="device">The <see cref="TraktDevice" />, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">
        /// Trakt API Documentation: Devices: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationDeviceException">
        /// Thrown if the given device has an invalid device code.
        /// Thrown if the user code of the given device was already approved by the user.
        /// Thrown if the given device code is already expired unused.
        /// Thrown if the user explicitly denied the user code of the given device.
        /// </exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown if the current client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> PollForAuthorizationAsync(TraktDevice device, CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(device, _context.ClientID, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="TraktContext.ClientSecret" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="device">The <see cref="TraktDevice" />, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">
        /// Trakt API Documentation: Devices: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationDeviceException">
        /// Thrown if the given device has an invalid device code.
        /// Thrown if the user code of the given device was already approved by the user.
        /// Thrown if the given device code is already expired unused.
        /// Thrown if the user explicitly denied the user code of the given device.
        /// </exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the current client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> PollForAuthorizationAsync(TraktDevice device, string clientId, CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(device, clientId, _context.ClientSecret, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktContext.Authorization" /> if successful.
        /// </summary>
        /// <param name="device">The <see cref="TraktDevice" />, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried authorization.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktAuthorization" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">
        /// Trakt API Documentation: Devices: Get Token
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiAuthenticationDeviceException">
        /// Thrown if the given device has an invalid device code.
        /// Thrown if the user code of the given device was already approved by the user.
        /// Thrown if the given device code is already expired unused.
        /// Thrown if the user explicitly denied the user code of the given device.
        /// </exception>
        /// <exception cref="TraktException">Thrown if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the given device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown if the given client id is null, empty or contains spaces.
        /// Thrown if the given client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<TraktAuthorization>> PollForAuthorizationAsync(TraktDevice device, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => PollForAuthorizationImplAsync(device, clientId, clientSecret, cancellationToken);
    }
}
