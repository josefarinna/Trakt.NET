namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to countries.
    /// <para>This module contains all methods of the "Trakt API Documentation - Countries" section.</para>
    /// </summary>
    public sealed partial class TraktCountriesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktCountry>> GetMovieCountriesImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktCountry>(_context, new CountriesMoviesGetRequest(), cancellationToken);

        private Task<TraktListResponse<TraktCountry>> GetShowCountriesImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktCountry>(_context, new CountriesShowsGetRequest(), cancellationToken);
    }
}
