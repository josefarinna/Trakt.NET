namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to calendars.
    /// <para>This module contains all methods of the <see href="https://docs.trakt.tv/reference/about-calendars">Trakt API Documentation - Calendars</see> section.</para>
    /// </summary>
    public sealed partial class TraktCalendarModule
    {
        /// <summary>Gets all shows from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="group">Determines how calendar items are grouped. See also <seealso cref="TraktCalendarGroup" />.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsshows">
        /// Trakt API Documentation: Calendars: My Shows - Get shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserShowsAsync(DateTime startDate, uint days,
            TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserShowsImplAsync(startDate, days, group, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all new shows from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsnewshows">
        /// Trakt API Documentation: Calendars: My New Shows - Get new shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserNewShowsAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserNewShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all season premieres from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsseasonpremieres">
        /// Trakt API Documentation: Calendars: My Season Premieres - Get season premieres
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserSeasonPremieresAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserSeasonPremieresImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all show finales from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsfinales">
        /// Trakt API Documentation: Calendars: My Finales - Get finales
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetUserFinalesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserFinalesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsmovies">
        /// Trakt API Documentation: Calendars: My Movies - Get movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetUserMoviesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from the user's streaming releases calendar during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsstreaming">
        /// Trakt API Documentation: Calendars: My Streaming - Get streaming releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetUserStreamingMoviesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserStreamingMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from the user's DVD/Blu-ray releases calendar during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsdvdreleases">
        /// Trakt API Documentation: Calendars: My DVD - Get DVD releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetUserDVDMoviesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserDVDMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all shows from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="group">Determines how calendar items are grouped. See also <seealso cref="TraktCalendarGroup" />.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsshows">
        /// Trakt API Documentation: Calendars: All Shows - Get shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllShowsAsync(DateTime startDate, uint days,
            TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllShowsImplAsync(startDate, days, group, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all new shows from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsnewshows">
        /// Trakt API Documentation: Calendars: All New Shows - Get new shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllNewShowsAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllNewShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all season premieres from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsseasonpremieres">
        /// Trakt API Documentation: Calendars: All Season Premieres - Get season premieres
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllSeasonPremieresAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllSeasonPremieresImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all show finales from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsfinales">
        /// Trakt API Documentation: Calendars: All Finales - Get finales
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetAllFinalesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllFinalesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsmovies">
        /// Trakt API Documentation: Calendars: All Movies - Get movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetAllMoviesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from all streaming releases calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsstreaming">
        /// Trakt API Documentation: Calendars: All Streaming - Get streaming releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetAllStreamingMoviesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllStreamingMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets all movies from all DVD/Blu-ray releases calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows, episodes and / or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMovie}" /> containing the queried calendar movies.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsdvdreleases">
        /// Trakt API Documentation: Calendars: All DVD - Get DVD releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMovie>> GetAllDVDMoviesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllDVDMoviesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets upcoming movies and episodes from all calendars that are trending or highly anticipated.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="type">Narrow the feed to a single media type. If null, returns both. See also <seealso cref="TraktCalendarMediaType" />.</param>
        /// <param name="group">Determines how calendar items are grouped. See also <seealso cref="TraktCalendarGroup" />.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMedia}" /> containing the queried calendar media items.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsreleaseshot">
        /// Trakt API Documentation: Calendars: Get hot releases
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMedia>> GetHotReleasesAsync(DateTime startDate, uint days,
            TraktCalendarMediaType? type = null, TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetHotReleasesImplAsync(startDate, days, type, group, filter, extendedInfo, cancellationToken);

        /// <summary>Gets movies and episodes from the user's calendar airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="type">Narrow the feed to a single media type. If null, returns both. See also <seealso cref="TraktCalendarMediaType" />.</param>
        /// <param name="group">Determines how calendar items are grouped. See also <seealso cref="TraktCalendarGroup" />.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMedia}" /> containing the queried calendar media items.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsmedia">
        /// Trakt API Documentation: Calendars: Get media
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMedia>> GetUserMediaAsync(DateTime startDate, uint days,
            TraktCalendarMediaType? type = null, TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetUserMediaImplAsync(startDate, days, type, group, filter, extendedInfo, cancellationToken);

        /// <summary>Gets movies and episodes from all calendars airing during the given time period.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="type">Narrow the feed to a single media type. If null, returns both. See also <seealso cref="TraktCalendarMediaType" />.</param>
        /// <param name="group">Determines how calendar items are grouped. See also <seealso cref="TraktCalendarGroup" />.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarMedia}" /> containing the queried calendar media items.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsmedia">
        /// Trakt API Documentation: Calendars: Get media
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarMedia>> GetAllMediaAsync(DateTime startDate, uint days,
            TraktCalendarMediaType? type = null, TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetAllMediaImplAsync(startDate, days, type, group, filter, extendedInfo, cancellationToken);

        /// <summary>Gets upcoming show premieres during the requested UTC date range that are trending or highly anticipated.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsreleaseshotpremieres">
        /// Trakt API Documentation: Calendars: Get hot premieres
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetHotPremieresAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetHotPremieresImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets upcoming show finales during the requested UTC date range that are trending or highly anticipated.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsreleaseshotfinales">
        /// Trakt API Documentation: Calendars: Get hot finales
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetHotFinalesAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetHotFinalesImplAsync(startDate, days, filter, extendedInfo, cancellationToken);

        /// <summary>Gets upcoming series premieres during the requested UTC date range that are trending or highly anticipated.</summary>
        /// <param name="startDate">The start date of the calendar.</param>
        /// <param name="days">The number of days for which the calendar should be queried. 1 - 33 days.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktCalendarShow}" /> containing the queried calendar shows.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcalendarsreleaseshotnew">
        /// Trakt API Documentation: Calendars: Get hot new shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktListResponse<TraktCalendarShow>> GetHotNewShowsAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetHotNewShowsImplAsync(startDate, days, filter, extendedInfo, cancellationToken);
    }
}

