namespace TraktNET
{
    internal abstract class RequestBase(HttpMethod method, Uri? requestUri) : HttpRequestMessage(method, requestUri)
    {
        internal abstract TraktOAuthRequirement OAuthRequirement { get; }

        internal abstract void BuildUri();
    }
}
