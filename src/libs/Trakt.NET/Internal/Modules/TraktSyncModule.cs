namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to sync.
    /// <para>This module contains all methods of the "Trakt API Documentation - Sync" section.</para>
    /// </summary>
    public sealed partial class TraktSyncModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktSyncLastActivities>> GetLastActivitiesImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new SyncLastActivitiesGetRequest();

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncLastActivities>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktFavorite>> GetFavoritesImplAsync(TraktFavoriteObjectType? favoriteObjectType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncFavoritesGetRequest
            {
                Type = favoriteObjectType,
                SortBy = sortBy,
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktFavorite>(_context, request, (page, limit)
                => new SyncFavoritesGetRequest
                {
                    Type = favoriteObjectType,
                    SortBy = sortBy,
                    SortHow = sortHow,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderFavoritedItemsImplAsync(List<uint> reorderedFavoritedItemRanks,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = reorderedFavoritedItemRanks
            };

            var request = new SyncFavoritedItemsReorderPostRequest
            {
                TraktListItemsReorderPost = content
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktListItemsReorderPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UpdateFavoriteItemImplAsync(uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemUpdatePost
            {
                Notes = notes
            };

            var request = new SyncFavoriteItemUpdatePostRequest
            {
                ListItemId = listItemId,
                TraktListItemUpdatePost = content
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSyncPlaybackProgressItem>> GetPlaybackProgressImplAsync(TraktSyncType? objectType = null,
            DateTime? startAt = null, DateTime? endAt = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SyncPlaybackProgressGetRequest
            {
                Type = objectType,
                StartAt = startAt,
                EndAt = endAt,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSyncPlaybackProgressItem>(_context, request, (page, limit)
                => new SyncPlaybackProgressGetRequest
                {
                    Type = objectType,
                    StartAt = startAt,
                    EndAt = endAt,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse> RemovePlaybackItemImplAsync(uint playbackId, CancellationToken cancellationToken = default)
        {
            if (playbackId == 0)
                throw new TraktRequestValidationException(nameof(playbackId), "playback id not valid");

            var request = new SyncPlaybackDeleteRequest
            {
                Id = playbackId
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktSyncCollectionMovie>> GetCollectionMoviesImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktSyncCollectionMovie>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktSyncCollectionShow>> GetCollectionShowsImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktSyncCollectionShow>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<Dictionary<string, string>>> GetMinimalMovieCollectionImplAsync(string? availableOn = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionMinimalMoviesGetRequest
            {
                AvailableOn = availableOn
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<Dictionary<string, string>>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>> GetMinimalShowCollectionImplAsync(string? availableOn = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionMinimalShowsGetRequest
            {
                AvailableOn = availableOn
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<Dictionary<string, string>>> GetMinimalEpisodeCollectionImplAsync(string? availableOn = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionMinimalEpisodesGetRequest
            {
                AvailableOn = availableOn
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<Dictionary<string, string>>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncCollectionPostResponse>> AddCollectionItemsImplAsync(TraktSyncCollectionPost collectionPost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionAddPostRequest
            {
                TraktSyncCollectionPost = collectionPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncCollectionPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncCollectionRemovePostResponse>> RemoveCollectionItemsImplAsync(TraktSyncCollectionRemovePost collectionRemovePost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncCollectionRemovePostRequest
            {
                TraktSyncCollectionRemovePost = collectionRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncCollectionRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktWatchedMovie>> GetWatchedMoviesImplAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncWatchedMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchedMovie>(_context, request, (page, limit)
                => new SyncWatchedMoviesGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktWatchedShow>> GetWatchedShowsImplAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncWatchedShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchedShow>(_context, request, (page, limit)
                => new SyncWatchedShowsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSyncProgressWatchedItem>> GetWatchedProgressImplAsync(TraktSortBy? sortBy = null,
            TraktSortHow? sortHow = null, bool? lifetimeStats = null, bool? hideCompleted = null, bool? hideNotCompleted = null,
            bool? onlyRewatching = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncWatchedProgressGetRequest
            {
                SortBy = sortBy,
                SortHow = sortHow,
                LifetimeStats = lifetimeStats,
                HideCompleted = hideCompleted,
                HideNotCompleted = hideNotCompleted,
                OnlyRewatching = onlyRewatching,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSyncProgressWatchedItem>(_context, request, (page, limit)
                => new SyncWatchedProgressGetRequest
                {
                    SortBy = sortBy,
                    SortHow = sortHow,
                    LifetimeStats = lifetimeStats,
                    HideCompleted = hideCompleted,
                    HideNotCompleted = hideNotCompleted,
                    OnlyRewatching = onlyRewatching,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSyncProgressWatchedItem>> GetUpNextProgressImplAsync(TraktSortBy? sortBy = null,
            TraktSortHow? sortHow = null, bool? includeStats = null, bool? lifetimeStats = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncUpNextProgressGetRequest
            {
                SortBy = sortBy,
                SortHow = sortHow,
                IncludeStats = includeStats,
                LifetimeStats = lifetimeStats,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSyncProgressWatchedItem>(_context, request, (page, limit)
                => new SyncUpNextProgressGetRequest
                {
                    SortBy = sortBy,
                    SortHow = sortHow,
                    IncludeStats = includeStats,
                    LifetimeStats = lifetimeStats,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSyncProgressWatchedItem>> GetUpNextNitroProgressImplAsync(TraktSortBy? sortBy = null,
            TraktSortHow? sortHow = null, TraktUpNextIntent? intent = null, string? watchNow = null, TraktFilter? filter = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncUpNextNitroProgressGetRequest
            {
                SortBy = sortBy,
                SortHow = sortHow,
                Intent = intent,
                WatchNow = watchNow,
                Filter = filter,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSyncProgressWatchedItem>(_context, request, (page, limit)
                => new SyncUpNextNitroProgressGetRequest
                {
                    SortBy = sortBy,
                    SortHow = sortHow,
                    Intent = intent,
                    WatchNow = watchNow,
                    Filter = filter,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktWatchedEpisode>> GetWatchedEpisodesImplAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncWatchedEpisodesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchedEpisode>(_context, request, (page, limit)
                => new SyncWatchedEpisodesGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktHistoryItem>> GetWatchedHistoryImplAsync(TraktSyncItemType? historyItemType = null, uint? itemId = null,
            DateTime? startAt = null, DateTime? endAt = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncWatchedHistoryGetRequest
            {
                Type = historyItemType,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktHistoryItem>(_context, request, (page, limit)
                => new SyncWatchedHistoryGetRequest
                {
                    Type = historyItemType,
                    ItemId = itemId,
                    StartAt = startAt,
                    EndAt = endAt,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncHistoryPostResponse>> AddWatchedHistoryItemsImplAsync(TraktSyncHistoryPost historyPost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncWatchedHistoryAddPostRequest
            {
                TraktSyncHistoryPost = historyPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncHistoryPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncHistoryRemovePostResponse>> RemoveWatchedHistoryItemsImplAsync(TraktSyncHistoryRemovePost historyRemovePost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncWatchedHistoryRemovePostRequest
            {
                TraktSyncHistoryRemovePost = historyRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncHistoryRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktRatingsItem>> GetRatingsImplAsync(TraktRatingsItemType? ratingsItemType = null,
            int[]? ratingsFilter = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncRatingsGetRequest
            {
                Type = ratingsItemType,
                RatingFilter = string.Join(",", ratingsFilter ?? []),
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktRatingsItem>(_context, request, (page, limit)
                => new SyncRatingsGetRequest
                {
                    Type = ratingsItemType,
                    RatingFilter = string.Join(",", ratingsFilter ?? []),
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncRatingsPostResponse>> AddRatingsImplAsync(TraktSyncRatingsPost ratingsPost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncRatingsAddPostRequest
            {
                TraktSyncRatingsPost = ratingsPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncRatingsPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncRatingsRemovePostResponse>> RemoveRatingsImplAsync(TraktSyncRatingsRemovePost ratingsRemovePost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncRatingsRemovePostRequest
            {
                TraktSyncRatingsRemovePost = ratingsRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncRatingsRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncFavoritesPostResponse>> AddFavoriteItemsImplAsync(TraktSyncFavoritesPost favoritesPost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncFavoritesAddPostRequest
            {
                TraktSyncFavoritesPost = favoritesPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncFavoritesPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncFavoritesRemovePostResponse>> RemoveFavoriteItemsImplAsync(TraktSyncFavoritesRemovePost favoritesRemovePost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncFavoritesRemovePostRequest
            {
                TraktSyncFavoritesRemovePost = favoritesRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncFavoritesRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktList>> UpdateFavoritesImplAsync(string description, TraktSortBy? sortBy = null, TraktSortHow? sortHow = null,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktUpdateListPost
            {
                Description = description,
                SortBy = sortBy,
                SortHow = sortHow
            };

            var request = new SyncFavoritesUpdatePostRequest
            {
                TraktUpdateListPost = content
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktWatchlistItem>> GetWatchlistImplAsync(TraktSyncItemType? watchlistItemType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(page);
            ArgumentValidator.ThrowIfNull(limit);

            var request = new SyncWatchlistGetRequest
            {
                Type = watchlistItemType,
                SortBy = sortBy,
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktWatchlistItem>(_context, request, (page, limit)
                => new SyncWatchlistGetRequest
                {
                    Type = watchlistItemType,
                    SortBy = sortBy,
                    SortHow = sortHow,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderWatchlistItemsImplAsync(List<uint> reorderedWatchlistItemRanks,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = reorderedWatchlistItemRanks
            };

            var request = new SyncWatchlistItemsReorderPostRequest
            {
                TraktListItemsReorderPost = content
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktListItemsReorderPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UpdateWatchlistItemImplAsync(uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktListItemUpdatePost
            {
                Notes = notes
            };
            
            var request = new SyncWatchlistItemUpdatePostRequest
            {
                ListItemId = listItemId,
                TraktListItemUpdatePost = content
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncWatchlistPostResponse>> AddWatchlistItemsImplAsync(TraktSyncWatchlistPost watchlistPost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncWatchlistAddPostRequest
            {
                TraktSyncWatchlistPost = watchlistPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncWatchlistPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSyncWatchlistRemovePostResponse>> RemoveWatchlistItemsImplAsync(TraktSyncWatchlistRemovePost watchlistRemovePost,
            CancellationToken cancellationToken = default)
        {
            var request = new SyncWatchlistRemovePostRequest
            {
                TraktSyncWatchlistRemovePost = watchlistRemovePost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSyncWatchlistRemovePostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktList>> UpdateWatchlistImplAsync(string description, TraktSortBy? sortBy = null, TraktSortHow? sortHow = null,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktUpdateListPost
            {
                Description = description,
                SortBy = sortBy,
                SortHow = sortHow
            };

            var request = new SyncWatchlistUpdatePostRequest
            {
                TraktUpdateListPost = content
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, request, cancellationToken);
        }
    }
}
