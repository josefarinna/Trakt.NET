namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to sync.
    /// <para>This module contains all methods of the "Trakt API Documentation - Sync" section.</para>
    /// </summary>
    public sealed partial class TraktSyncModule
    {
        /// <summary>Gets the user's last activities.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried last activities.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncLastActivities" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynclastactivities">
        /// Trakt API Documentation: Sync: Last Activities
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
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
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried updated movies.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktFavorite" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getsyncfavoritesget">
        /// Trakt API Documentation: Sync: Get Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktFavorite>> GetFavoritesAsync(TraktFavoriteObjectType? favoriteObjectType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetFavoritesImplAsync(favoriteObjectType, sortBy, sortHow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Reorder all user's favorites.</summary>
        /// <param name="reorderedFavoritedItemRanks">A collection of list ids. Represents the new order of an user's favorites.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncfavoritesreorder">
        /// Trakt API Documentation: Sync: Reorder Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderFavoritedItemsAsync(List<uint> reorderedFavoritedItemRanks,
            CancellationToken cancellationToken = default)
            => ReorderFavoritedItemsImplAsync(reorderedFavoritedItemRanks, cancellationToken);

        /// <summary>Update the notes on a single favorite item.</summary>
        /// <param name="listItemId">The id of the favorite item which should be updated.</param>
        /// <param name="notes">The new favorite item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putsyncfavoritesupdateitem">
        /// Trakt API Documentation: Sync: Update Favorite Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdateFavoriteItemAsync(uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
            => UpdateFavoriteItemImplAsync(listItemId, notes, cancellationToken);

        /// <summary>Gets the user's saved playback progress of scrobbles that are paused.</summary>
        /// <param name="objectType">Determines, which type of items should be queried. By default, all types will be returned. See also <seealso cref="TraktSyncType" />.</param>
        /// <param name="startAt">Determines an optional start date and time for a range of the returned playback progress.</param>
        /// <param name="endAt">Determines an optional end date and time for a range of the returned playback progress.</param>
        /// <param name="filter">
        /// The filter, which determines the criteria about the playback progress items should be queried.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the playback progress items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried popular movies.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSyncPlaybackProgressItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncprogressplayback">
        /// Trakt API Documentation: Sync: Playback
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSyncPlaybackProgressItem>> GetPlaybackProgressAsync(TraktSyncType? objectType = null,
            DateTime? startAt = null, DateTime? endAt = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetPlaybackProgressImplAsync(objectType, startAt, endAt, filter, extendedInfo, page, limit, cancellationToken);

        /// <summary>Removes a playback progress item from the user's playback progress list.</summary>
        /// <param name="playbackId">The id of the playback progress item, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deletesyncprogressdropmovie">
        /// Trakt API Documentation: Sync: Remove Playback
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> RemovePlaybackItemAsync(uint playbackId, CancellationToken cancellationToken = default)
            => RemovePlaybackItemImplAsync(playbackId, cancellationToken);

        /// <summary>Gets all collected movies in the user's collection.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried collected movies.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionMovie" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionall">
        /// Trakt API Documentation: Sync: Get Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktSyncCollectionMovie>> GetCollectionMoviesAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCollectionMoviesImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets all collected shows in the user's collection.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried collected shows.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionall">
        /// Trakt API Documentation: Sync: Get Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktSyncCollectionShow>> GetCollectionShowsAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCollectionShowsImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets the user's minimal movie collection.</summary>
        /// <param name="availableOn">Optional filter for streaming services.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried minimal movie collection.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionminimalmovies">
        /// Trakt API Documentation: Sync: Get minimal movie collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetMinimalMovieCollectionAsync(string? availableOn = null,
            CancellationToken cancellationToken = default)
            => GetMinimalMovieCollectionImplAsync(availableOn, cancellationToken);

        /// <summary>Gets the user's minimal show collection.</summary>
        /// <param name="availableOn">Optional filter for streaming services.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried minimal show collection.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionminimalshows">
        /// Trakt API Documentation: Sync: Get minimal show collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>> GetMinimalShowCollectionAsync(string? availableOn = null,
            CancellationToken cancellationToken = default)
            => GetMinimalShowCollectionImplAsync(availableOn, cancellationToken);

        /// <summary>Gets the user's minimal episode collection.</summary>
        /// <param name="availableOn">Optional filter for streaming services.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried minimal episode collection.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynccollectionminimalepisodes">
        /// Trakt API Documentation: Sync: Get minimal episode collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetMinimalEpisodeCollectionAsync(string? availableOn = null,
            CancellationToken cancellationToken = default)
            => GetMinimalEpisodeCollectionImplAsync(availableOn, cancellationToken);

        /// <summary>Adds items to the user's collection. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="collectionPost">An <see cref="TraktSyncCollectionPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were added and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postsynccollectionadd">
        /// Trakt API Documentation: Sync: Add to Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncCollectionPostResponse>> AddCollectionItemsAsync(TraktSyncCollectionPost collectionPost,
            CancellationToken cancellationToken = default)
            => AddCollectionItemsImplAsync(collectionPost, cancellationToken);

        /// <summary>Removes items from the user's collection. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="collectionRemovePost">An <see cref="TraktSyncCollectionRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncCollectionPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsynccollectionremove">
        /// Trakt API Documentation: Sync: Remove from Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
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
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watched movies.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedMovie" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatched">
        /// Trakt API Documentation: Sync: Get Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktWatchedMovie>> GetWatchedMoviesAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedMoviesImplAsync(extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all shows the user has watched, sorted by most plays.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watched shows.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatched">
        /// Trakt API Documentation: Sync: Get Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktWatchedShow>> GetWatchedShowsAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedShowsImplAsync(extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets watched progress for the authenticated user.</summary>
        /// <param name="sortBy">The field to sort by. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The direction to sort in. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="lifetimeStats">
        /// When true, progress.completed and progress.stats reflect lifetime totals across all watches of the show.
        /// </param>
        /// <param name="hideCompleted">Specifies whether completed shows should be hidden.</param>
        /// <param name="hideNotCompleted">Specifies whether incomplete shows should be hidden.</param>
        /// <param name="onlyRewatching">
        /// When true, restrict the list to shows the user is currently rewatching.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried show watched progress items.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSyncProgressWatchedItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncprogresswatched">
        /// Trakt API Documentation: Sync: Get watched progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSyncProgressWatchedItem>> GetWatchedProgressAsync(TraktSortBy? sortBy = null,
            TraktSortHow? sortHow = null, bool? lifetimeStats = null, bool? hideCompleted = null, bool? hideNotCompleted = null,
            bool? onlyRewatching = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetWatchedProgressImplAsync(sortBy, sortHow, lifetimeStats, hideCompleted, hideNotCompleted, onlyRewatching, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets up next progress for the authenticated user.</summary>
        /// <param name="sortBy">The field to sort by. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The direction to sort in. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="includeStats">Specifies whether to include watch stats in the response.</param>
        /// <param name="lifetimeStats">
        /// When true, progress.completed and progress.stats reflect lifetime totals across all watches of the show.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried show up next progress items.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSyncProgressWatchedItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncprogressupnextstandard">
        /// Trakt API Documentation: Sync: Get up next
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSyncProgressWatchedItem>> GetUpNextProgressAsync(TraktSortBy? sortBy = null,
            TraktSortHow? sortHow = null, bool? includeStats = null, bool? lifetimeStats = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetUpNextProgressImplAsync(sortBy, sortHow, includeStats, lifetimeStats, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets up next nitro progress for the authenticated user.</summary>
        /// <param name="sortBy">The field to sort by. See also <seealso cref="TraktSortBy" />.</param>
        /// <param name="sortHow">The direction to sort in. See also <seealso cref="TraktSortHow" />.</param>
        /// <param name="intent">The intent of the up next request. See also <seealso cref="TraktUpNextIntent" />.</param>
        /// <param name="watchNow">Watch now filter parameter.</param>
        /// <param name="filter">Optional filters. See also <seealso cref="TraktFilter" />.</param>
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried show up next nitro progress items.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSyncProgressWatchedItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncprogressupnextnitro">
        /// Trakt API Documentation: Sync: Get up next nitro
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSyncProgressWatchedItem>> GetUpNextNitroProgressAsync(TraktSortBy? sortBy = null,
            TraktSortHow? sortHow = null, TraktUpNextIntent? intent = null, string? watchNow = null, TraktFilter? filter = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetUpNextNitroProgressImplAsync(sortBy, sortHow, intent, watchNow, filter, page, limit, cancellationToken);

        /// <summary>Gets all episodes the user has watched, sorted by most plays.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episodes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watched episodes.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedEpisode" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatched">
        /// Trakt API Documentation: Sync: Get Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktWatchedEpisode>> GetWatchedEpisodesAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedEpisodesImplAsync(extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all movies, shows, seasons and / or episodes the user has watched, sorted by most recent.</summary>
        /// <param name="historyItemType">Determines, which type of history items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="itemId">The Trakt Id for the item, which should be specifically queried. Will be ignored, if <paramref name="historyItemType" /> is not set or unspecified.</param>
        /// <param name="startAt">The datetime, after which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="endAt">The datetime, until which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="filter">
        /// The filter, which determines the criteria about the history items should be queried.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the history items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried history items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktHistoryItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsynchistoryget">
        /// Trakt API Documentation: Sync: Get History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktHistoryItem>> GetWatchedHistoryAsync(TraktSyncItemType? historyItemType = null, uint? itemId = null,
            DateTime? startAt = null, DateTime? endAt = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedHistoryImplAsync(historyItemType, itemId, startAt, endAt, filter, extendedInfo, page, limit, cancellationToken);

        /// <summary>Adds items to the user's watch history. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="historyPost">An <see cref="TraktSyncHistoryPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were added and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovie" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsynchistoryadd">
        /// Trakt API Documentation: Sync: Add to History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncHistoryPostResponse>> AddWatchedHistoryItemsAsync(TraktSyncHistoryPost historyPost,
            CancellationToken cancellationToken = default)
            => AddWatchedHistoryItemsImplAsync(historyPost, cancellationToken);

        /// <summary>Removes items from the user's watch history. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="historyRemovePost">An <see cref="TraktSyncHistoryRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were deleted and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncHistoryRemovePostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsynchistoryremove">
        /// Trakt API Documentation: Sync: Remove from History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
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
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried rating items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRatingsItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsyncratingsget">
        /// Trakt API Documentation: Sync: Get Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktRatingsItem>> GetRatingsAsync(TraktRatingsItemType? ratingsItemType = null,
            int[]? ratingsFilter = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetRatingsImplAsync(ratingsItemType, ratingsFilter, extendedInfo, page, limit, cancellationToken);

        /// <summary>Adds items to the user's ratings. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="ratingsPost">An <see cref="TraktSyncRatingsPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were added and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncRatingsPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncratingsadd">
        /// Trakt API Documentation: Sync: Add Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncRatingsPostResponse>> AddRatingsAsync(TraktSyncRatingsPost ratingsPost,
            CancellationToken cancellationToken = default)
            => AddRatingsImplAsync(ratingsPost, cancellationToken);

        /// <summary>Removes items from the user's ratings. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="ratingsRemovePost">An <see cref="TraktSyncRatingsRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were deleted and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncRatingsRemovePostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncratingsremove">
        /// Trakt API Documentation: Sync: Remove Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncRatingsRemovePostResponse>> RemoveRatingsAsync(TraktSyncRatingsRemovePost ratingsRemovePost,
            CancellationToken cancellationToken = default)
            => RemoveRatingsImplAsync(ratingsRemovePost, cancellationToken);

        /// <summary>Adds items to the user's favorites. Accepts movies and shows.</summary>
        /// <param name="favoritesPost">An <see cref="TraktSyncFavoritesPost" /> instance containing all movies and shows, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were added and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncFavoritesPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncfavoritesadd">
        /// Trakt API Documentation: Sync: Add to Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncFavoritesPostResponse>> AddFavoriteItemsAsync(TraktSyncFavoritesPost favoritesPost,
            CancellationToken cancellationToken = default)
            => AddFavoriteItemsImplAsync(favoritesPost, cancellationToken);

        /// <summary>Remove items from the user's favorites. Accepts movies and shows.</summary>
        /// <param name="favoritesRemovePost">An <see cref="TraktSyncFavoritesRemovePost" /> instance containing all movies and shows, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing which items were removed and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncFavoritesRemovePostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncfavoritesremove">
        /// Trakt API Documentation: Sync: Remove from Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
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
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the updated favorites list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putsyncfavoritesupdate">
        /// Trakt API Documentation: Sync: Update Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
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
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watchlist items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchlistItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getsyncwatchlistget">
        /// Trakt API Documentation: Sync: Get Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktWatchlistItem>> GetWatchlistAsync(TraktSyncItemType? watchlistItemType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetWatchlistImplAsync(watchlistItemType, sortBy, sortHow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Reorders an user's watchlist.</summary>
        /// <param name="reorderedWatchlistItemRanks">A collection of list ids. Represents the new order of an user's watchlist.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated watchlist order.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovie" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncwatchlistreorder">
        /// Trakt API Documentation: Sync: Reorder Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderWatchlistItemsAsync(List<uint> reorderedWatchlistItemRanks,
            CancellationToken cancellationToken = default)
            => ReorderWatchlistItemsImplAsync(reorderedWatchlistItemRanks, cancellationToken);

        /// <summary>Update the notes on a watchlist item.</summary>
        /// <param name="listItemId">The id of the watchlist item which should be updated.</param>
        /// <param name="notes">The new watchlist item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/putsyncwatchlistupdateitem">
        /// Trakt API Documentation: Sync: Update Watchlist Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdateWatchlistItemAsync(uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
            => UpdateWatchlistItemImplAsync(listItemId, notes, cancellationToken);

        /// <summary>Adds items to the user's watchlist. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="watchlistPost">An <see cref="TraktSyncWatchlistPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were added, existing and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncWatchlistPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postsyncwatchlistadd">
        /// Trakt API Documentation: Sync: Add to Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSyncWatchlistPostResponse>> AddWatchlistItemsAsync(TraktSyncWatchlistPost watchlistPost,
            CancellationToken cancellationToken = default)
            => AddWatchlistItemsImplAsync(watchlistPost, cancellationToken);

        /// <summary>Removes items from the user's watchlist. Accepts shows, seasons, episodes and movies.</summary>
        /// <param name="watchlistRemovePost">An <see cref="TraktSyncWatchlistRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSyncWatchlistRemovePostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsyncwatchlistremove">
        /// Trakt API Documentation: Sync: Remove from Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
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
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the updated watchlist.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putsyncwatchlistupdate">
        /// Trakt API Documentation: Sync: Update Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> UpdateWatchlistAsync(string description, TraktSortBy? sortBy = null, TraktSortHow? sortHow = null,
            CancellationToken cancellationToken = default)
            => UpdateWatchlistImplAsync(description, sortBy, sortHow, cancellationToken);
    }
}
