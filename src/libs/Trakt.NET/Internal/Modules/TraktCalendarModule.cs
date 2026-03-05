namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to calendars.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/calendars">"Trakt API Documentation - Calendars"</a> section.
    /// </summary>
    public sealed partial class TraktCalendarModule(TraktContext context) : BaseModule(context)
    {
        public Task<TraktListResponse<TraktCalendarShow>> GetUserShowsImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUserShowsGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetUserNewShowsImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUserNewShowsGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetUserSeasonPremieresImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetUserFinalesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUserFinalesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetUserMoviesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUserMoviesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetUserStreamingMoviesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetUserDVDMoviesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllShowsImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllShowsGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllNewShowsImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllNewShowsGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllSeasonPremieresImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllSeasonPremieresGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllFinalesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllFinalesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetAllMoviesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllMoviesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetAllStreamingMoviesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetAllDVDMoviesImplAsync(DateTime? startDate = null, uint? days = null,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            var request = new CalendarAllDVDMoviesGetRequest
            {
                StartDate = startDate?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }
    }
}
