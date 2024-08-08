namespace TraktNET
{
    public sealed class TraktSandboxContext : TraktContext
    {
        internal TraktSandboxContext(string clientID, string clientSecret)
            : base(clientID, clientSecret)
        {
            BaseUri = new Uri(Constants.API.StagingBaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.StagingBaseAuthorizationURL);
        }
    }
}
