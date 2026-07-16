using System.Threading;
using System.Threading.Tasks;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        private Task<TraktResponse<TraktPlexSettings>> GetPlexSettingsImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new UserPlexSettingsGetRequest();
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPlexSettings>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UpdatePlexSettingsImplAsync(TraktPlexSettingsUpdate settingsUpdate, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(settingsUpdate);

            var request = new UserPlexSettingsPutRequest
            {
                TraktPlexSettingsUpdate = settingsUpdate
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktPlexConnectResponse>> ConnectPlexImplAsync(TraktPlexConnectPost connectPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(connectPost);

            var request = new UserPlexConnectPostRequest
            {
                TraktPlexConnectPost = connectPost
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPlexConnectResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> DisconnectPlexImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new UserPlexDisconnectDeleteRequest();
            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktPlexServersResponse>> GetPlexServersImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new UserPlexServersGetRequest();
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPlexServersResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktPlexServerAccountsAndLibraries>> GetPlexServerAccountsImplAsync(string serverId, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(serverId, nameof(serverId));

            var request = new UserPlexServerAccountsGetRequest
            {
                ServerId = serverId
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktPlexServerAccountsAndLibraries>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> SyncPlexImplAsync(TraktPlexSyncPost syncPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(syncPost);

            var request = new UserPlexSyncPostRequest
            {
                TraktPlexSyncPost = syncPost
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
