namespace TraktNET
{
    public sealed class TraktDefaultContext(string clientID, string clientSecret) : TraktContext(clientID, clientSecret)
    {
    }
}
