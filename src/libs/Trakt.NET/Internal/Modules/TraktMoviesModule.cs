namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to movies.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/movies">"Trakt API Documentation - Movies"</a> section.
    /// </summary>
    public sealed partial class TraktMoviesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovie>> GetMovieImplAsync(string movieIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieGetRequest
            {
                Id = movieIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovie>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktMovieAlias>> GetMovieAliasesImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieAliasesGetRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktMovieAlias>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktMovieRelease>> GetMovieReleasesImplAsync(string movieIDOrSlug, string? country = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieReleasesGetRequest
            {
                Id = movieIDOrSlug,
                Country = country
            };

            return RequestHandler.ExecuteListRequestAsync<TraktMovieRelease>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktMovieTranslation>> GetMovieTranslationsImplAsync(string movieIDOrSlug, string? language = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieTranslationsGetRequest
            {
                Id = movieIDOrSlug,
                Language = language
            };

            return RequestHandler.ExecuteListRequestAsync<TraktMovieTranslation>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktRating>> GetMovieRatingsImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieRatingsGetRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktRating>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktMovieStatistics>> GetMovieStatisticsImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieStatisticsGetRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieStatistics>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktVideo>> GetMovieVideosImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieVideosGetRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktVideo>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCastAndCrew>> GetMoviePeopleImplAsync(string movieIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MoviePeopleGetRequest
            {
                Id = movieIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCastAndCrew>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktMovie>> GetMovieRelatedMoviesImplAsync(string movieIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MovieRelatedMoviesGetRequest
            {
                Id = movieIDOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMovie>(_context, request, (page, limit)
                => new MovieRelatedMoviesGetRequest
                {
                    Id = movieIDOrSlug,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktListResponse<TraktStudio>> GetMovieStudiosImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieStudiosGetRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktStudio>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUser>> GetMovieWatchingUsersImplAsync(string movieIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieWatchingGetRequest
            {
                Id = movieIDOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktUser>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktList>> GetMovieListsImplAsync(string movieIDOrSlug, TraktListType? listType = null,
            TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieListsGetRequest
            {
                Id = movieIDOrSlug,
                ListType = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktList>(_context, request, (page, limit)
                => new MovieListsGetRequest
                {
                    Id = movieIDOrSlug,
                    ListType = listType,
                    SortOrder = listSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetMovieCommentsImplAsync(string movieIDOrSlug, TraktCommentSortOrder? commentSortOrder = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MovieCommentsGetRequest
            {
                Id = movieIDOrSlug,
                SortOrder = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new MovieCommentsGetRequest
                {
                    Id = movieIDOrSlug,
                    SortOrder = commentSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktResponse> RefreshMovieImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieRefreshPostRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetMovieWatchnowImplAsync(
            string movieIDOrSlug, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieWatchnowGetRequest
            {
                Id = movieIDOrSlug,
                Country = country,
                Links = links,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<Dictionary<string, TraktWatchnowSources>>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<Dictionary<string, string>>> GetMovieJustwatchLinksImplAsync(
            string movieIDOrSlug, string country, CancellationToken cancellationToken = default)
        {
            var request = new MovieJustwatchLinksGetRequest
            {
                Id = movieIDOrSlug,
                Country = country
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<Dictionary<string, string>>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> ReportMovieImplAsync(string movieIdOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktReportPost
            {
                Reason = reason,
                Message = message
            };

            var request = new MovieReportPostRequest
            {
                Id = movieIdOrSlug,
                TraktReportPost = content
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> RefreshMovieJustWatchLinksImplAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieRefreshJustWatchPostRequest
            {
                Id = movieIdOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
