namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to lists.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/lists">"Trakt API Documentation - Lists"</a> section.
    /// </summary>
    public sealed partial class TraktListsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktPagedResponse<TraktTrendingList>> GetTrendingListsImplAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ListsTrendingGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktTrendingList>(_context, request, (page, limit)
                => new ListsTrendingGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktPopularList>> GetPopularListsImplAsync(TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ListsPopularGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktPopularList>(_context, request, (page, limit)
                => new ListsPopularGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktResponse<TraktList>> GetListImplAsync(string listIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SingleListGetRequest
            {
                Id = listIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetListCommentsImplAsync(string listIdOrSlug, TraktCommentSortOrder? commentSortOrder = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ListCommentsGetRequest
            {
                Id = listIdOrSlug,
                Sort = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new ListCommentsGetRequest
                {
                    Id = listIdOrSlug,
                    Sort = commentSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktListItem>> GetListItemsImplAsync(string listIdOrSlug, TraktListItemType? listItemType = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ListItemsGetRequest
            {
                Id = listIdOrSlug,
                Type = listItemType,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktListItem>(_context, request, (page, limit)
                => new ListItemsGetRequest
                {
                    Id = listIdOrSlug,
                    Type = listItemType,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktListLike>> GetListLikesImplAsync(string listIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ListLikesGetRequest
            {
                Id = listIdOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktListLike>(_context, request, (page, limit)
                => new ListLikesGetRequest
                {
                    Id = listIdOrSlug,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktResponse> LikeListImplAsync(string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ListLikePostRequest
            {
                Id = listIdOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UnlikeListImplAsync(string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ListUnlikeDeleteRequest
            {
                Id = listIdOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
