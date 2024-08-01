namespace TraktNET
{
    internal static class ModuleTestUtility
    {
        private const string ClientId = "trakt_test_client_id";
        private const string ClientSecret = "trakt_test_client_secret";

        internal static TraktContext GetContext()
        {
            var context = TraktContext.Create(ClientId, ClientSecret);
            context.HttpClientProvider = new TestHttpClientProvider();
            return context;
        }
    }
}
