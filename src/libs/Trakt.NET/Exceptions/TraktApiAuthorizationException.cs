namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an access token is required, but was not provided.</summary>
    public sealed partial class TraktApiAuthorizationException : TraktApiException
    {
    }
}
