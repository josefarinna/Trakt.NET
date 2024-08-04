namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an timed out intermediate proxy server while waiting for a response.</summary>
    public sealed partial class TraktApiGatewayTimeoutException : TraktApiException
    {
    }
}
