namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>Gets trending movies.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings. etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried trending movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktTrendingMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/trending/get-trending-movies">
        /// Trakt API Documentation: Movies: Trending - Get trending movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new TrendingMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktTrendingMovie>(_context, request, (uint? page, uint? limit)
                => new TrendingMoviesGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets popular movies.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings. etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried popular movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/popular/get-popular-movies">
        /// Trakt API Documentation: Movies: Popular - Get popular movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMovie>> GetPopularMoviesAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new PopularMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMovie>(_context, request, (uint? page, uint? limit)
                => new PopularMoviesGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most favorited movies.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the movies should be queried. Defaults to weekly.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings. etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried most favorited movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostFavoritedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/favorited/get-the-most-favorited-movies">
        /// Trakt API Documentation: Movies: Favorited - Get the most favorited movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostFavoritedMovie>> GetMostFavoritedMoviesAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostFavoritedMoviesGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostFavoritedMovie>(_context, request, (uint? page, uint? limit)
                => new MostFavoritedMoviesGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most played movies.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the movies should be queried. Defaults to weekly.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings. etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried most played movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostPlayedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/played/get-the-most-played-movies">
        /// Trakt API Documentation: Movies: Played - Get the most played movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostPlayedMovie>> GetMostPlayedMoviesAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostPlayedMoviesGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostPlayedMovie>(_context, request, (uint? page, uint? limit)
                => new MostPlayedMoviesGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most watched movies.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the movies should be queried. Defaults to weekly.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings. etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried most watched movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostPlayedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/watched/get-the-most-watched-movies">
        /// Trakt API Documentation: Movies: Watched - Get the most watched movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostWatchedMovie>> GetMostWatchedMoviesAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostWatchedMoviesGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostWatchedMovie>(_context, request, (uint? page, uint? limit)
                => new MostWatchedMoviesGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most collected movies.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the movies should be queried. Defaults to weekly.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings. etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried most collected movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostPlayedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/collected/get-the-most-collected-movies">
        /// Trakt API Documentation: Movies: Collected - Get the most collected movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostCollectedMovie>> GetMostCollectedMoviesAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostCollectedMoviesGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostCollectedMovie>(_context, request, (uint? page, uint? limit)
                => new MostCollectedMoviesGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }
    }
}
