namespace TraktNET
{
    internal sealed class HttpClientFactoryProvider(IHttpClientFactory httpClientFactory) : HttpClientProvider
    {
        internal override HttpClient GetHttpClient(TraktContext context) => httpClientFactory.CreateClient(context.ID);
    }
}
