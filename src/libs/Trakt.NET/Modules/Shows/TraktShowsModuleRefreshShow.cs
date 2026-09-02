namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>Refreshs a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.
        /// <para>Queues a show for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
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
        /// <para><see href="https://docs.trakt.tv/reference/postshowsrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> RefreshShowAsync(string traktShowIDOrSlug, CancellationToken cancellationToken = default)
            => RefreshShowAsync(traktShowIDOrSlug, null, cancellationToken);

        /// <summary>Refreshs a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.
        /// <para>Queues a show for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="images">Determines whether images should also be refreshed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postshowsrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> RefreshShowAsync(string traktShowIDOrSlug, bool? images, CancellationToken cancellationToken = default)
            => RefreshShowImplAsync(traktShowIDOrSlug, images, cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktShow" /> with the specified Trakt-ID.
        /// <para>Queues a show for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
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
        /// <para><see href="https://docs.trakt.tv/reference/postshowsrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse> RefreshShowAsync(uint traktShowID, CancellationToken cancellationToken = default)
            => RefreshShowAsync(traktShowID, null, cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktShow" /> with the specified Trakt-ID.
        /// <para>Queues a show for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="images">Determines whether images should also be refreshed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postshowsrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse> RefreshShowAsync(uint traktShowID, bool? images, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return RefreshShowImplAsync(traktShowID.ToInvariantCultureString(), images, cancellationToken);
        }

        /// <summary>
        /// Refreshs a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.
        /// <para>Queues a show for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
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
        /// <para><see href="https://docs.trakt.tv/reference/postshowsrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse> RefreshShowAsync(TraktShowIDs showIDs, CancellationToken cancellationToken = default)
            => RefreshShowAsync(showIDs, null, cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.
        /// <para>Queues a show for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="images">Determines whether images should also be refreshed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postshowsrefresh">
        /// Trakt API Documentation: Shows: Refresh - Refresh show metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse> RefreshShowAsync(TraktShowIDs showIDs, bool? images, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return RefreshShowImplAsync(showIDs.BestID, images, cancellationToken);
        }
    }
}
