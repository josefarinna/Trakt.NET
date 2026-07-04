namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to sync.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/sync">"Trakt API Documentation - Sync"</a> section.
    /// </summary>
    public sealed partial class TraktSyncModule
    {
        /// <summary>Gets the user's last activities.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried last activities.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncLastActivities" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynclastactivities">
        /// Trakt API Documentation: Sync: Last Activities
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<TraktSyncLastActivities>> GetLastActivitiesAsync(CancellationToken cancellationToken = default)
            => GetLastActivitiesImplAsync(cancellationToken);

        /// <summary>Gets an user's favorite movies and / or shows.</summary>
        /// <param name="favoriteObjectType">Determines, which type of favorite items should be queried. See also <seealso cref="TraktFavoriteObjectType" />.</param>
        /// <param name="sortBy">
        /// The favorites sort order. See also <seealso cref="TraktSortBy" />.
        /// Will be ignored, if the given <paramref name="favoriteObjectType" /> is null or unspecified.
        /// </param>
        /// <param name="sortHow">
        /// The favorites sort order. See also <seealso cref="TraktSortHow" />.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the favorite items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried updated movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktFavorite" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getsyncfavoritesget">
        /// Trakt API Documentation: Sync: Get Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktFavorite>> GetFavoritesAsync(TraktFavoriteObjectType? favoriteObjectType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetFavoritesImplAsync(favoriteObjectType, sortBy, sortHow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Reorder all user's favorites.</summary>
        /// <param name="reorderedFavoritedItemRanks">A collection of list ids. Represents the new order of an user's favorites.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncfavoritesreorder">
        /// Trakt API Documentation: Sync: Reorder Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderFavoritedItemsAsync(List<uint> reorderedFavoritedItemRanks,
            CancellationToken cancellationToken = default)
            => ReorderFavoritedItemsImplAsync(reorderedFavoritedItemRanks, cancellationToken);

        /// <summary>Update the notes on a single favorite item.</summary>
        /// <param name="listItemId">The id of the favorite item which should be updated.</param>
        /// <param name="notes">The new favorite item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putsyncfavoritesupdateitem">
        /// Trakt API Documentation: Sync: Update Favorite Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdateFavoriteItemAsync(uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
            => UpdateFavoriteItemImplAsync(listItemId, notes, cancellationToken);

        /// <summary>Gets the user's saved playback progress of scrobbles that are paused.</summary>
        /// <param name="objectType">Determines, which type of items should be queried. By default, all types will be returned. See also <seealso cref="TraktSyncType" />.</param>
        /// <param name="startAt">Determines an optional start date and time for a range of the returned playback progress.</param>
        /// <param name="endAt">Determines an optional end date and time for a range of the returned playback progress.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried popular movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSyncPlaybackProgressItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncprogressplayback">
        /// Trakt API Documentation: Sync: Playback
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSyncPlaybackProgressItem>> GetPlaybackProgressAsync(TraktSyncType? objectType = null,
            DateTime? startAt = null, DateTime? endAt = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetPlaybackProgressImplAsync(objectType, startAt, endAt, page, limit, cancellationToken);

        /// <summary>Removes a playback progress item from the user's playback progress list.</summary>
        /// <param name="playbackId">The id of the playback progress item, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deletesyncprogressdropmovie">
        /// Trakt API Documentation: Sync: Remove Playback
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> RemovePlaybackItemAsync(uint playbackId, CancellationToken cancellationToken = default)
            => RemovePlaybackItemImplAsync(playbackId, cancellationToken);

        /// <summary>Gets all collected movies in the user's collection.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried collected movies.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionall">
        /// Trakt API Documentation: Sync: Get Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktSyncCollectionMovie>> GetCollectionMoviesAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCollectionMoviesImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets all collected shows in the user's collection.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried collected shows.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionShow" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionall">
        /// Trakt API Documentation: Sync: Get Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktSyncCollectionShow>> GetCollectionShowsAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCollectionShowsImplAsync(extendedInfo, cancellationToken);

        /// <summary>Adds items to the user's collection. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="collectionPost">An <see cref="TraktSyncCollectionPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were added and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postsynccollectionadd">
        /// Trakt API Documentation: Sync: Add to Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncCollectionPostResponse>> AddCollectionItemsAsync(TraktSyncCollectionPost collectionPost,
            CancellationToken cancellationToken = default)
            => AddCollectionItemsImplAsync(collectionPost, cancellationToken);

        /// <summary>Removes items from the user's collection. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="collectionRemovePost">An <see cref="TraktSyncCollectionRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsynccollectionremove">
        /// Trakt API Documentation: Sync: Remove from Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncCollectionRemovePostResponse>> RemoveCollectionItemsAsync(TraktSyncCollectionRemovePost collectionRemovePost,
            CancellationToken cancellationToken = default)
            => RemoveCollectionItemsImplAsync(collectionRemovePost, cancellationToken);

        /// <summary>Gets all movies the user has watched, sorted by most plays.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried box office movies.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatched">
        /// Trakt API Documentation: Sync: Get Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktWatchedMovie>> GetWatchedMoviesAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetWatchedMoviesImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets all shows the user has watched, sorted by most plays.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried box office movies.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedShow" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatched">
        /// Trakt API Documentation: Sync: Get Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktWatchedShow>> GetWatchedShowsAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetWatchedShowsImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets all movies, shows, seasons and / or episodes the user has watched, sorted by most recent.</summary>
        /// <param name="historyItemType">Determines, which type of history items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="itemId">The Trakt Id for the item, which should be specifically queried. Will be ignored, if <paramref name="historyItemType" /> is not set or unspecified.</param>
        /// <param name="startAt">The datetime, after which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="endAt">The datetime, until which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the history items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried history items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktHistoryItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynchistoryget">
        /// Trakt API Documentation: Sync: Get History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktHistoryItem>> GetWatchedHistoryAsync(TraktSyncItemType? historyItemType = null, uint? itemId = null,
            DateTime? startAt = null, DateTime? endAt = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetWatchedHistoryImplAsync(historyItemType, itemId, startAt, endAt, extendedInfo, page, limit, cancellationToken);

        /// <summary>Adds items to the user's watch history. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="historyPost">An <see cref="TraktSyncHistoryPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were added and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsynchistoryadd">
        /// Trakt API Documentation: Sync: Add to History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncHistoryPostResponse>> AddWatchedHistoryItemsAsync(TraktSyncHistoryPost historyPost,
            CancellationToken cancellationToken = default)
            => AddWatchedHistoryItemsImplAsync(historyPost, cancellationToken);

        /// <summary>Removes items from the user's watch history. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="historyRemovePost">An <see cref="TraktSyncHistoryRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncHistoryRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsynchistoryremove">
        /// Trakt API Documentation: Sync: Remove from History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncHistoryRemovePostResponse>> RemoveWatchedHistoryItemsAsync(TraktSyncHistoryRemovePost historyRemovePost,
            CancellationToken cancellationToken = default)
            => RemoveWatchedHistoryItemsImplAsync(historyRemovePost, cancellationToken);

        /// <summary>Gets the user's ratings for movies, shows, seasons and / or episodes.</summary>
        /// <param name="ratingsItemType">Determines, which type of rating items should be queried. See also <seealso cref="TraktRatingsItemType" />.</param>
        /// <param name="ratingsFilter">
        /// An array of numbers. Numbers should be between 1 and 10.
        /// Will be ignored, if the given array contains a number higher than 10 or below 1 or if it contains more than ten numbers.
        /// Will be ignored, if the given <paramref name="ratingsItemType" /> is null or unspecified.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the rating items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried rating items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRatingsItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncratingsget">
        /// Trakt API Documentation: Sync: Get Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktRatingsItem>> GetRatingsAsync(TraktRatingsItemType? ratingsItemType = null,
            int[]? ratingsFilter = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetRatingsImplAsync(ratingsItemType, ratingsFilter, extendedInfo, page, limit, cancellationToken);

        /// <summary>Adds items to the user's ratings. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="ratingsPost">An <see cref="TraktSyncRatingsPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were added and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncRatingsPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncratingsadd">
        /// Trakt API Documentation: Sync: Add Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncRatingsPostResponse>> AddRatingsAsync(TraktSyncRatingsPost ratingsPost,
            CancellationToken cancellationToken = default)
            => AddRatingsImplAsync(ratingsPost, cancellationToken);

        /// <summary>Removes items from the user's ratings. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="ratingsRemovePost">An <see cref="TraktSyncRatingsRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncRatingsRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncratingsremove">
        /// Trakt API Documentation: Sync: Remove Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncRatingsRemovePostResponse>> RemoveRatingsAsync(TraktSyncRatingsRemovePost ratingsRemovePost,
            CancellationToken cancellationToken = default)
            => RemoveRatingsImplAsync(ratingsRemovePost, cancellationToken);

        /// <summary>Adds items to the user's favorites. Accepts movies and shows.</summary>
        /// <param name="favoritesPost">An <see cref="TraktSyncFavoritesPost" /> instance containing all movies and shows, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were added and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncFavoritesPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncfavoritesadd">
        /// Trakt API Documentation: Sync: Add to Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncFavoritesPostResponse>> AddFavoriteItemsAsync(TraktSyncFavoritesPost favoritesPost,
            CancellationToken cancellationToken = default)
            => AddFavoriteItemsImplAsync(favoritesPost, cancellationToken);

        /// <summary>Remove items from the user's favorites. Accepts movies and shows.</summary>
        /// <param name="favoritesRemovePost">An <see cref="TraktSyncFavoritesRemovePost" /> instance containing all movies and shows, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were removed and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncFavoritesRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncfavoritesremove">
        /// Trakt API Documentation: Sync: Remove from Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncFavoritesRemovePostResponse>> RemoveFavoriteItemsAsync(TraktSyncFavoritesRemovePost favoritesRemovePost,
            CancellationToken cancellationToken = default)
            => RemoveFavoriteItemsImplAsync(favoritesRemovePost, cancellationToken);

        /// <summary>Update the favorites list by sending 1 or more parameters.</summary>
        /// <param name="description">Description for the favorites list.</param>
        /// <param name="sortBy">Sort by value for the favorites list.</param>
        /// <param name="sortHow">Sort how value for the favorites list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the updated favorites list.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putsyncfavoritesupdate">
        /// Trakt API Documentation: Sync: Update Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> UpdateFavoritesAsync(string description, TraktSortBy? sortBy = null, TraktSortHow? sortHow = null,
            CancellationToken cancellationToken = default)
            => UpdateFavoritesImplAsync(description, sortBy, sortHow, cancellationToken);

        /// <summary>Gets the user's watchlist containing movies, shows, seasons and / or episodes.</summary>
        /// <param name="watchlistItemType">Determines, which type of watchlist items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="sortBy">Sort by value for the watchlist items.</param>
        /// <param name="sortHow">Sort how value for the watchlist items.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watchlist items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watchlist items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchlistItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatchlistget">
        /// Trakt API Documentation: Sync: Get Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktWatchlistItem>> GetWatchlistAsync(TraktSyncItemType? watchlistItemType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetWatchlistImplAsync(watchlistItemType, sortBy, sortHow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Reorders an user's watchlist.</summary>
        /// <param name="reorderedWatchlistItemRanks">A collection of list ids. Represents the new order of an user's watchlist.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated watchlist order.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncwatchlistreorder">
        /// Trakt API Documentation: Sync: Reorder Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderWatchlistItemsAsync(List<uint> reorderedWatchlistItemRanks,
            CancellationToken cancellationToken = default)
            => ReorderWatchlistItemsImplAsync(reorderedWatchlistItemRanks, cancellationToken);

        /// <summary>Update the notes on a watchlist item.</summary>
        /// <param name="listItemId">The id of the watchlist item which should be updated.</param>
        /// <param name="notes">The new watchlist item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/putsyncwatchlistupdateitem">
        /// Trakt API Documentation: Sync: Update Watchlist Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdateWatchlistItemAsync(uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
            => UpdateWatchlistItemImplAsync(listItemId, notes, cancellationToken);

        /// <summary>Adds items to the user's watchlist. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="watchlistPost">An <see cref="TraktSyncWatchlistPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were added, existing and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncWatchlistPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postsyncwatchlistadd">
        /// Trakt API Documentation: Sync: Add to Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncWatchlistPostResponse>> AddWatchlistItemsAsync(TraktSyncWatchlistPost watchlistPost,
            CancellationToken cancellationToken = default)
            => AddWatchlistItemsImplAsync(watchlistPost, cancellationToken);

        /// <summary>Removes items from the user's watchlist. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="watchlistRemovePost">An <see cref="TraktSyncWatchlistRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncWatchlistRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncwatchlistremove">
        /// Trakt API Documentation: Sync: Remove from Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncWatchlistRemovePostResponse>> RemoveWatchlistItemsAsync(TraktSyncWatchlistRemovePost watchlistRemovePost,
            CancellationToken cancellationToken = default)
            => RemoveWatchlistItemsImplAsync(watchlistRemovePost, cancellationToken);

        /// <summary>Update the watchlist by sending 1 or more parameters.</summary>
        /// <param name="description">Description for the watchlist.</param>
        /// <param name="sortBy">Sort by value for the watchlist.</param>
        /// <param name="sortHow">Sort how value for the watchlist.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the updated watchlist.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putsyncwatchlistupdate">
        /// Trakt API Documentation: Sync: Update Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> UpdateWatchlistAsync(string description, TraktSortBy? sortBy = null, TraktSortHow? sortHow = null,
            CancellationToken cancellationToken = default)
            => UpdateWatchlistImplAsync(description, sortBy, sortHow, cancellationToken);
    }
}
