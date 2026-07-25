namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("team", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
    internal sealed partial class TeamMembersGetRequest
    {
    }
}
