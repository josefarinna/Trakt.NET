namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>
        /// Gets the items on an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-items/get-items-on-a-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, for which the items should be queried.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="TraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetPersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
            TraktListItemType? listItemType = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserPersonalListItemsGetRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                Type = listItemType,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktListItem>(_context, request, (page, limit)
                => new UserPersonalListItemsGetRequest
                {
                    Id = usernameOrSlug,
                    ListId = listIdOrSlug,
                    Type = listItemType,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        /// <summary>
        /// Gets the items on an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-items/get-items-on-a-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, for which the items should be queried.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="TraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetPersonalListItemsAsync(string usernameOrSlug, uint traktListId,
            TraktListItemType? listItemType = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetPersonalListItemsAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), listItemType, extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>
        /// Gets the items on an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-items/get-items-on-a-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be queried.</param>
        /// <param name="listIds">The ids of the personal list, for which the items should be queried.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="TraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetPersonalListItemsAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktListItemType? listItemType = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetPersonalListItemsAsync(usernameOrSlug, listIds.BestID, listItemType, extendedInfo,
                                             page, limit, cancellationToken);
        }

        /// <summary>
        /// Gets the items on an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-items/get-items-on-a-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be queried.</param>
        /// <param name="list">The personal list, for which the items should be queried.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="TraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetPersonalListItemsAsync(string usernameOrSlug, TraktList list,
            TraktListItemType? listItemType = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return GetPersonalListItemsAsync(usernameOrSlug, list.IDs!, listItemType, extendedInfo,
                                             page, limit, cancellationToken);
        }
    }
}
