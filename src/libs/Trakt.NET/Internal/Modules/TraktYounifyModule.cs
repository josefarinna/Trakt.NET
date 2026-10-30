namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to Younify connections.
    /// <para>This module contains all methods of the "Trakt API Documentation - Younify" section.</para>
    /// </summary>
    public sealed partial class TraktYounifyModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktYounifyConnection>> GetConnectionsImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktYounifyConnection>(_context, new YounifyConnectionsGetRequest(), cancellationToken);

        private Task<TraktResponse<TraktYounifyConnectResponse>> ConnectImplAsync(TraktYounifyConnectPost post, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteSingleItemRequestAsync<TraktYounifyConnectResponse>(_context, new YounifyConnectPostRequest { TraktYounifyConnectPost = post }, cancellationToken);

        private Task<TraktResponse> RefreshServiceImplAsync(TraktYounifyRefreshServicePost post, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyRefreshServicePostRequest { TraktYounifyRefreshServicePost = post }, cancellationToken);

        private Task<TraktResponse> RefreshImplAsync(string serviceId, TraktYounifyRefreshPost? post = null, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyRefreshPostRequest { ServiceId = serviceId, TraktYounifyRefreshPost = post }, cancellationToken);

        private Task<TraktResponse> RefreshAllImplAsync(string serviceId, bool allData = true, TraktYounifyRefreshPost? post = null, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyRefreshAllPostRequest { ServiceId = serviceId, AllData = allData, TraktYounifyRefreshPost = post }, cancellationToken);

        private Task<TraktResponse> DisconnectImplAsync(string serviceId, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyDisconnectDeleteRequest { ServiceId = serviceId }, cancellationToken);
    }
}
