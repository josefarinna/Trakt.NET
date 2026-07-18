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

    [TraktPostRequest("younify/users/refresh/{service_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyRefreshPostRequest
    {
    }

    [TraktPostRequest("younify/users/refresh/{service_id!!}/all_data", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyRefreshAllPostRequest
    {
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("younify/users/services/{service_id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class YounifyDisconnectDeleteRequest
    {
    }
}
