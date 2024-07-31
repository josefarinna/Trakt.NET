namespace TraktNET
{
    public class TraktDefaultContext : TraktContext
    {
        public TraktDefaultContext(string contextID, string clientID, string clientSecret) : base(contextID, clientID, clientSecret)
        {
        }

        public TraktDefaultContext(string clientID, string clientSecret) : base(clientID, clientSecret)
        {
        }
    }
}
