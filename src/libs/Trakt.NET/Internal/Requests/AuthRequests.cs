namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------
    [TraktGetRequest("oauth/authorize")]
    internal sealed partial class AuthorizeRequest
    {
        [TraktRequestQuery("response_type")]
        public required string ResponseType { get; set; } = "code";

        [TraktRequestQuery("client_id")]
        public required string ClientId { get; set; }

        [TraktRequestQuery("redirect_uri")]
        public required string RedirectUri { get; set; }

        [TraktRequestQuery("state")]
        public string? State { get; set; }

        [TraktRequestParameter]
        public bool? Signup { get; set; }

        [TraktRequestParameter]
        public string? Prompt { get; set; }
    }

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
