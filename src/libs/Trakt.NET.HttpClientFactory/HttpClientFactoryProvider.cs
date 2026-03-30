namespace TraktNET
{
    internal sealed class HttpClientFactoryProvider(IHttpClientFactory httpClientFactory, bool baseAuthRequest) : HttpClientProvider
    {
        internal override HttpClient GetHttpClient(TraktContext context, bool baseAuthRequest) => httpClientFactory.CreateClient(context.ID);
    }
}
