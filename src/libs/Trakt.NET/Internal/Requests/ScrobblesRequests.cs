namespace TraktNET
{
    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("scrobble/pause", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ScrobblePausePostRequest
    {
        [TraktRequestPayload]
        internal required TraktScrobblePost TraktScrobblePost { get; set; }
    }

    [TraktPostRequest("scrobble/start", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ScrobbleStartPostRequest
    {
        [TraktRequestPayload]
        internal required TraktScrobblePost TraktScrobblePost { get; set; }
    }

    [TraktPostRequest("scrobble/stop", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ScrobbleStopPostRequest
    {
        [TraktRequestPayload]
        internal required TraktScrobblePost TraktScrobblePost { get; set; }
    }
}
