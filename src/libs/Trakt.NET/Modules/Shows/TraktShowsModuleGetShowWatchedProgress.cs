namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>Gets watched progress for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="hidden"> If <see langword="true"/>, include hidden episodes in the progress results.</param>
        /// <param name="specials"> If <see langword="true"/>, include special episodes in the progress results.</param>
        /// <param name="countSpecials"> If <see langword="true"/>, count specials when calculating watched progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para/>If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the watched progress information.
        /// <para/>
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and the appropriate response type for watched progress.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/get-show-watched-progress">
        /// Trakt API Documentation: Shows: Watched Progress - Get show watched progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowWatchedProgress>> GetShowWatchedProgressAsync(string traktShowIDOrSlug, bool? hidden = null, bool? specials = null, bool? countSpecials = null,
            CancellationToken cancellationToken = default)
            => GetShowWatchedProgressImplAsync(traktShowIDOrSlug, hidden, specials, countSpecials, cancellationToken);

        /// <summary>Gets watched progress for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="hidden"> If <see langword="true"/>, include hidden episodes in the progress results.</param>
        /// <param name="specials"> If <see langword="true"/>, include special episodes in the progress results.</param>
        /// <param name="countSpecials"> If <see langword="true"/>, count specials when calculating watched progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para/>If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the watched progress information.
        /// <para/>
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and the appropriate response type for watched progress.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/get-show-watched-progress">
        /// Trakt API Documentation: Shows: Watched Progress - Get show watched progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowWatchedProgress>> GetShowWatchedProgressAsync(uint traktShowID, bool? hidden = null, bool? specials = null, bool? countSpecials = null,
            CancellationToken cancellationToken = default)
            => GetShowWatchedProgressImplAsync(traktShowID.ToInvariantCultureString(), hidden, specials, countSpecials, cancellationToken);

        /// <summary>Gets watched progress for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="hidden"> If <see langword="true"/>, include hidden episodes in the progress results.</param>
        /// <param name="specials"> If <see langword="true"/>, include special episodes in the progress results.</param>
        /// <param name="countSpecials"> If <see langword="true"/>, count specials when calculating watched progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para/>If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the watched progress information.
        /// <para/>
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and the appropriate response type for watched progress.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/get-show-watched-progress">
        /// Trakt API Documentation: Shows: Watched Progress - Get show watched progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowWatchedProgress>> GetShowWatchedProgressAsync(TraktShowIDs showIDs, bool? hidden = null, bool? specials = null, bool? countSpecials = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetShowWatchedProgressImplAsync(showIDs.BestID, hidden, specials, countSpecials, cancellationToken);
        }
    }
}
