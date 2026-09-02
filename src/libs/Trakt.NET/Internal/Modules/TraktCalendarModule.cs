namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to calendars.
    /// <para>This module contains all methods of the <see href="https://docs.trakt.tv/reference/about-calendars">Trakt API Documentation - Calendars</see> section.</para>
    /// </summary>
    public sealed partial class TraktCalendarModule(TraktContext context) : BaseModule(context)
    {
        public Task<TraktListResponse<TraktCalendarShow>> GetUserShowsImplAsync(DateTime startDate, uint days,
            TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserShowsGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Group = group,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetUserNewShowsImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserNewShowsGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetUserSeasonPremieresImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetUserFinalesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserFinalesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetUserMoviesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserMoviesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetUserStreamingMoviesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetUserDVDMoviesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllShowsImplAsync(DateTime startDate, uint days,
            TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllShowsGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Group = group,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllNewShowsImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllNewShowsGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllSeasonPremieresImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllSeasonPremieresGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetAllFinalesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllFinalesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetAllMoviesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllMoviesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetAllStreamingMoviesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMovie>> GetAllDVDMoviesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllDVDMoviesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMovie>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMedia>> GetHotReleasesImplAsync(DateTime startDate, uint days,
            TraktCalendarMediaType? type = null, TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllReleasesHotGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Group = group,
                Filter = filter,
                ExtendedInfo = extendedInfo,
                Type = type
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMedia>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMedia>> GetUserMediaImplAsync(DateTime startDate, uint days,
            TraktCalendarMediaType? type = null, TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarUserMediaGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Group = group,
                Filter = filter,
                ExtendedInfo = extendedInfo,
                Type = type
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMedia>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarMedia>> GetAllMediaImplAsync(DateTime startDate, uint days,
            TraktCalendarMediaType? type = null, TraktCalendarGroup? group = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllMediaGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Group = group,
                Filter = filter,
                ExtendedInfo = extendedInfo,
                Type = type
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarMedia>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetHotPremieresImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllReleasesHotPremieresGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetHotFinalesImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllReleasesHotFinalesGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        public Task<TraktListResponse<TraktCalendarShow>> GetHotNewShowsImplAsync(DateTime startDate, uint days,
            TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ValidateCalendarParameters(startDate);

            var request = new CalendarAllReleasesHotNewGetRequest
            {
                StartDate = startDate.ToTraktSortDateTimeString(),
                Days = days,
                Filter = filter,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktCalendarShow>(_context, request, cancellationToken);
        }

        private static void ValidateCalendarParameters(DateTime startDate)
        {
            if (startDate <= DateTime.MinValue || startDate == default)
                throw new ArgumentNullException(nameof(startDate));
        }
    }
}

