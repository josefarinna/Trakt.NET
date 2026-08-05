namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to people.
    /// <para>This module contains all methods of the "Trakt API Documentation - People" section.</para>
    /// </summary>
    public sealed partial class TraktPeopleModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktPagedResponse<uint>> GetRecentlyUpdatedPeopleIDsImplAsync(DateTime? startDate = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new PeopleRecentlyUpdatedIDsGetRequest
            {
                StartDate = startDate,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<uint>(_context, request, (page, limit)
                => new PeopleRecentlyUpdatedIDsGetRequest
                {
                    StartDate = startDate,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktRecentlyUpdatedPerson>> GetRecentlyUpdatedPeopleImplAsync(DateTime? startDate = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new PeopleRecentlyUpdatedGetRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktRecentlyUpdatedPerson>(_context, request, (page, limit)
                => new PeopleRecentlyUpdatedGetRequest
                {
                    StartDate = startDate,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktPerson>> GetPersonImplAsync(string personIdOrSlug, TraktExtendedInfo? extendedInfo = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var request = new PersonSummaryGetRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPerson>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktList>> GetPersonListsImplAsync(string personIdOrSlug, TraktListType? listType = null,
            TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            var request = new PersonListsGetRequest
            {
                Id = personIdOrSlug,
                Type = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktList>(_context, request, (page, limit)
                => new PersonListsGetRequest
                {
                    Id = personIdOrSlug,
                    Type = listType,
                    SortOrder = listSortOrder,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktPersonMovieCredits>> GetPersonMovieCreditsImplAsync(string personIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPersonMovieCredits>(_context, new PersonMovieCreditsGetRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        private Task<TraktResponse<TraktPersonShowCredits>> GetPersonShowCreditsImplAsync(string personIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPersonShowCredits>(_context, new PersonShowCreditsGetRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        private Task<TraktResponse> RefreshPersonImplAsync(string personIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new PersonRefreshPostRequest
            {
                Id = personIDOrSlug
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> ReportPersonImplAsync(string personIdOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            var content = new TraktReportPost
            {
                Reason = reason,
                Message = message
            };

            var request = new PersonReportPostRequest
            {
                Id = personIdOrSlug,
                TraktReportPost = content
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
