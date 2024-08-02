using System.Diagnostics.CodeAnalysis;

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
    }
}
