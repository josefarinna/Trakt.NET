namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to watch now sources.
    /// <para>This module contains all methods of the "Trakt API Documentation - Watch Now" section.</para>
    /// </summary>
    public sealed partial class TraktWatchnowModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>> GetWatchnowSourcesImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>(_context, new WatchnowSourcesGetRequest(), cancellationToken);

        private Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>> GetWatchnowSourcesCountryImplAsync(string countryCode, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>(_context, new WatchnowSourcesCountryGetRequest { CountryCode = countryCode }, cancellationToken);
    }
}
