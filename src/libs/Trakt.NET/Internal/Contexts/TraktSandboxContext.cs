namespace TraktNET
{
    public sealed class TraktSandboxContext : TraktContext
    {
        internal TraktSandboxContext(string clientID, string? clientSecret, string? userAgent)
            : base(clientID, clientSecret, userAgent)
        {
            BaseUri = new Uri(Constants.Api.StagingBaseURL);
            BaseAuthorizationUri = new Uri(Constants.Api.StagingBaseAuthorizationURL);
        }
    }
}
