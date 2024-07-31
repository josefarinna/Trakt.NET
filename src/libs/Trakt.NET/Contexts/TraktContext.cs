namespace TraktNET
{
    public abstract class TraktContext
    {
        public string ID { get;  }

        public string ClientID { get; set; }
        
        public string ClientSecret { get; set; }

        public static TraktContext Create(string contextID, string clientID, string clientSecret)
            => new TraktDefaultContext(contextID, clientID, clientSecret);

        public static TraktContext Create(string clientID, string clientSecret)
            => new TraktDefaultContext(clientID, clientSecret);

        public static TraktContext CreateForSandbox(string contextID, string clientID, string clientSecret)
            => new TraktSandboxContext(contextID, clientID, clientSecret);

        public static TraktContext CreateForSandbox(string clientID, string clientSecret)
            => new TraktSandboxContext(clientID, clientSecret);

        internal Uri BaseUri { get; set; }

        internal Uri BaseAuthorizationUri { get; set; }

        internal TraktContext(string contextID, string clientID, string clientSecret)
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(contextID, "context id must not be null or empty only whitespace");
            ArgumentValidator.ThrowIfNullOrWhiteSpace(clientID, "client id must not be null or empty or only whitespace", checkSpaces: true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(clientSecret, "client secret must not be null or empty or only whitespace", checkSpaces: true);

            ID = contextID;
            ClientID = clientID;
            ClientSecret = clientSecret;
            BaseUri = new Uri(Constants.API.BaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.BaseAuthorizationURL);
        }

        internal TraktContext(string clientID, string clientSecret)
            : this(Guid.NewGuid().ToString(), clientID, clientSecret)
        {
        }
    }
}
