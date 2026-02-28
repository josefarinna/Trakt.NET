namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>Undoes the reset of watched progress for a <see cref="TraktShow" /> with the given Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para>See <see href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">
        /// Trakt API Documentation: Shows: Undo Reset Watched Progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> UndoResetShowWatchedProgressAsync(string traktShowIDOrSlug, CancellationToken cancellationToken = default)
            => UndoResetShowWatchedProgressImplAsync(traktShowIDOrSlug, cancellationToken);

        /// <summary>Undoes the reset of watched progress for a <see cref="TraktShow" /> with the given Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para>See <see href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">
        /// Trakt API Documentation: Shows: Undo Reset Watched Progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> UndoResetShowWatchedProgressAsync(uint traktShowID, CancellationToken cancellationToken = default)
            => UndoResetShowWatchedProgressImplAsync(traktShowID.ToInvariantCultureString(), cancellationToken);

        /// <summary>Undoes the reset of watched progress for a <see cref="TraktShow" /> with the given IDs.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the restored watched progress information.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowResetWatchedProgress" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para>See <see href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">
        /// Trakt API Documentation: Shows: Undo Reset Watched Progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse> UndoResetShowWatchedProgressAsync(TraktShowIDs showIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return UndoResetShowWatchedProgressAsync(showIDs.BestID, cancellationToken);
        }
    }
}
