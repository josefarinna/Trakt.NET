namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to movies.<para />
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/movies">"Trakt API Documentation - Movies"</a> section.
    /// </summary>
    public partial class TraktMoviesModule(TraktContext context) : BaseModule(context)
    {
        public Task<TraktResponse<TraktMovie>> GetMovieAsync(string movieId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieImplAsync(movieId, extendedInfo, cancellationToken);

        public Task<TraktResponse<TraktMovie>> GetMovieAsync(uint movieId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            if (movieId == 0)
                throw new ArgumentOutOfRangeException(nameof(movieId), "movie id must not be 0");

            return GetMovieImplAsync(movieId.ToInvariantCultureString(), extendedInfo, cancellationToken);
        }

        public Task<TraktResponse<TraktMovie>> GetMovieAsync(TraktMovieIds movieIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIds);

            if (!movieIds.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));
            }

            return GetMovieImplAsync(movieIds.BestID, extendedInfo, cancellationToken);
        }

        public Task<TraktPagedResponse<TraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedInfo? extendedInfo = null, // TODO: TraktMovieFilter filter = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new TrendingMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktTrendingMovie>(_context, request, (uint? page, uint? limit)
                => new TrendingMoviesGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        public Task<TraktPagedResponse<TraktMovie>> GetPopularMoviesAsync(TraktExtendedInfo? extendedInfo = null, // TODO: TraktMovieFilter filter = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new PopularMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMovie>(_context, request, (uint? page, uint? limit)
                => new PopularMoviesGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }
    }
}
