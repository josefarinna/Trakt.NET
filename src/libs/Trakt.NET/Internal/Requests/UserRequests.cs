namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("users/{id!!}/collection/movies", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserCollectionMoviesGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/collection/shows", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
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

    [TraktGetRequest("users/request", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserFollowRequestsGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/friend", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserFriendGetRequest
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
        [TraktRequestQuery("type")]
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

    [TraktGetRequest("users/{id!!}/watched/movies", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchedMoviesGetRequest
    {
    }

    [TraktGetRequest("users/{id!!}/watched/shows", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchedShowsGetRequest
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
        internal TraktCommentSortOrder Sort { get; set; }
    }

    [TraktGetRequest("users/{id!!}/watchlist", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class UserWatchlistGetRequest
    {
        [TraktRequestParameter]
        internal TraktSyncItemType Type { get; set; }

        [TraktRequestParameter]
        internal TraktSortBy? SortBy { get; set; }

        [TraktRequestParameter]
        internal TraktSortHow? SortHow { get; set; }
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("users/request/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserApproveFollowerPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.User;
    }

    [TraktPostRequest("users/{id!!}/follow", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserFollowRequestsPostRequest
    {
    }

    [TraktPostRequest("users/hidden", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserHiddenItemsAddPostRequest
    {
        [TraktRequestParameter]
        internal TraktHiddenItemsSection Section { get; set; }
    }

    [TraktPostRequest("users/hidden/{section:TraktHiddenItemsSection!!}/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserHiddenItemsRemovePostRequest
    {
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserListLikePostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListAddPostRequest
    {
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/items", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemsAddPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/items/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemsRemovePostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("users/{id!!}/lists/{list_id!!}/items/reorder", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemsReorderPostRequest
    {
    }

    [TraktPostRequest("users/{id!!}/lists/reorder", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListsReorderPostRequest
    {
    }

    // -------------------------------------------------------
    // PUT Requests
    // -------------------------------------------------------

    [TraktPutRequest("users/{id!!}/lists/{list_id!!}/items", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListItemUpdatePutRequest
    {
        [TraktRequestParameter]
        internal uint ListItemId { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPutRequest("users/{id!!}/lists/{list_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserPersonalListUpdatePutRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("users/request/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
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
}
