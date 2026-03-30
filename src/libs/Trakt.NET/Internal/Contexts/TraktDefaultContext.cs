namespace TraktNET
{
    public sealed class TraktDefaultContext(string clientID, string clientSecret, string? userAgent) : TraktContext(clientID, clientSecret, userAgent)
    {
    }
}
