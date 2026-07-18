namespace TraktNET
{
    public sealed partial class TraktYounifyModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktYounifyConnection>> GetConnectionsImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktYounifyConnection>(_context, new YounifyConnectionsGetRequest(), cancellationToken);

        private Task<TraktResponse<TraktYounifyConnectResponse>> ConnectImplAsync(TraktYounifyConnectPost post, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteSingleItemRequestAsync<TraktYounifyConnectResponse>(_context, new YounifyConnectPostRequest { TraktYounifyConnectPost = post }, cancellationToken);

        private Task<TraktResponse> RefreshImplAsync(string serviceId, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyRefreshPostRequest { ServiceId = serviceId }, cancellationToken);

        private Task<TraktResponse> RefreshAllImplAsync(string serviceId, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyRefreshAllPostRequest { ServiceId = serviceId }, cancellationToken);

        private Task<TraktResponse> DisconnectImplAsync(string serviceId, CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteNoContentRequestAsync(_context, new YounifyDisconnectDeleteRequest { ServiceId = serviceId }, cancellationToken);
    }
}
