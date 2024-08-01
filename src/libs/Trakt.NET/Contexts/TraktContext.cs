namespace TraktNET
{
    public abstract class TraktContext
    {
        private string _clientId = string.Empty;
        private string _clientSecret = string.Empty;

        public string ID { get; }

        public string ClientID
        {
            get => _clientId;

            set
            {
                ArgumentValidator.ThrowIfNullOrWhiteSpace(value, "client id must not be null or empty or only whitespace", checkSpaces: true);
                _clientId = value;
            }
        }

        public string ClientSecret
        {
            get => _clientSecret;

            set
            {
                ArgumentValidator.ThrowIfNullOrWhiteSpace(value, "client secret must not be null or empty or only whitespace", checkSpaces: true);
                _clientSecret = value;
            }
        }

        public TraktAuthorization Authorization { get; set; }

        public bool IgnoreOAuthIfOptional { get; set; }

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

        internal HttpClientProvider HttpClientProvider { get; set; }

        internal TraktContext(string contextID, string clientID, string clientSecret)
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(contextID, "context id must not be null or empty or only whitespace");

            ID = contextID;
            ClientID = clientID;
            ClientSecret = clientSecret;
            Authorization = new TraktAuthorization();
            BaseUri = new Uri(Constants.API.BaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.BaseAuthorizationURL);
            HttpClientProvider = new DefaultHttpClientProvider();
        }

        internal TraktContext(string clientID, string clientSecret)
            : this(Guid.NewGuid().ToString(), clientID, clientSecret)
        {
        }

        internal HttpClient GetHttpClient() => HttpClientProvider.GetHttpClient(this);
    }
}
