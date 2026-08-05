namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>Resets the watched progress for a <see cref="TraktShow" /> with the given Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="resetAt">The UTC datetime from which the progress should be calculated onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing an optional reset_at UTC date to have it.
        /// calculate progress from that specific date onwards.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowResetWatchedProgress" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para>See <see href="https://docs.trakt.tv/reference/postshowsprogressreset">
        /// Trakt API Documentation: Shows: Reset Watched Progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowResetWatchedProgress>> ResetShowWatchedProgressAsync(string traktShowIDOrSlug,
            DateTime? resetAt = null, CancellationToken cancellationToken = default)
            => ResetShowWatchedProgressImplAsync(traktShowIDOrSlug, resetAt, cancellationToken);

        /// <summary>Resets the watched progress for a <see cref="TraktShow" /> with the given Trakt-ID or -Slug.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="resetAt">The UTC datetime from which the progress should be calculated onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing an optional reset_at UTC date to have it.
        /// calculate progress from that specific date onwards.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowResetWatchedProgress" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para>See <see href="https://docs.trakt.tv/reference/postshowsprogressreset">
        /// Trakt API Documentation: Shows: Reset Watched Progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowResetWatchedProgress>> ResetShowWatchedProgressAsync(uint traktShowID,
            DateTime? resetAt = null, CancellationToken cancellationToken = default)
            => ResetShowWatchedProgressImplAsync(traktShowID.ToInvariantCultureString(), resetAt, cancellationToken);

        /// <summary>Resets the watched progress for a <see cref="TraktShow" /> with the given Trakt-ID or -Slug.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="resetAt">The UTC datetime from which the progress should be calculated onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing an optional reset_at UTC date to have it.
        /// calculate progress from that specific date onwards.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowResetWatchedProgress" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para>See <see href="https://docs.trakt.tv/reference/postshowsprogressreset">
        /// Trakt API Documentation: Shows: Reset Watched Progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse<TraktShowResetWatchedProgress>> ResetShowWatchedProgressAsync(TraktShowIDs showIDs,
            DateTime? resetAt = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return ResetShowWatchedProgressAsync(showIDs.BestID, resetAt, cancellationToken);
        }
    }
}
