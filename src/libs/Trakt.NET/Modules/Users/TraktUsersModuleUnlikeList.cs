namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Removes like on an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which a like on a list should be removed.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which a like should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-like/remove-like-on-a-list">
        /// Trakt API Documentation: Users: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UnlikeListAsync(string usernameOrSlug, string listIdOrSlug, CancellationToken cancellationToken = default)
            => UnlikeListImplAsync(usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>Removes like on an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which a like on a list should be removed.</param>
        /// <param name="traktListId">The Trakt-ID or slug of the list, for which a like should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-like/remove-like-on-a-list">
        /// Trakt API Documentation: Users: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> UnlikeListAsync(string usernameOrSlug, uint traktListId, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UnlikeListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Removes like on an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which a like on a list should be removed.</param>
        /// <param name="listIds">The ids of the list, for which a like should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-like/remove-like-on-a-list">
        /// Trakt API Documentation: Users: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> UnlikeListAsync(string usernameOrSlug, TraktListIDs listIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UnlikeListAsync(usernameOrSlug, listIds.BestID, cancellationToken);
        }

        /// <summary>Removes like on an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which a like on a list should be removed.</param>
        /// <param name="list">The list, for which a like should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-like/remove-like-on-a-list">
        /// Trakt API Documentation: Users: List Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> UnlikeListAsync(string usernameOrSlug, TraktList list, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return UnlikeListAsync(usernameOrSlug, list.IDs!, cancellationToken);
        }
    }
}
