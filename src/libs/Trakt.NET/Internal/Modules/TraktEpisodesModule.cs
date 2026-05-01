namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to episodes.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/episodes">"Trakt API Documentation - Episodes"</a> section.
    /// </summary>
    public sealed partial class TraktEpisodesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktEpisode>> GetEpisodeImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new EpisodeGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            };
                
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisode>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetEpisodeCommentsImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new EpisodeCommentsGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                SortOrder = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new EpisodeCommentsGetRequest
                {
                    ShowId = showIdOrSlug,
                    SeasonNumber = seasonNumber,
                    EpisodeNumber = episodeNumber,
                    SortOrder = commentSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktList>> GetEpisodeListsImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new EpisodeListsGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ListType = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktList>(_context, request, (page, limit)
                => new EpisodeListsGetRequest
                {
                    ShowId = showIdOrSlug,
                    SeasonNumber = seasonNumber,
                    EpisodeNumber = episodeNumber,
                    ListType = listType,
                    SortOrder = listSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktCastAndCrew>> GetEpisodePeopleImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new EpisodePeopleGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCastAndCrew>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktRating>> GetEpisodeRatingsImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            CancellationToken cancellationToken = default)
        {
            var request = new EpisodeRatingsGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktRating>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeStatistics>> GetEpisodeStatisticsImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            CancellationToken cancellationToken = default)
        {
            var request = new EpisodeStatisticsGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeStatistics>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktEpisodeTranslation>> GetEpisodeTranslationsImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            var request = new EpisodeTranslationsGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                Language = language
            };

            return RequestHandler.ExecuteListRequestAsync<TraktEpisodeTranslation>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktVideo>> GetEpisodeVideosImplAsync(string movieIDOrSlug, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new EpisodeVideosGetRequest
            {
                ShowId = movieIDOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktVideo>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUser>> GetEpisodeWatchingUsersImplAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new EpisodeWatchingGetRequest
            {
                ShowId = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUser>(_context, request, cancellationToken);
        }
    }
}
