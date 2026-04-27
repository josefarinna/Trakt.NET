namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets all likes for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the likes should be queried.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list likes.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListLike" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">
        /// Trakt API Documentation - Users: List Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktListLike>> GetListLikesAsync(string usernameOrSlug, string listIdOrSlug,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetListLikesImplAsync(usernameOrSlug, listIdOrSlug, page, limit, cancellationToken);

        /// <summary>Gets all likes for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the likes should be queried.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list likes.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListLike" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">
        /// Trakt API Documentation - Users: List Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktListLike>> GetListLikesAsync(string usernameOrSlug, uint traktListId,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListLikesAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), page, limit, cancellationToken);
        }

        /// <summary>Gets all likes for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="listIds">The ids of the list, for which the likes should be queried.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list likes.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListLike" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">
        /// Trakt API Documentation - Users: List Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<TraktListLike>> GetListLikesAsync(string usernameOrSlug, TraktListIDs listIds,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetListLikesAsync(usernameOrSlug, listIds.BestID, page, limit, cancellationToken);
        }

        /// <summary>Gets all likes for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="list">The list, for which the likes should be queried.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list likes.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListLike" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">
        /// Trakt API Documentation - Users: List Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktPagedResponse<TraktListLike>> GetListLikesAsync(string usernameOrSlug, TraktList list,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return GetListLikesAsync(usernameOrSlug, list.IDs!, page, limit, cancellationToken);
        }
    }
}
