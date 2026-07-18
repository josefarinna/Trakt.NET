namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to Younify streaming connections.<para />
    /// This module contains all methods of the Trakt API Documentation - Younify section.
    /// </summary>
    public sealed partial class TraktYounifyModule
    {
        /// <summary>Gets all connectable streaming services with the current user's connection status.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing all streaming service connections.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktYounifyConnection" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getyounifyconnections">
        /// Trakt API Documentation: Younify - Get streaming connections
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktYounifyConnection>> GetConnectionsAsync(CancellationToken cancellationToken = default)
            => GetConnectionsImplAsync(cancellationToken);

        /// <summary>Creates a Younify streaming connection, minting a signed web-auth URL for the client to open.</summary>
        /// <param name="post">The payload containing the service ID and return URL. See also <seealso cref="TraktYounifyConnectPost" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the signed web-auth URL.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktYounifyConnectResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postyounifyconnect">
        /// Trakt API Documentation: Younify - Create a streaming connection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="post"/> is null.</exception>
        public Task<TraktResponse<TraktYounifyConnectResponse>> ConnectAsync(TraktYounifyConnectPost post, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(post);
            post.Validate();
            return ConnectImplAsync(post, cancellationToken);
        }

        /// <summary>Queues a re-sync of a connected streaming service for the authenticated user.</summary>
        /// <param name="serviceId">The streaming service id (e.g. "netflix").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>A response of type <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postyounifyrefresh">
        /// Trakt API Documentation: Younify - Refresh a streaming service
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> RefreshAsync(string serviceId, CancellationToken cancellationToken = default)
            => RefreshImplAsync(serviceId, cancellationToken);

        /// <summary>Queues a full re-sync of a connected streaming service for the authenticated user.</summary>
        /// <param name="serviceId">The streaming service id (e.g. "netflix").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>A response of type <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postyounifyrefreshall">
        /// Trakt API Documentation: Younify - Refresh a streaming service (full re-sync)
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> RefreshAllAsync(string serviceId, CancellationToken cancellationToken = default)
            => RefreshAllImplAsync(serviceId, cancellationToken);

        /// <summary>Unlinks a streaming service from the authenticated user.</summary>
        /// <param name="serviceId">The streaming service id (e.g. "netflix").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>A response of type <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteyounifydisconnect">
        /// Trakt API Documentation: Younify - Unlink a streaming service
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> DisconnectAsync(string serviceId, CancellationToken cancellationToken = default)
            => DisconnectImplAsync(serviceId, cancellationToken);
    }
}
