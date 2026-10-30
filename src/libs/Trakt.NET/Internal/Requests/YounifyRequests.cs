namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("younify/connections", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyConnectionsGetRequest
    {
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("younify/connect", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyConnectPostRequest
    {
        [TraktRequestPayload]
        internal required TraktYounifyConnectPost TraktYounifyConnectPost { get; set; }
    }

    [TraktPostRequest("younify/users/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyRefreshServicePostRequest
    {
        [TraktRequestPayload]
        internal required TraktYounifyRefreshServicePost TraktYounifyRefreshServicePost { get; set; }
    }

    [TraktPostRequest("younify/users/refresh/{service_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyRefreshPostRequest
    {
        [TraktRequestPayload]
        internal TraktYounifyRefreshPost? TraktYounifyRefreshPost { get; set; }
    }

    [TraktPostRequest("younify/users/refresh/{service_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyRefreshAllPostRequest
    {
        [TraktRequestParameter]
        internal bool? AllData { get; set; } = true;

        [TraktRequestPayload]
        internal TraktYounifyRefreshPost? TraktYounifyRefreshPost { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("younify/users/services/{service_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyDisconnectDeleteRequest
    {
    }
}
