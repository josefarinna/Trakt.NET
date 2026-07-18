namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to smart lists.<para />
    /// This module contains all methods of the Trakt API Documentation - SmartLists section relating to smart lists.
    /// </summary>
    public sealed partial class TraktSmartListsModule
    {
        /// <summary>Gets a single smart list definition by its globally-unique slug.</summary>
        /// <param name="listIdOrSlug">The id or slug of the smart list, which should be queried.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listssummary">
        /// Trakt API Documentation: Lists: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(string listIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetSmartListImplAsync(listIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets a single smart list definition by its Trakt ID.</summary>
        /// <param name="traktListId">The Trakt-ID of the smart list, which should be queried.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listssummary">
        /// Trakt API Documentation: Lists: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(uint traktListId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetSmartListAsync(traktListId.ToInvariantCultureString(), extendedInfo, cancellationToken);
        }

        /// <summary>Gets a single smart list definition by its IDs.</summary>
        /// <param name="listIds">The ids of the smart list, which should be queried.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listssummary">
        /// Trakt API Documentation: Lists: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(TraktListIDs listIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetSmartListAsync(listIds.BestID, extendedInfo, cancellationToken);
        }

        /// <summary>Gets a single smart list definition by its object reference.</summary>
        /// <param name="list">The smart list, which should be queried.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listssummary">
        /// Trakt API Documentation: Lists: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(TraktSmartList list, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);
            return GetSmartListAsync(list.IDs!, extendedInfo, cancellationToken);
        }

        /// <summary>Gets items of a smart list.</summary>
        /// <param name="listIdOrSlug">The id or slug of the smart list, for which items should be retrieved.</param>
        /// <param name="type">The media type of items to retrieve. See also <seealso cref="TraktSmartListMediaType" />.</param>
        /// <param name="sortBy">The sort field. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The sort direction. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="filter">Optional filters. See also <seealso cref="TraktFilter" />.</param>
        /// <param name="watchnow">Optional watchnow streaming service options.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="page">The page number of items to retrieve.</param>
        /// <param name="limit">The page limit of items to retrieve.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the retrieved smart list items.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listsitems">
        /// Trakt API Documentation: Lists: Smart List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetSmartListItemsAsync(
            string listIdOrSlug, TraktSmartListMediaType type, TraktSortBy sortBy, TraktSortHow sortHow,
            TraktFilter? filter = null, string? watchnow = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSmartListItemsImplAsync(listIdOrSlug, type, sortBy, sortHow, filter, watchnow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets items of a smart list.</summary>
        /// <param name="traktListId">The Trakt-ID of the smart list, for which items should be retrieved.</param>
        /// <param name="type">The media type of items to retrieve. See also <seealso cref="TraktSmartListMediaType" />.</param>
        /// <param name="sortBy">The sort field. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The sort direction. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="filter">Optional filters. See also <seealso cref="TraktFilter" />.</param>
        /// <param name="watchnow">Optional watchnow streaming service options.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="page">The page number of items to retrieve.</param>
        /// <param name="limit">The page limit of items to retrieve.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the retrieved smart list items.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listsitems">
        /// Trakt API Documentation: Lists: Smart List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetSmartListItemsAsync(
            uint traktListId, TraktSmartListMediaType type, TraktSortBy sortBy, TraktSortHow sortHow,
            TraktFilter? filter = null, string? watchnow = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetSmartListItemsAsync(traktListId.ToInvariantCultureString(), type, sortBy, sortHow, filter, watchnow, extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>Gets items of a smart list.</summary>
        /// <param name="listIds">The ids of the smart list, for which items should be retrieved.</param>
        /// <param name="type">The media type of items to retrieve. See also <seealso cref="TraktSmartListMediaType" />.</param>
        /// <param name="sortBy">The sort field. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The sort direction. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="filter">Optional filters. See also <seealso cref="TraktFilter" />.</param>
        /// <param name="watchnow">Optional watchnow streaming service options.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="page">The page number of items to retrieve.</param>
        /// <param name="limit">The page limit of items to retrieve.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the retrieved smart list items.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listsitems">
        /// Trakt API Documentation: Lists: Smart List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetSmartListItemsAsync(
            TraktListIDs listIds, TraktSmartListMediaType type, TraktSortBy sortBy, TraktSortHow sortHow,
            TraktFilter? filter = null, string? watchnow = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetSmartListItemsAsync(listIds.BestID, type, sortBy, sortHow, filter, watchnow, extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>Gets items of a smart list.</summary>
        /// <param name="list">The smart list, for which items should be retrieved.</param>
        /// <param name="type">The media type of items to retrieve. See also <seealso cref="TraktSmartListMediaType" />.</param>
        /// <param name="sortBy">The sort field. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The sort direction. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="filter">Optional filters. See also <seealso cref="TraktFilter" />.</param>
        /// <param name="watchnow">Optional watchnow streaming service options.</param>
        /// <param name="extendedInfo">The extended information options. See also <seealso cref="TraktExtendedInfo" />.</param>
        /// <param name="page">The page number of items to retrieve.</param>
        /// <param name="limit">The page limit of items to retrieve.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be caught.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the retrieved smart list items.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktListItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getsmart_listsitems">
        /// Trakt API Documentation: Lists: Smart List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktPagedResponse<TraktListItem>> GetSmartListItemsAsync(
            TraktSmartList list, TraktSmartListMediaType type, TraktSortBy sortBy, TraktSortHow sortHow,
            TraktFilter? filter = null, string? watchnow = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);
            return GetSmartListItemsAsync(list.IDs!, type, sortBy, sortHow, filter, watchnow, extendedInfo, page, limit, cancellationToken);
        }
    }
}
