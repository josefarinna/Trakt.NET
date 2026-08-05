namespace TraktNET
{
    public sealed partial class TraktListsModule
    {
        /// <summary>Like a list.</summary>
        /// <param name="listIdOrSlug">The id or slug of the list, which will be liked. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistslike">
        /// Trakt API Documentation: Lists: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> LikeListAsync(string listIdOrSlug, CancellationToken cancellationToken = default)
            => LikeListImplAsync(listIdOrSlug, cancellationToken);

        /// <summary>Like a list.</summary>
        /// <param name="traktListId">The Trakt ID of the list, which will be liked. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistslike">
        /// Trakt API Documentation: Lists: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> LikeListAsync(uint traktListId, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return LikeListAsync(traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Like a list.</summary>
        /// <param name="listIds">The ids of the list, which will be liked. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistslike">
        /// Trakt API Documentation: Lists: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> LikeListAsync(TraktListIDs listIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return LikeListAsync(listIds.BestID, cancellationToken);
        }

        /// <summary>Like a list.</summary>
        /// <param name="list">The list, which will be liked. See also <seealso cref="TraktList" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistslike">
        /// Trakt API Documentation: Lists: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> LikeListAsync(TraktList list, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return LikeListAsync(list.IDs!, cancellationToken);
        }
    }
}
