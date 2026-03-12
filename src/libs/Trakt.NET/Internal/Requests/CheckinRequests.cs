namespace TraktNET
{
    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("checkin", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CheckinPostRequest
    {
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("checkin", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CheckinDeleteRequest
    {
    }
}
