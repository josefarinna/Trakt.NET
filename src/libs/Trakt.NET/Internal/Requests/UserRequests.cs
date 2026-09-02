namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("users/{id!!}/collection/movies", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserCollectionMoviesGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/collection/shows", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserCollectionShowsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktCommentObjectType? ObjectType { get; set; }

        [TraktRequestQuery("include_replies")]
        internal TraktIncludeReplies? IncludeReplies { get; set; }
    }

    [TraktGetRequest("users/{id!!}/favorites/comments", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserFavoritesCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? Sort { get; set; }
    }

    [TraktGetRequest("users/{id!!}/favorites", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserFavoritesGetRequest
    {
        [TraktRequestParameter]
        internal TraktFavoriteObjectType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktSortBy? SortBy { get; set; }

        [TraktRequestParameter]
        internal TraktSortHow? SortHow { get; set; }
    }

    [TraktGetRequest("users/{id!!}/followers", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserFollowersGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/following", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserFollowingGetRequest
    {
    }

    [TraktGetRequest("users/requests", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserFollowRequestsGetRequest
    {
    }

    [TraktGetRequest("users/blocked", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserBlockedUsersGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/friends", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserFriendsGetRequest
    {
    }

    [TraktGetRequest("users/hidden/", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserHiddenItemsGetRequest
    {
        [TraktRequestParameter]
        internal TraktHiddenItemsSection Section { get; set; }

        [TraktRequestQuery("type")]
        internal TraktHiddenItemType? Type { get; set; }
    }

    [TraktGetRequest("users/{id!!}/likes", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserLikesGetRequest
    {
        [TraktRequestParameter]
        internal TraktUserLikeType? Type { get; set; }
    }

    [TraktGetRequest("users/{id!!}/lists/collaborations", OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserListCollaborationsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/lists/{list_id!!}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class UserListCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? Sort { get; set; }
    }

    [TraktGetRequest("users/{id!!}/lists/{list_id!!}/likes", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserListLikesGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/notes", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserNotesGetRequest
    {
        [TraktRequestParameter]
        internal TraktNotesObjectType? Type { get; set; }
    }

    [TraktGetRequest("users/requests/following", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class UserPendingFollowingRequestsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/lists/{list_id!!}/items", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserPersonalListItemsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListItemType? Type { get; set; }
    }

    [TraktGetRequest("users/{id!!}/lists", OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserPersonalListsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserPersonalSingleListGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.User;
    }

    [TraktGetRequest("users/{id!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserProfileGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/ratings", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserRatingsGetRequest
    {
        [TraktRequestParameter]
        internal TraktRatingsItemType? Type { get; set; }

        [TraktRequestParameter]
        internal string? RatingFilter { get; set; }
    }

    [TraktGetRequest("users/saved_filters", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSavedFiltersGetRequest
    {
        [TraktRequestQuery("section")]
        internal TraktFilterSection? Section { get; set; }
    }

    [TraktGetRequest("users/settings", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSettingsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/stats", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserStatisticsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/history", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchedHistoryGetRequest
    {
        [TraktRequestParameter]
        internal TraktSyncItemType? Type { get; set; }

        [TraktRequestParameter]
        internal uint? ItemID { get; set; }

        [TraktRequestQuery("start_at", UseCacheEfficientDateTime = true)]
        internal DateTime? StartAt { get; set; }

        [TraktRequestQuery("end_at", UseCacheEfficientDateTime = true)]
        internal DateTime? EndAt { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.User;
    }

    [TraktGetRequest("users/{id!!}/watched/movies", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchedMoviesGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/watched/shows", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchedShowsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/watched/episodes", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchedEpisodesGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/watching", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchingGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/watchlist/comments", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchlistCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? Sort { get; set; }
    }

    [TraktGetRequest("users/{id!!}/watchlist", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchlistGetRequest
    {
        [TraktRequestParameter]
        internal TraktSyncItemType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktSortBy? SortBy { get; set; }

        [TraktRequestParameter]
        internal TraktSortHow? SortHow { get; set; }
    }

    [TraktGetRequest("users/settings/plex/", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexSettingsGetRequest
    {
    }

    [TraktGetRequest("users/settings/plex/servers", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexServersGetRequest
    {
    }

    [TraktGetRequest("users/settings/plex/servers/{server_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexServerAccountsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/smart-lists", OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserSmartListsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/smart-lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserSmartListGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("users/{id!!}/{type_path:TraktUserSocialActivityType!!}/activities", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserActivitiesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("users/syncs", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSyncsGetRequest
    {
    }

    [TraktGetRequest("users/syncs", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSyncsByTypeGetRequest
    {
        [TraktRequestParameter]
        internal required TraktUserSyncType Type { get; set; }
    }

    [TraktGetRequest("users/syncs/{id:ulong!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSyncDetailsGetRequest
    {
    }

    [TraktGetRequest("users/syncs/{id:ulong!!}/paused", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSyncPausedGetRequest
    {
    }

    [TraktGetRequest("users/syncs/{id:ulong!!}/skipped", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSyncSkippedGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/mir/{year:uint!!}/{month:uint!!}", SupportsExtendedInfo = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserMonthInReviewGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/yir/{year:uint!!}", SupportsExtendedInfo = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserYearInReviewGetRequest
    {
    }

    [TraktGetRequest("users/reactions/comments", SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserCommentReactionsGetRequest
    {
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("users/requests/{id:uint!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserApproveFollowerPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.User;
    }

    [TraktPostRequest("users/{id!!}/follow", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserFollowUserPostRequest
    {
    }

    [TraktPostRequest("users/{id!!}/block", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserBlockUserPostRequest
    {
    }

    [TraktPostRequest("users/hidden", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserHiddenItemsAddPostRequest
    {
        [TraktRequestParameter]
        internal TraktHiddenItemsSection Section { get; set; }

        [TraktRequestPayload]
        internal required TraktUserHiddenItemsPost TraktUserHiddenItemsPost { get; set; }
    }

    [TraktPostRequest("users/hidden/{section:TraktHiddenItemsSection!!}/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserHiddenItemsRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktUserHiddenItemsRemovePost TraktUserHiddenItemsRemovePost { get; set; }
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserListLikePostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktUserPersonalListPost TraktUserPersonalListPost { get; set; }
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/items", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemsAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktUserPersonalListItemsPost TraktUserPersonalListItemsPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/items/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemsRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktUserPersonalListItemsRemovePost TraktUserPersonalListItemsRemovePost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/items/reorder", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemsReorderPostRequest
    {
        [TraktRequestPayload]
        internal required TraktListItemsReorderPost TraktListItemsReorderPost { get; set; }
    }

    [TraktPostRequest("users/{id!!}/lists/reorder", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListsReorderPostRequest
    {
        [TraktRequestPayload]
        internal required TraktListItemsReorderPost TraktListItemsReorderPost { get; set; }
    }

    [TraktPostRequest("users/{id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }
    }

    [TraktPostRequest("users/settings/plex/connect", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexConnectPostRequest
    {
        [TraktRequestPayload]
        internal required TraktPlexConnectPost TraktPlexConnectPost { get; set; }
    }

    [TraktPostRequest("users/settings/plex/sync", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexSyncPostRequest
    {
        [TraktRequestPayload]
        internal required TraktPlexSyncPost TraktPlexSyncPost { get; set; }
    }

    [TraktPostRequest("users/{id!!}/smart-lists", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSmartListAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSmartListPost TraktSmartListPost { get; set; }
    }

    // -------------------------------------------------------
    // PUT Requests
    // -------------------------------------------------------

    [TraktPutRequest("users/settings", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSettingsSavePutRequest
    {
        [TraktRequestPayload]
        internal required TraktUserSettingsPost TraktUserSettingsPost { get; set; }
    }

    [TraktPutRequest("users/{id!!}/lists/{list_id!!}/items", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemUpdatePutRequest
    {
        [TraktRequestParameter]
        internal uint ListItemId { get; set; }

        [TraktRequestPayload]
        internal required TraktListItemUpdatePost TraktListItemUpdatePost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPutRequest("users/{id!!}/lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListUpdatePutRequest
    {
        [TraktRequestPayload]
        internal TraktUserPersonalListPost? TraktUserPersonalListPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPutRequest("users/settings/plex/", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexSettingsPutRequest
    {
        [TraktRequestPayload]
        internal required TraktPlexSettingsUpdate TraktPlexSettingsUpdate { get; set; }
    }

    [TraktPutRequest("users/{id!!}/smart-lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSmartListUpdatePutRequest
    {
        [TraktRequestPayload]
        internal TraktSmartListPost? TraktSmartListPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPutRequest("users/avatar", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserAvatarPutRequest
    {
        [TraktRequestPayload]
        internal required TraktUserAvatarPost TraktUserAvatarPost { get; set; }
    }

    [TraktPutRequest("users/set_cover", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserCoverPutRequest
    {
        [TraktRequestPayload]
        internal required TraktUserCoverPost TraktUserCoverPost { get; set; }
    }

    [TraktPostRequest("users/saved_filters", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSavedFilterAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktUserSavedFilterPost TraktUserSavedFilterPost { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("users/requests/{id:uint!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserDenyFollowerDeleteRequest
    {
    }

    [TraktDeleteRequest("users/{id!!}/lists/{list_id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserListUnlikeDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktDeleteRequest("users/{id!!}/lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktDeleteRequest("users/{id!!}/follow", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserUnfollowUserDeleteRequest
    {
    }

    [TraktDeleteRequest("users/{id!!}/block", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserUnblockUserDeleteRequest
    {
    }

    [TraktDeleteRequest("users/settings/plex/disconnect", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPlexDisconnectDeleteRequest
    {
    }

    [TraktDeleteRequest("users/{id!!}/smart-lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSmartListDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktDeleteRequest("users/syncs/{id:ulong!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSyncUndoDeleteRequest
    {
    }

    [TraktDeleteRequest("users/saved_filters/{id:uint!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserSavedFilterDeleteRequest
    {
    }
}
