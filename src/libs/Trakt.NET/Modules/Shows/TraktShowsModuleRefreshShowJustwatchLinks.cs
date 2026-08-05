namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>
        /// Refreshs the JustWatch links of a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postshowsjustwatchrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> RefreshShowJustWatchLinksAsync(string traktShowIDOrSlug, CancellationToken cancellationToken = default)
            => RefreshShowJustWatchLinksImplAsync(traktShowIDOrSlug, cancellationToken);

        /// <summary>
        /// Refreshs the JustWatch links of a <see cref="TraktShow" /> with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postshowsjustwatchrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse> RefreshShowJustWatchLinksAsync(uint traktShowID, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return RefreshShowJustWatchLinksAsync(traktShowID.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>
        /// Refreshs the JustWatch links of a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.
        /// </summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postshowsjustwatchrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse> RefreshShowJustWatchLinksAsync(TraktShowIDs showIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return RefreshShowJustWatchLinksAsync(showIDs.BestID, cancellationToken);
        }
    }
}
