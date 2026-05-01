namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to calendars.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/calendars">"Trakt API Documentation - Calendars"</a> section.
    /// </summary>
    public sealed partial class TraktCalendarModule
    {
        /// <summary>Gets all shows from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-shows/get-shows">
        /// Trakt API Documentation: Calendars: My Shows - Get shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserShowsAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all new shows from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-new-shows/get-new-shows">
        /// Trakt API Documentation: Calendars: My New Shows - Get new shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserNewShowsAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserNewShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all season premieres from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-season-premieres/get-season-premieres">
        /// Trakt API Documentation: Calendars: My Season Premieres - Get season premieres
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserSeasonPremieresAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserSeasonPremieresImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all show finales from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-finales/get-finales">
        /// Trakt API Documentation: Calendars: My Finales - Get finales
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserFinalesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserFinalesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-movies/get-movies">
        /// Trakt API Documentation: Calendars: My Movies - Get movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetUserMoviesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from the user's streaming releases calendar during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-streaming/get-streaming-releases">
        /// Trakt API Documentation: Calendars: My Streaming - Get streaming releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetUserStreamingMoviesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserStreamingMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from the user's DVD/Blu-ray releases calendar during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/my-dvd/get-dvd-releases">
        /// Trakt API Documentation: Calendars: My DVD - Get DVD releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetUserDVDMoviesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserDVDMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all shows from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-shows/get-shows">
        /// Trakt API Documentation: Calendars: All Shows - Get shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllShowsAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all new shows from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-new-shows/get-new-shows">
        /// Trakt API Documentation: Calendars: All New Shows - Get new shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllNewShowsAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllNewShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all season premieres from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-season-premieres/get-season-premieres">
        /// Trakt API Documentation: Calendars: All Season Premieres - Get season premieres
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllSeasonPremieresAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllSeasonPremieresImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all show finales from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-finales/get-finales">
        /// Trakt API Documentation: Calendars: All Finales - Get finales
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllFinalesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllFinalesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-movies/get-movies">
        /// Trakt API Documentation: Calendars: All Movies - Get movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetAllMoviesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from all streaming releases calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-streaming/get-streaming-releases">
        /// Trakt API Documentation: Calendars: All Streaming - Get streaming releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetAllStreamingMoviesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllStreamingMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from all DVD/Blu-ray releases calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar. If not set, today's date will be used.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 31 days. Default is 7 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/calendars/all-dvd/get-dvd-releases">
        /// Trakt API Documentation: Calendars: All DVD - Get DVD releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetAllDVDMoviesAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllDVDMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);
    }
}
