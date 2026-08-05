namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets top level comments for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list comments should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistcomments">
        /// Trakt API Documentation: Users: List Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetListCommentsAsync(string usernameOrSlug, string listIdOrSlug,
            TraktCommentSortOrder? commentSortOrder = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetListCommentsImplAsync(usernameOrSlug, listIdOrSlug, commentSortOrder, page, limit, cancellationToken);

        /// <summary>Gets top level comments for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list comments should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistcomments">
        /// Trakt API Documentation: Users: List Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetListCommentsAsync(string usernameOrSlug, uint traktListId,
            TraktCommentSortOrder? commentSortOrder = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListCommentsAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), commentSortOrder, page, limit, cancellationToken);
        }

        /// <summary>Gets top level comments for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list comments should be queried.</param>
        /// <param name="listIds">The ids of the list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistcomments">
        /// Trakt API Documentation: Users: List Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetListCommentsAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktCommentSortOrder? commentSortOrder = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetListCommentsAsync(usernameOrSlug, listIds.BestID, commentSortOrder, page, limit, cancellationToken);
        }

        /// <summary>Gets top level comments for an user's list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list comments should be queried.</param>
        /// <param name="list">The list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried list comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistcomments">
        /// Trakt API Documentation: Users: List Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetListCommentsAsync(string usernameOrSlug, TraktList list,
            TraktCommentSortOrder? commentSortOrder = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return GetListCommentsAsync(usernameOrSlug, list.IDs!, commentSortOrder, page, limit, cancellationToken);
        }
    }
}
