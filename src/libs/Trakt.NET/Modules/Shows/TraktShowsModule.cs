namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to shows.
    /// <para>This module contains all methods of the "Trakt API Documentation - Shows" section.</para>
    /// </summary>
    public sealed partial class TraktShowsModule
    {
        /// <summary>Gets trending shows.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried trending shows.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktTrendingShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowstrending">
        /// Trakt API Documentation: Shows: Trending - Get trending shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktTrendingShow>> GetTrendingShowsAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new TrendingShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktTrendingShow>(_context, request, (page, limit)
                => new TrendingShowsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Filter = filter,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        /// <summary>Gets popular shows.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried popular shows.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowspopular">
        /// Trakt API Documentation: Shows: Popular - Get popular shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktShow>> GetPopularShowsAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new PopularShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktShow>(_context, request, (page, limit)
                => new PopularShowsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Filter = filter,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        /// <summary>Gets the most favorited shows.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the most favorited shows should be queried.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" />
        /// containing the queried most favorited shows.
        /// <para>The response also contains information about the queried page number,</para>
        /// the page's item count, maximum page count and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostFavoritedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsfavorited">
        /// Trakt API Documentation: Shows: Favorited - Get the most favorited shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostFavoritedShow>> GetMostFavoritedShowsAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostFavoritedShowsGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostFavoritedShow>(_context, request, (page, limit)
                => new MostFavoritedShowsGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most played shows.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the most played shows should be queried.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" />
        /// containing the queried most played shows.
        /// <para>The response also contains information about the queried page number, the page's item count,</para>
        /// maximum page count and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostPlayedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsplayed">
        /// Trakt API Documentation: Shows: Played - Get the most played shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostPlayedShow>> GetMostPlayedShowsAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostPlayedShowsGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostPlayedShow>(_context, request, (page, limit)
                => new MostPlayedShowsGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most watched shows.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the most watched shows should be queried.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" />
        /// containing the queried most watched shows.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostWatchedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatched">
        /// Trakt API Documentation: Shows: Watched - Get the most watched shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostWatchedShow>> GetMostWatchedShowsAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostWatchedShowsGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostWatchedShow>(_context, request, (page, limit)
                => new MostWatchedShowsGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most collected shows.</summary>
        /// <param name="timePeriod">
        /// Specifies the time period for which the most collected shows should be queried.
        /// <para>See also <seealso cref="TraktTimePeriod" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" />
        /// containing the queried most collected shows.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostCollectedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowscollected">
        /// Trakt API Documentation: Shows: Collected - Get the most collected shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostCollectedShow>> GetMostCollectedShowsAsync(TraktTimePeriod? timePeriod = null,
            TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MostCollectedShowsGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostCollectedShow>(_context, request, (page, limit)
                => new MostCollectedShowsGetRequest
                {
                    TimePeriod = timePeriod,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets the most anticipated shows.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried most anticipated shows.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktMostAnticipatedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsanticipated">
        /// Trakt API Documentation: Shows: Anticipated - Get the most anticipated shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktMostAnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MostAnticipatedShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                Filter = filter
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktMostAnticipatedShow>(_context, request, (page, limit)
                => new MostAnticipatedShowsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    Filter = filter
                },
                cancellationToken);
        }

        /// <summary>Gets recently updated shows.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="startDate">Specifies the start date from which shows should be returned.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried updated shows.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUpdatedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsupdates">
        /// Trakt API Documentation: Shows: Updates - Get recently updated shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUpdatedShow>> GetRecentlyUpdatedShowsAsync(TraktExtendedInfo? extendedInfo = null,
            DateTime? startDate = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new RecentlyUpdatedShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                StartDate = startDate
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUpdatedShow>(_context, request, (page, limit)
                => new RecentlyUpdatedShowsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    StartDate = startDate
                },
                cancellationToken);
        }

        /// <summary>Gets recently updated show IDs.</summary>
        /// <param name="startDate">Specifies the start date from which show IDs should be returned.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried updated show Trakt IDs.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsupdatedids">
        /// Trakt API Documentation: Shows: Updates - Get recently updated show IDs
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<uint>> GetRecentlyUpdatedShowTraktIDsAsync(DateTime? startDate = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RecentlyUpdatedShowIDsGetRequest
            {
                StartDate = startDate,
                Page = page,
                Limit = limit
            };
            return RequestHandler.ExecutePagedListRequestAsync<uint>(_context, request, (page, limit)
                => new RecentlyUpdatedShowIDsGetRequest
                {
                    Page = page,
                    Limit = limit,
                    StartDate = startDate
                },
                cancellationToken);
        }
    }
}
