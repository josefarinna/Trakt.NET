using System.Net;

namespace TraktNET
{
    public static class ModuleTestUtility
    {
        public static TraktClient GetClient(string requestUri, string responseContent)
        {
            var client = TraktClient.Create(TestConstants.ClientId, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static TraktClient GetClient(string requestUri,  string responseContent, uint? page, uint? pageCount,
            uint? limit, uint? itemCount)
        {
            var client = TraktClient.Create(TestConstants.ClientId, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static void SetClient(TraktClient client, string requestUri, string responseContent, uint? page, uint? pageCount,
            uint? limit, uint? itemCount)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount);
            client.HttpClientProvider = httpClientProvider;
        }

        public static TraktClient GetClient(string requestUri, HttpStatusCode statusCode)
        {
            var client = TraktClient.Create(TestConstants.ClientId, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, statusCode);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }
    }
}
