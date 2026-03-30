namespace TraktNET
{
    public sealed class TraktSandboxContext : TraktContext
    {
        internal TraktSandboxContext(string clientID, string clientSecret, string? userAgent)
            : base(clientID, clientSecret, userAgent)
        {
            BaseUri = new Uri(Constants.API.StagingBaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.StagingBaseAuthorizationURL);
        }
    }
}
