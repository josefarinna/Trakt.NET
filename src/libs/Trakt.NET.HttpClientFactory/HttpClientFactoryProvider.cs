namespace TraktNET
{
    internal sealed class HttpClientFactoryProvider(IHttpClientFactory httpClientFactory) : HttpClientProvider
    {
        internal override HttpClient GetHttpClient(TraktContext context, bool baseAuthRequest)
            => httpClientFactory.CreateClient(baseAuthRequest ? $"{context.ID}_auth" : context.ID);
    }
}
