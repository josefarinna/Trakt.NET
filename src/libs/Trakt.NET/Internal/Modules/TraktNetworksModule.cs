namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to networks.
    /// <para>This module contains all methods of the "Trakt API Documentation - Networks" section.</para>
    /// </summary>
    public sealed partial class TraktNetworksModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktNetwork>> GetNetworksImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktNetwork>(_context, new NetworksGetRequest(), cancellationToken);
    }
}
