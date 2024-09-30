namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to movies.<para />
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/movies">"Trakt API Documentation - Movies"</a> section.
    /// </summary>
    public sealed partial class TraktMoviesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovie>> GetMovieImplAsync(string movieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieGetRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovie>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktMovieAlias>> GetMovieAliasesImplAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieAliasesGetRequest
            {
                Id = movieIdOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktMovieAlias>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktMovieRelease>> GetMovieReleasesImplAsync(string movieIdOrSlug, string? country = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieReleasesGetRequest
            {
                Id = movieIdOrSlug,
                Country = country
            };

            return RequestHandler.ExecuteListRequestAsync<TraktMovieRelease>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktMovieTranslation>> GetMovieTranslationsImplAsync(string movieIdOrSlug, string? language = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieTranslationsGetRequest
            {
                Id = movieIdOrSlug,
                Language = language
            };

            return RequestHandler.ExecuteListRequestAsync<TraktMovieTranslation>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktRating>> GetMovieRatingsImplAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieRatingsGetRequest
            {
                Id = movieIdOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktRating>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktMovieStatistics>> GetMovieStatisticsImplAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieStatisticsGetRequest
            {
                Id = movieIdOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieStatistics>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktVideo>> GetMovieVideosImplAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieVideosGetRequest
            {
                Id = movieIdOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktVideo>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCastAndCrew>> GetMoviePeopleImplAsync(string movieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MoviePeopleGetRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCastAndCrew>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktMovie>> GetMovieRelatedMoviesImplAsync(string movieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MovieRelatedMoviesGetRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMovie>(_context, request, (uint? page, uint? limit)
                => new MovieRelatedMoviesGetRequest
                {
                    Id = movieIdOrSlug,
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
    }
}
