namespace TraktNET
{
    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("checkin", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CheckinPostRequest
    {
        [TraktRequestPayload]
        internal required TraktCheckin TraktCheckin { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("checkin", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CheckinDeleteRequest
    {
    }
}
