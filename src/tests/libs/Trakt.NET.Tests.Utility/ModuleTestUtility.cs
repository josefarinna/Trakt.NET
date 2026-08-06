using System.Net;

namespace TraktNET
{
    public static class ModuleTestUtility
    {
        public static TraktClient GetClient(string requestUri, string responseContent)
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static TraktClient GetClient(string requestUri, string responseContent, uint? page, uint? pageCount,
            uint? limit, uint? itemCount)
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static TraktClient GetClient(string requestUri, HttpStatusCode statusCode)
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, statusCode);
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

        public static TraktClient GetOAuthClient(string requestUri)
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            client.Authorization = TestConstants.MockAuthorization;

            string baseUrl = requestUri == "oauth/authorize" ? Constants.API.BaseAuthorizationURL : Constants.API.BaseURL;

            var httpClientProvider = new TestHttpClientProvider(baseUrl);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static TraktClient GetOAuthClient(string requestUri, string responseContent, uint? page = null, uint? pageCount = null,
            uint? limit = null, uint? itemCount = null, bool noOauthHeaders = false)
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            client.Authorization = TestConstants.MockAuthorization;

            string baseUrl = requestUri == "oauth/authorize" ? Constants.API.BaseAuthorizationURL : Constants.API.BaseURL;

            var httpClientProvider = new TestHttpClientProvider(baseUrl);
            httpClientProvider.SetupOAuthMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount, noOauthHeaders);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static TraktClient GetOAuthClient(string requestUri, HttpStatusCode statusCode, bool noOauthHeaders = false)
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            client.Authorization = TestConstants.MockAuthorization;

            string baseUrl = requestUri == "oauth/authorize" ? Constants.API.BaseAuthorizationURL : Constants.API.BaseURL;

            var httpClientProvider = new TestHttpClientProvider(baseUrl);
            httpClientProvider.SetupOAuthMockResponse(requestUri, statusCode, noOauthHeaders);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static void SetOAuthClient(TraktClient client, string requestUri, string responseContent, uint? page = null, uint? pageCount = null,
            uint? limit = null, uint? itemCount = null, bool noOauthHeaders = false)
        {
            string baseUrl = requestUri == "oauth/authorize" ? Constants.API.BaseAuthorizationURL : Constants.API.BaseURL;

            var httpClientProvider = new TestHttpClientProvider(baseUrl);
            httpClientProvider.SetupOAuthMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount, noOauthHeaders);
            client.HttpClientProvider = httpClientProvider;
        }

        public static TraktClient GetOAuthClientForSandbox(string requestUri, string responseContent, uint? page, uint? pageCount,
            uint? limit, uint? itemCount)
        {
            var client = TraktClient.CreateForSandbox(TestConstants.ClientID, TestConstants.ClientSecret);
            client.Authorization = TestConstants.MockAuthorization;

            string baseUrl = requestUri == "oauth/authorize" ? Constants.API.BaseAuthorizationURL : Constants.API.BaseURL;

            var httpClientProvider = new TestHttpClientProvider(baseUrl);
            httpClientProvider.SetupOAuthMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static TraktClient GetOAuthClientForSandbox(string requestUri, HttpStatusCode statusCode)
        {
            var client = TraktClient.CreateForSandbox(TestConstants.ClientID, TestConstants.ClientSecret);
            client.Authorization = TestConstants.MockAuthorization;

            string baseUrl = requestUri == "oauth/authorize" ? Constants.API.BaseAuthorizationURL : Constants.API.BaseURL;

            var httpClientProvider = new TestHttpClientProvider(baseUrl);
            httpClientProvider.SetupOAuthMockResponse(requestUri, statusCode);
            client.HttpClientProvider = httpClientProvider;
            return client;
        }

        public static void AddMockExpectationResponse(TraktClient client, string requestUri, string requestContent, string responseContent)
        {
            if (client.HttpClientProvider is TestHttpClientProvider httpClientProvider)
            {
                httpClientProvider.AddExpectationMockResponse(requestUri, requestContent, responseContent, HttpStatusCode.OK);
            }
        }

        public static void AddMockExpectationResponse(TraktClient client, string requestUri, string requestContent, HttpStatusCode statusCode)
        {
            if (client.HttpClientProvider is TestHttpClientProvider httpClientProvider)
            {
                httpClientProvider.AddExpectationMockResponse(requestUri, requestContent, null, statusCode);
            }
        }
    }
}
