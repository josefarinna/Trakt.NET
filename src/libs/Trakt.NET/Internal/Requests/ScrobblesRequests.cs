namespace TraktNET
{
    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("scrobble/pause", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ScrobblePausePostRequest
    {
    }

    [TraktPostRequest("scrobble/start", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ScrobbleStartPostRequest
    {
    }

    [TraktPostRequest("scrobble/stop", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ScrobbleStopPostRequest
    {
    }
}
