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
        /// <para>Limited Access: this endpoint is only available to official first-party Trakt apps (third-party apps receive 401).</para>
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
        /// <para>Limited Access: this endpoint is only available to official first-party Trakt apps (third-party apps receive 401).</para>
        /// <para><see href="https://docs.trakt.tv/reference/putusersplexupdatesettings">
        /// Trakt API Documentation: Users: Update Plex settings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="settingsUpdate"/> is null.</exception>
        public Task<TraktResponse> UpdatePlexSettingsAsync(TraktPlexSettingsUpdate settingsUpdate, CancellationToken cancellationToken = default)
            => UpdatePlexSettingsImplAsync(settingsUpdate, cancellationToken);

        /// <summary>Disconnects Plex and clears connection/selection state.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>Limited Access: this endpoint is only available to official first-party Trakt apps (third-party apps receive 401).</para>
        /// <para><see href="https://docs.trakt.tv/reference/deleteusersplexdisconnect">
        /// Trakt API Documentation: Users: Disconnect Plex
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse> DisconnectPlexAsync(CancellationToken cancellationToken = default)
            => DisconnectPlexImplAsync(cancellationToken);
    }
}
