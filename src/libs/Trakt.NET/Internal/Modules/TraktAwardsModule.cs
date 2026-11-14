namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to awards.
    /// <para>This module contains all methods of the "Trakt API Documentation - Awards" section.</para>
    /// </summary>
    public sealed partial class TraktAwardsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktAwardCatalogCeremony>> GetAwardCatalogImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new AwardsCatalogGetRequest();
            return RequestHandler.ExecuteListRequestAsync<TraktAwardCatalogCeremony>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktUpcomingCeremony>> GetCeremoniesImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new AwardsCeremoniesGetRequest();
            return RequestHandler.ExecuteListRequestAsync<TraktUpcomingCeremony>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktTitleAward>> GetMovieAwardsImplAsync(string movieIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new MovieAwardsGetRequest
            {
                Id = movieIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktTitleAward>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktTitleAward>> GetShowAwardsImplAsync(string showIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new ShowAwardsGetRequest
            {
                Id = showIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktTitleAward>(_context, request, cancellationToken);
        }

        private Task<TraktListResponse<TraktPersonAward>> GetPersonAwardsImplAsync(string personIDOrSlug, CancellationToken cancellationToken = default)
        {
            var request = new PersonAwardsGetRequest
            {
                Id = personIDOrSlug
            };

            return RequestHandler.ExecuteListRequestAsync<TraktPersonAward>(_context, request, cancellationToken);
        }
    }
}
