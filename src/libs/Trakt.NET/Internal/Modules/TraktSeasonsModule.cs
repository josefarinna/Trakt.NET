namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to seasons.
    /// <para>This module contains all methods of the "Trakt API Documentation - Seasons" section.</para>
    /// </summary>
    public partial class TraktSeasonsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktSeason>> GetAllSeasonsImplAsync(string showIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            string? translationLanguageCode = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonsAllGetRequest
            {
                ShowId = showIDOrSlug,
                ExtendedInfo = extendedInfo,
                Translations = translationLanguageCode
            };

            return RequestHandler.ExecuteListRequestAsync<TraktSeason>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSeason>> GetSeasonImplAsync(string showIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSeason>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktEpisode>> GetSeasonEpisodesImplAsync(string showIDOrSlug, uint seasonNumber,
            string? translations, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonEpisodesGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                Translations = translations,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktEpisode>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktSeasonTranslation>> GetSeasonTranslationsImplAsync(string showIDOrSlug, uint seasonNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonTranslationsGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                Language = language
            };

            return RequestHandler.ExecuteListRequestAsync<TraktSeasonTranslation>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetSeasonCommentsImplAsync(string showIDOrSlug, uint seasonNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SeasonCommentsGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                SortOrder = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };
            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new SeasonCommentsGetRequest
                {
                    ShowId = showIDOrSlug,
                    SeasonNumber = seasonNumber,
                    SortOrder = commentSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktList>> GetSeasonListsImplAsync(string showIDOrSlug, uint seasonNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null,
            uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonListsGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                ListType = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktList>(_context, request, (page, limit)
                => new SeasonListsGetRequest
                {
                    ShowId = showIDOrSlug,
                    SeasonNumber = seasonNumber,
                    ListType = listType,
                    SortOrder = listSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktResponse<TraktCastAndCrew>> GetSeasonPeopleImplAsync(string showIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonPeopleGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCastAndCrew>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktRating>> GetSeasonRatingsImplAsync(string showIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonRatingsGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktRating>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktSeasonStatistics>> GetSeasonStatisticsImplAsync(string showIDOrSlug, uint seasonNumber,
            CancellationToken cancellationToken = default)
        {
            var request = new SeasonStatisticsGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSeasonStatistics>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUser>> GetSeasonWatchingUsersImplAsync(string showIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonWatchingGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUser>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktVideo>> GetSeasonVideosImplAsync(string movieIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new SeasonVideosGetRequest
            {
                ShowId = movieIDOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktVideo>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<Dictionary<string, string>>> GetSeasonJustwatchLinksImplAsync(
            string showIDOrSlug, uint seasonNumber, string country, CancellationToken cancellationToken = default)
        {
            var request = new SeasonJustwatchLinksGetRequest
            {
                ShowId = showIDOrSlug,
                SeasonNumber = seasonNumber,
                Country = country
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<Dictionary<string, string>>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> ReportSeasonImplAsync(string seasonIdOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktReportPost
            {
                Reason = reason,
                Message = message
            };

            var request = new SeasonReportPostRequest
            {
                Id = seasonIdOrSlug,
                TraktReportPost = content
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
