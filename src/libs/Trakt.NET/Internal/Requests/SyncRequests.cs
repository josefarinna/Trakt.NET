namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("sync/collection/movies", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncCollectionMoviesGetRequest
    {
    }

    [TraktGetRequest("sync/collection/shows", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncCollectionShowsGetRequest
    {
    }

    [TraktGetRequest("sync/favorites", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncFavoritesGetRequest
    {
        [TraktRequestParameter]
        internal TraktFavoriteObjectType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktSortBy? SortBy { get; set; }

        [TraktRequestParameter]
        internal TraktSortHow? SortHow { get; set; }
    }

    [TraktGetRequest("sync/last_activities", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncLastActivitiesGetRequest
    {
    }

    [TraktGetRequest("sync/playback", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncPlaybackProgressGetRequest
    {
        [TraktRequestParameter]
        internal TraktSyncType? Type { get; set; }

        [TraktRequestQuery("start_at")]
        internal DateTime? StartAt { get; set; }

        [TraktRequestQuery("end_at")]
        internal DateTime? EndAt { get; set; }
    }

    [TraktGetRequest("sync/ratings", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncRatingsGetRequest
    {
        [TraktRequestParameter]
        internal TraktRatingsItemType? Type { get; set; }

        [TraktRequestParameter]
        internal string? RatingFilter { get; set; }
    }

    [TraktGetRequest("sync/history", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchedHistoryGetRequest
    {
        [TraktRequestParameter]
        internal TraktSyncItemType? Type { get; set; }

        [TraktRequestParameter]
        internal uint? ItemId{ get; set; }

        [TraktRequestQuery("start_at")]
        internal DateTime? StartAt { get; set; }

        [TraktRequestQuery("end_at")]
        internal DateTime? EndAt { get; set; }
    }

    [TraktGetRequest("sync/watched/movies", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchedMoviesGetRequest
    {
    }

    [TraktGetRequest("sync/watched/shows", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchedShowsGetRequest
    {
    }

    [TraktGetRequest("sync/watchlist", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchlistGetRequest
    {
        [TraktRequestParameter]
        internal TraktSyncItemType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktSortBy? SortBy { get; set; }

        [TraktRequestParameter]
        internal TraktSortHow? SortHow { get; set; }
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("sync/collection", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncCollectionAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncCollectionPost TraktSyncCollectionPost { get; set; }
    }

    [TraktPostRequest("sync/collection/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncCollectionRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncCollectionRemovePost TraktSyncCollectionRemovePost { get; set; }
    }

    [TraktPostRequest("sync/favorites/reorder", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncFavoritedItemsReorderPostRequest
    {
        [TraktRequestPayload]
        internal required TraktListItemsReorderPost TraktListItemsReorderPost { get; set; }
    }

    [TraktPostRequest("sync/favorites", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncFavoritesAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncFavoritesPost TraktSyncFavoritesPost { get; set; }
    }

    [TraktPostRequest("sync/favorites/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncFavoritesRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncFavoritesRemovePost TraktSyncFavoritesRemovePost { get; set; }
    }

    [TraktPostRequest("sync/ratings", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncRatingsAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncRatingsPost TraktSyncRatingsPost { get; set; }
    }

    [TraktPostRequest("sync/ratings/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncRatingsRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncRatingsRemovePost TraktSyncRatingsRemovePost { get; set; }
    }

    [TraktPostRequest("sync/history", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchedHistoryAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncHistoryPost TraktSyncHistoryPost { get; set; }
    }

    [TraktPostRequest("sync/history/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchedHistoryRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncHistoryRemovePost TraktSyncHistoryRemovePost { get; set; }
    }

    [TraktPostRequest("sync/watchlist", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchlistAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncWatchlistPost TraktSyncWatchlistPost { get; set; }
    }

    [TraktPostRequest("sync/watchlist/reorder", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchlistItemsReorderPostRequest
    {
        [TraktRequestPayload]
        internal required TraktListItemsReorderPost TraktListItemsReorderPost { get; set; }
    }

    [TraktPostRequest("sync/watchlist/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchlistRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktSyncWatchlistRemovePost TraktSyncWatchlistRemovePost { get; set; }
    }

    // -------------------------------------------------------
    // PUT Requests
    // -------------------------------------------------------

    [TraktPutRequest("sync/favorites", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncFavoriteItemUpdatePostRequest
    {
        [TraktRequestParameter]
        internal uint ListItemId { get; set; }

        [TraktRequestPayload]
        internal TraktListItemUpdatePost? TraktListItemUpdatePost { get; set; }
    }

    [TraktPutRequest("sync/favorites", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncFavoritesUpdatePostRequest
    {
        [TraktRequestPayload]
        internal required TraktUpdateListPost TraktUpdateListPost { get; set; }
    }

    [TraktPutRequest("sync/watchlist", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchlistItemUpdatePostRequest
    {
        [TraktRequestParameter]
        internal uint ListItemId { get; set; }

        [TraktRequestPayload]
        internal TraktListItemUpdatePost? TraktListItemUpdatePost { get; set; }
    }

    [TraktPutRequest("sync/watchlist", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncWatchlistUpdatePostRequest
    {
        [TraktRequestPayload]
        internal required TraktUpdateListPost TraktUpdateListPost { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("sync/playback/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SyncPlaybackDeleteRequest
    {
    }
}
