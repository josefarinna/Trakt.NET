using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace TraktNET
{
    public static class ModuleTestUtility
    {
        public static TraktContext GetContext([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri,
            [StringSyntax(StringSyntaxAttribute.Json)] string responseContent)
        {
            var context = TraktContext.Create(TestConstants.ClientId, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent);
            context.HttpClientProvider = httpClientProvider;
            return context;
        }

        public static TraktContext GetContext([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri,
            [StringSyntax(StringSyntaxAttribute.Json)] string responseContent, uint? page, uint? pageCount, uint? limit, uint? itemCount)
        {
            var context = TraktContext.Create(TestConstants.ClientId, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount);
            context.HttpClientProvider = httpClientProvider;
            return context;
        }

        public static void SetContext(TraktContext context, [StringSyntax(StringSyntaxAttribute.Uri)] string requestUri,
            [StringSyntax(StringSyntaxAttribute.Json)] string responseContent, uint? page, uint? pageCount, uint? limit, uint? itemCount)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, responseContent, page, pageCount, limit, itemCount);
            context.HttpClientProvider = httpClientProvider;
        }

        public static TraktContext GetContext([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, HttpStatusCode statusCode)
        {
            var context = TraktContext.Create(TestConstants.ClientId, TestConstants.ClientSecret);
            var httpClientProvider = new TestHttpClientProvider(Constants.API.BaseURL);
            httpClientProvider.SetupMockResponse(requestUri, statusCode);
            context.HttpClientProvider = httpClientProvider;
            return context;
        }
    }
}
