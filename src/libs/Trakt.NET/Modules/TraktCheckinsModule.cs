namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.
    /// <para>This module contains all methods of the <see href="https://docs.trakt.tv/reference/about-checkin">Trakt API Documentation - Checkins</see> section.</para>
    /// </summary>
    public partial class TraktCheckinsModule
    {
        /// <summary>
        /// Checks into the given <see cref="TraktMovie" />.
        /// </summary>
        /// <param name="movieCheckin">An <see cref="TraktMovieCheckin" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovieCheckinResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcheckinstart">
        /// Trakt API Documentation: Checkin: Checkin into an item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktMovieCheckinResponse>> CheckIntoMovieAsync(TraktMovieCheckin movieCheckin, CancellationToken cancellationToken = default)
            => CheckIntoMovieImplAsync(movieCheckin, cancellationToken);

        /// <summary>
        /// Checks into the given <see cref="TraktEpisode" />.
        /// </summary>
        /// <param name="episodeCheckin">An <see cref="TraktEpisodeCheckin" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeCheckinResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcheckinstart">
        /// Trakt API Documentation: Checkin: Checkin into an item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktEpisodeCheckinResponse>> CheckIntoEpisodeAsync(TraktEpisodeCheckin episodeCheckin, CancellationToken cancellationToken = default)
            => CheckIntoEpisodeImplAsync(episodeCheckin, cancellationToken);

        /// <summary>
        /// Deletes any active checkins.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deletecheckindelete">
        /// Trakt API Documentation: Checkin: Delete any active checkins
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse> DeleteAnyActiveCheckinsAsync(CancellationToken cancellationToken = default)
            => DeleteAnyActiveCheckinsImplAsync(cancellationToken);
    }
}
