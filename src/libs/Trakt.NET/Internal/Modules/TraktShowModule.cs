namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to shows.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/shows">"Trakt API Documentation - Shows"</a> section.
    /// </summary>
    public sealed partial class TraktShowsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktShow>> GetShowImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowGetRequest
            {
                Id = showIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktShow>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktShowAlias>> GetShowAliasesImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowAliasesGetRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktShowAlias>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktShowCertification>> GetShowCertificationsImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowCertificationsGetRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktShowCertification>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktShowTranslation>> GetShowTranslationsImplAsync(string showIDOrSlug, string? language = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowTranslationsGetRequest
            {
                Id = showIDOrSlug,
                Language = language
            };

            return RequestHandler.ExecuteListRequestAsync<TraktShowTranslation>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktRating>> GetShowRatingsImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowRatingsGetRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktRating>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktShowStatistics>> GetShowStatisticsImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowStatisticsGetRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktShowStatistics>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktVideo>> GetShowVideosImplAsync(string movieIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowVideosGetRequest
            {
                Id = movieIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktVideo>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCastAndCrew>> GetShowPeopleImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowPeopleGetRequest
            {
                Id = showIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCastAndCrew>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktShow>> GetShowRelatedShowsImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ShowRelatedShowsGetRequest
            {
                Id = showIDOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktShow>(_context, request,
                (page, limit) =>
                    new ShowRelatedShowsGetRequest
                    {
                        Id = showIDOrSlug,
                        ExtendedInfo = extendedInfo,
                        Page = page,
                        Limit = limit
                    },
                cancellationToken);
        }

        private Task<TraktListResponse<TraktStudio>> GetShowStudiosImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowStudiosGetRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktStudio>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUser>> GetShowWatchingUsersImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowWatchingGetRequest
            {
                Id = showIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUser>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktEpisode>> GetShowNextEpisodeImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowNextEpisodeGetRequest
            {
                Id = showIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisode>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktEpisode>> GetShowLastEpisodeImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowLastEpisodeGetRequest
            {
                Id = showIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisode>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktList>> GetShowListsImplAsync(string showIDOrSlug, TraktListType? listType = null,
            TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowListsGetRequest
            {
                Id = showIDOrSlug,
                ListType = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktList>(_context, request, (page, limit)
                => new ShowListsGetRequest
                {
                    Id = showIDOrSlug,
                    ListType = listType,
                    SortOrder = listSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetShowCommentsImplAsync(string showIDOrSlug, TraktCommentSortOrder? commentSortOrder = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new ShowCommentsGetRequest
            {
                Id = showIDOrSlug,
                SortOrder = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new ShowCommentsGetRequest
                {
                    Id = showIDOrSlug,
                    SortOrder = commentSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktResponse<TraktShowWatchedProgress>> GetShowWatchedProgressImplAsync(string showIDOrSlug, bool? hidden,
            bool? specials, bool? countSpecials, CancellationToken cancellationToken = default)
        {
            var request = new ShowWatchedProgressGetRequest
            {
                Id = showIDOrSlug,
                Hidden = hidden,
                Specials = specials,
                CountSpecials = countSpecials
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktShowWatchedProgress>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktShowCollectionProgress>> GetShowCollectionProgressImplAsync(string showIDOrSlug, bool? hidden,
            bool? specials, bool? countSpecials, CancellationToken cancellationToken = default)
        {
            var request = new ShowCollectionProgressGetRequest
            {
                Id = showIDOrSlug,
                Hidden = hidden,
                Specials = specials,
                CountSpecials = countSpecials
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktShowCollectionProgress>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> RefreshShowImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowRefreshPostRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktShowResetWatchedProgress>> ResetShowWatchedProgressImplAsync(string showIDOrSlug, DateTime? resetAt,
            CancellationToken cancellationToken = default)
        {
            var request = new ShowResetWatchedProgressPostRequest
            {
                Id = showIDOrSlug,
                ResetAt = resetAt,
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktShowResetWatchedProgress>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UndoResetShowWatchedProgressImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowUndoResetWatchedProgressDeleteRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
