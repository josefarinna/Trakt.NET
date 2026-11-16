namespace TraktNET
{
    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------
    [TraktPostRequest("oauth/token")]
    internal sealed partial class AuthorizationRequest
    {
        [TraktRequestPayload]
        internal required TraktAuthorizationPost TraktAuthorizationPost { get; set; }
    }

    [TraktPostRequest("oauth/token")]
    internal sealed partial class AuthorizationRefreshRequest
    {
        [TraktRequestPayload]
        internal required TraktAuthorizationRefreshPost TraktAuthorizationRefreshPost { get; set; }
    }

    [TraktPostRequest("oauth/revoke")]
    internal sealed partial class AuthorizationRevokeRequest
    {
        [TraktRequestPayload]
        internal required TraktAuthorizationRevokePost TraktAuthorizationRevokePost { get; set; }
    }

    [TraktPostRequest("oauth/device/code")]
    internal sealed partial class DeviceRequest
    {
        [TraktRequestPayload]
        internal required TraktDevicePost TraktDevicePost { get; set; }
    }

    [TraktPostRequest("oauth/device/token")]
    internal sealed partial class AuthorizationPollRequest
    {
        [TraktRequestPayload]
        internal required TraktAuthorizationPollPost TraktAuthorizationPollPost { get; set; }
    }
}
