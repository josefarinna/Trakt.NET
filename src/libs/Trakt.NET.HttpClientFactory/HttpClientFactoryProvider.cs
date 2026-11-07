namespace TraktNET
{
    internal sealed class HttpClientFactoryProvider(IHttpClientFactory httpClientFactory, string httpClientName) : HttpClientProvider
    {
        internal override HttpClient GetHttpClient(TraktContext context, bool baseAuthRequest)
            => httpClientFactory.CreateClient(baseAuthRequest ? $"{httpClientName}_auth" : httpClientName);
    }
}
