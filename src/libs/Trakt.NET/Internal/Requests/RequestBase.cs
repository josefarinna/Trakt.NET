namespace TraktNET
{
    internal abstract class RequestBase(HttpMethod method, Uri? requestUri) : HttpRequestMessage(method, requestUri)
    {
        internal abstract TraktOAuthRequirement OAuthRequirement { get; }

        internal virtual TraktRequestObjectType RequestObjectType => TraktRequestObjectType.None;

        internal RequestFlags Flags { get; set; }

        internal virtual string ObjectId => string.Empty;

        internal virtual uint SeasonNr => 0;

        internal virtual uint EpisodeNr => 0;

        internal abstract void BuildUri();
    }

    internal record struct RequestFlags
    {
        internal bool IsCheckinRequest { get; set; }

        internal bool IsDeviceRequest { get; set; }

        internal bool IsAuthorizationRequest { get; set; }

        internal bool IsAuthorizationRevokeRequest { get; set; }
    }
}
