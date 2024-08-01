namespace TraktNET
{
    internal sealed class TestHttpClientProvider : HttpClientProvider
    {
        internal RequestMockHttpMessageHandler MockMessageHandler { get; }

        public TestHttpClientProvider() => MockMessageHandler = new RequestMockHttpMessageHandler();

        internal override HttpClient GetHttpClient(TraktContext context) => new(MockMessageHandler);
    }
}
