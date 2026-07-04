namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to users.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/users">"Trakt API Documentation - Users"</a> section.
    /// </summary>
    public sealed partial class TraktUsersModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktUserSettings>> GetSettingsImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new UserSettingsGetRequest();

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserSettings>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUserFollowRequest>> GetFollowRequestsImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserFollowRequestsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUserFollowRequest>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUserFollowRequest>> GetPendingFollowingRequestsImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserPendingFollowingRequestsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUserFollowRequest>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserHiddenItem>> GetHiddenItemsImplAsync(TraktHiddenItemsSection hiddenItemsSection,
            TraktHiddenItemType? hiddenItemType = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserHiddenItemsGetRequest
            {
                Section = hiddenItemsSection,
                Type = hiddenItemType,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserHiddenItem>(_context, request, (page, limit)
                => new UserHiddenItemsGetRequest
                {
                    Section = hiddenItemsSection,
                    Type = hiddenItemType,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserSavedFilter>> GetSavedFiltersImplAsync(TraktFilterSection? section = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserSavedFiltersGetRequest
            {
                Section = section,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserSavedFilter>(_context, request, (page, limit)
                => new UserSavedFiltersGetRequest
                {
                    Section = section,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktUserHiddenItemsPostResponse>> AddHiddenItemsImplAsync(TraktUserHiddenItemsPost hiddenItemsPost,
            TraktHiddenItemsSection hiddenItemsSection, CancellationToken cancellationToken = default)
        {
            var request = new UserHiddenItemsAddPostRequest
            {
                Section = hiddenItemsSection,
                TraktUserHiddenItemsPost = hiddenItemsPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserHiddenItemsPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktUserHiddenItemsRemovePostResponse>> RemoveHiddenItemsImplAsync(TraktUserHiddenItemsRemovePost hiddenItemsRemovePost,
            TraktHiddenItemsSection hiddenItemsSection, CancellationToken cancellationToken = default)
        {
            var request = new UserHiddenItemsRemovePostRequest
            {
                Section = hiddenItemsSection,
                TraktUserHiddenItemsRemovePost = hiddenItemsRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserHiddenItemsRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserLikeItem>> GetLikesImplAsync(string usernameOrSlug, TraktUserLikeType? likeType = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserLikesGetRequest
            {
                Id = usernameOrSlug,
                Type = likeType,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserLikeItem>(_context, request, (page, limit)
                => new UserLikesGetRequest
                {
                    Id = usernameOrSlug,
                    Type = likeType,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktUser>> GetUserProfileImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserProfileGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUser>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktCollectionMovie>> GetCollectionMoviesImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserCollectionMoviesGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktCollectionMovie>(_context,  request, (page, limit)
                => new UserCollectionMoviesGetRequest
                {
                    Id = usernameOrSlug,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktCollectionShow>> GetCollectionShowsImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserCollectionShowsGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktCollectionShow>(_context, request, (page, limit)
                => new UserCollectionShowsGetRequest
                {
                    Id = usernameOrSlug,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserComment>> GetCommentsImplAsync(string usernameOrSlug, TraktCommentType? type = null,
            TraktCommentObjectType? objectType = null, TraktIncludeReplies? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserCommentsGetRequest
            {
                Id = usernameOrSlug,
                ObjectType = objectType,
                Type = type,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserComment>(_context, request, (page, limit)
                => new UserCommentsGetRequest
                {
                    Id = usernameOrSlug,
                    ObjectType = objectType,
                    Type = type,
                    IncludeReplies = includeReplies,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktListResponse<TraktList>> GetPersonalListsImplAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalListsGetRequest
            {
                Id = usernameOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktList>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktList>> CreatePersonalListImplAsync(string usernameOrSlug, TraktUserPersonalListPost personalListPost,
           CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalListAddPostRequest
            {
                Id = usernameOrSlug,
                TraktUserPersonalListPost = personalListPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListsImplAsync(string usernameOrSlug, List<uint> reorderedListsRank,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = reorderedListsRank
            };

            var request = new UserPersonalListsReorderPostRequest
            {
                Id = usernameOrSlug,
                TraktListItemsReorderPost = content
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktListItemsReorderPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktList>> GetListCollaborationsImplAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserListCollaborationsGetRequest
            {
                Id = usernameOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktList>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUserFollower>> GetFollowersImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserFollowersGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUserFollower>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUserFollower>> GetFollowingImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserFollowingGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUserFollower>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUserFriend>> GetFriendsImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserFriendsGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUserFriend>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktUserFollowUserPostResponse>> FollowUserImplAsync(string usernameOrSlug,
            CancellationToken cancellationToken = default)
        {
            var request = new UserFollowUserPostRequest
            {
                Id = usernameOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserFollowUserPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UnfollowUserImplAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserUnfollowUserDeleteRequest
            {
                Id = usernameOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktUserFollower>> ApproveFollowRequestImplAsync(uint followerRequestId, CancellationToken cancellationToken = default)
        {
            var request = new UserApproveFollowerPostRequest
            {
                Id = followerRequestId.ToInvariantCultureString()
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserFollower>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> DenyFollowRequestImplAsync(uint followerRequestId, CancellationToken cancellationToken = default)
        {
            var request = new UserDenyFollowerDeleteRequest
            {
                Id = followerRequestId.ToInvariantCultureString()
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktHistoryItem>> GetWatchedHistoryImplAsync(string usernameOrSlug, TraktSyncItemType? historyItemType = null,
            uint? itemId = null, DateTime? startAt = null, DateTime? endAt = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserWatchedHistoryGetRequest
            {
                Id = usernameOrSlug,
                Type = historyItemType,
                ItemID = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktHistoryItem>(_context, request, (page, limit)
                => new UserWatchedHistoryGetRequest
                {
                    Id = usernameOrSlug,
                    Type = historyItemType,
                    ItemID = itemId,
                    StartAt = startAt,
                    EndAt = endAt,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktFavorite>> GetFavoritesImplAsync(string usernameOrSlug, TraktFavoriteObjectType? favoriteObjectType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserFavoritesGetRequest
            {
                Id = usernameOrSlug,
                Type = favoriteObjectType,
                SortBy = sortBy,
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktFavorite>(_context, request, (page, limit)
                => new UserFavoritesGetRequest
                {
                    Id = usernameOrSlug,
                    Type = favoriteObjectType,
                    SortBy = sortBy,
                    SortHow = sortHow,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetFavoritesCommentsImplAsync(string usernameOrSlug, TraktCommentSortOrder? sortOrder = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserFavoritesCommentsGetRequest
            {
                Id = usernameOrSlug,
                Sort = sortOrder,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new UserFavoritesCommentsGetRequest
                {
                    Id = usernameOrSlug,
                    Sort = sortOrder,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktRatingsItem>> GetRatingsImplAsync(string usernameOrSlug, TraktRatingsItemType? ratingsItemType = null,
            uint[]? ratingsFilter = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserRatingsGetRequest
            {
                Id = usernameOrSlug,
                Type = ratingsItemType,
                RatingFilter = FormatRatingsFilter(ratingsFilter, ratingsItemType),
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktRatingsItem>(_context, request, (page, limit)
                => new UserRatingsGetRequest
                {
                    Id = usernameOrSlug,
                    Type = ratingsItemType,
                    RatingFilter = FormatRatingsFilter(ratingsFilter, ratingsItemType),
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private static string FormatRatingsFilter(uint[]? filter, TraktRatingsItemType? type)
        {
            bool isValidType = type != null && type != TraktRatingsItemType.Unspecified;

            if (isValidType && filter is { Length: > 0 and <= 10 })
            {
                if (filter.All(r => r is >= 1 and <= 10))
                    return string.Join(",", filter);
            }

            return string.Empty;
        }

        private Task<TraktPagedResponse<TraktWatchlistItem>> GetWatchlistImplAsync(string usernameOrSlug, TraktSyncItemType? watchlistItemType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserWatchlistGetRequest
            {
                Id = usernameOrSlug,
                Type = watchlistItemType,
                SortBy = sortBy,
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchlistItem>(_context, request, (page, limit)
                => new UserWatchlistGetRequest
                {
                    Id = usernameOrSlug,
                    Type = watchlistItemType,
                    SortBy = sortBy,
                    SortHow = sortHow,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetWatchlistCommentsImplAsync(string usernameOrSlug, TraktCommentSortOrder? sortOrder = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserWatchlistCommentsGetRequest
            {
                Id = usernameOrSlug,
                Sort = sortOrder,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new UserWatchlistCommentsGetRequest
                {
                    Id = usernameOrSlug,
                    Sort = sortOrder,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktUserWatchingItem>> GetWatchingImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new UserWatchingGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserWatchingItem>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktWatchedMovie>> GetWatchedMoviesImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserWatchedMoviesGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchedMovie>(_context, request, (page, limit)
                => new UserWatchedMoviesGetRequest
                {
                    Id = usernameOrSlug,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktWatchedShow>> GetWatchedShowsImplAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new UserWatchedShowsGetRequest
            {
                Id = usernameOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchedShow>(_context, request, (page, limit)
                => new UserWatchedShowsGetRequest
                {
                    Id = usernameOrSlug,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktUserStatistics>> GetStatisticsImplAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserStatisticsGetRequest
            {
                Id = usernameOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserStatistics>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktNoteItem>> GetUserNotesImplAsync(string usernameOrSlug, TraktNotesObjectType? notesObjectType = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserNotesGetRequest
            {
                Id = usernameOrSlug,
                Type = notesObjectType,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktNoteItem>(_context, request, (page, limit)
                => new UserNotesGetRequest
                {
                    Id = usernameOrSlug,
                    Type = notesObjectType,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse> ReportUserImplAsync(string usernameOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktUserReportPost
            {
                Reason = reason,
                Message = message
            };

            var request = new UserReportPostRequest
            {
                Id = usernameOrSlug,
                TraktUserReportPost = content
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktUserPersonalListItemsPostResponse>> AddPersonalListItemsImplAsync(string usernameOrSlug, string listIdOrSlug,
            TraktUserPersonalListItemsPost listItemsPost, CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalListItemsAddPostRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                TraktUserPersonalListItemsPost = listItemsPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserPersonalListItemsPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> DeletePersonalListImplAsync(string usernameOrSlug, string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalListDeleteRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetListCommentsImplAsync(string usernameOrSlug, string listIdOrSlug,
            TraktCommentSortOrder? commentSortOrder = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserListCommentsGetRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                Sort = commentSortOrder,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new UserListCommentsGetRequest
                {
                    Id = usernameOrSlug,
                    ListId = listIdOrSlug,
                    Sort = commentSortOrder,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktListLike>> GetListLikesImplAsync(string usernameOrSlug, string listIdOrSlug,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserListLikesGetRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktListLike>(_context, request, (page, limit)
                => new UserListLikesGetRequest
                {
                    Id = usernameOrSlug,
                    ListId = listIdOrSlug,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktList>> GetPersonalListImplAsync(string usernameOrSlug, string listIdOrSlug,
            CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalSingleListGetRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktListItem>> GetPersonalListItemsImplAsync(string usernameOrSlug, string listIdOrSlug,
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

        private Task<TraktResponse> LikeListImplAsync(string usernameOrSlug, string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserListLikePostRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsImplAsync(string usernameOrSlug, string listIdOrSlug,
            TraktUserPersonalListItemsRemovePost listItemsRemovePost, CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalListItemsRemovePostRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                TraktUserPersonalListItemsRemovePost = listItemsRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserPersonalListItemsRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListItemsImplAsync(string usernameOrSlug, string listIdOrSlug,
            List<uint> reorderedListItemsRank, CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = reorderedListItemsRank
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktListItemsReorderPostResponse>(_context, new UserPersonalListItemsReorderPostRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                TraktListItemsReorderPost = content
            },
            cancellationToken);
        }

        private Task<TraktResponse> UnlikeListImplAsync(string usernameOrSlug, string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new UserListUnlikeDeleteRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktList>> UpdatePersonalListImplAsync(string usernameOrSlug, string listIdOrSlug,
            TraktUserPersonalListPost personalListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(personalListPost);

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, new UserPersonalListUpdatePutRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                Content = System.Net.Http.Json.JsonContent.Create(personalListPost)
            },
            cancellationToken);
        }

        private Task<TraktResponse> UpdatePersonalListItemImplAsync(string usernameOrSlug, string listIdOrSlug,
            uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemUpdatePost
            {
                Notes = notes
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, new UserPersonalListItemUpdatePutRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                ListItemId = listItemId,
                TraktListItemUpdatePost = content
            }, cancellationToken);
        }
    }
}
