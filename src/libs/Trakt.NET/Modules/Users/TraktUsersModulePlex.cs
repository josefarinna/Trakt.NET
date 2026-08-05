using System;
using System.Threading;
using System.Threading.Tasks;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets the user's Plex connection settings and toggles.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the Plex settings.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPlexSettings" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersplexsettings">
        /// Trakt API Documentation: Users: Get Plex settings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<TraktPlexSettings>> GetPlexSettingsAsync(CancellationToken cancellationToken = default)
            => GetPlexSettingsImplAsync(cancellationToken);

        /// <summary>Updates/saves the user's Plex connection settings and toggles.</summary>
        /// <param name="settingsUpdate">The settings update payload. See also <seealso cref="TraktPlexSettingsUpdate" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putusersplexupdatesettings">
        /// Trakt API Documentation: Users: Update Plex settings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="settingsUpdate"/> is null.</exception>
        public Task<TraktResponse> UpdatePlexSettingsAsync(TraktPlexSettingsUpdate settingsUpdate, CancellationToken cancellationToken = default)
            => UpdatePlexSettingsImplAsync(settingsUpdate, cancellationToken);

        /// <summary>Connects Plex by minting a Plex web-auth URL for the client to open.</summary>
        /// <param name="connectPost">The connection payload containing the return URL. See also <seealso cref="TraktPlexConnectPost" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the Plex web-auth URL.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPlexConnectResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusersplexconnect">
        /// Trakt API Documentation: Users: Connect Plex
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="connectPost"/> is null.</exception>
        public Task<TraktResponse<TraktPlexConnectResponse>> ConnectPlexAsync(TraktPlexConnectPost connectPost, CancellationToken cancellationToken = default)
            => ConnectPlexImplAsync(connectPost, cancellationToken);

        /// <summary>Disconnects Plex and clears connection/selection state.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteusersplexdisconnect">
        /// Trakt API Documentation: Users: Disconnect Plex
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse> DisconnectPlexAsync(CancellationToken cancellationToken = default)
            => DisconnectPlexImplAsync(cancellationToken);

        /// <summary>Lists the user's Plex servers.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the Plex servers list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPlexServersResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersplexservers">
        /// Trakt API Documentation: Users: Get Plex servers
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<TraktPlexServersResponse>> GetPlexServersAsync(CancellationToken cancellationToken = default)
            => GetPlexServersImplAsync(cancellationToken);

        /// <summary>Returns the home accounts and syncable libraries for a Plex server.</summary>
        /// <param name="serverId">The Plex server machine identifier.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the accounts and libraries.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPlexServerAccountsAndLibraries" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersplexserveraccounts">
        /// Trakt API Documentation: Users: Get Plex server accounts and libraries
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="serverId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="serverId"/> is empty or only whitespace.</exception>
        public Task<TraktResponse<TraktPlexServerAccountsAndLibraries>> GetPlexServerAccountsAsync(string serverId, CancellationToken cancellationToken = default)
            => GetPlexServerAccountsImplAsync(serverId, cancellationToken);

        /// <summary>Enqueues a Plex sync immediately.</summary>
        /// <param name="syncPost">The sync payload options. See also <seealso cref="TraktPlexSyncPost" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusersplexsync">
        /// Trakt API Documentation: Users: Sync Plex now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="syncPost"/> is null.</exception>
        public Task<TraktResponse> SyncPlexAsync(TraktPlexSyncPost syncPost, CancellationToken cancellationToken = default)
            => SyncPlexImplAsync(syncPost, cancellationToken);
    }
}
