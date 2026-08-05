namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Deletes an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserslistslistdelete">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        public Task<TraktResponse> DeletePersonalListAsync(string usernameOrSlug, string listIdOrSlug, CancellationToken cancellationToken = default)
            => DeletePersonalListImplAsync(usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>Deletes an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="traktListId">The Trakt-ID of the list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserslistslistdelete">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> DeletePersonalListAsync(string usernameOrSlug, uint traktListId, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return DeletePersonalListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Deletes an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="listIds">The ids of the list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserslistslistdelete">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> DeletePersonalListAsync(string usernameOrSlug, TraktListIDs listIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);
            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return DeletePersonalListAsync(usernameOrSlug, listIds.BestID, cancellationToken);
        }

        /// <summary>Deletes an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="list">The list, which should be deleted. See also <seealso cref="TraktList" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserslistslistdelete">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> DeletePersonalListAsync(string usernameOrSlug, TraktList list, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return DeletePersonalListAsync(usernameOrSlug, list.IDs!, cancellationToken);
        }
    }
}
