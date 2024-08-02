using RichardSzalay.MockHttp;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace TraktNET
{
    internal sealed class TestHttpClientProvider : HttpClientProvider, IDisposable
    {
        private const string AcceptMediaType = "application/json";
        private const string TraktApiHeaderKey = "trakt-api-key";
        private const string TraktApiVersionHeaderKey = "trakt-api-version";

        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly string _baseUrl;

        public TestHttpClientProvider(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("invalid base URL", nameof(baseUrl));
            }

            _mockHttpMessageHandler = new MockHttpMessageHandler();
            _baseUrl = baseUrl;
        }

        public void SetupMockResponse([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri,
            [StringSyntax(StringSyntaxAttribute.Json)] string responseContent)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("invalid request URI", nameof(requestUri));
            }

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new ArgumentException("invalid response content", nameof(responseContent));
            }

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent, Encoding.UTF8, AcceptMediaType)
            };

            _mockHttpMessageHandler.When(_baseUrl + requestUri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TraktApiHeaderKey, TestConstants.ClientId },
                    { TraktApiVersionHeaderKey, "2" }
                })
                .Respond(_ => response);
        }

        internal override HttpClient GetHttpClient(TraktContext context)
        {
            var httpClient = _mockHttpMessageHandler.ToHttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptMediaType));
            return httpClient;
        }

        public void Dispose() => _mockHttpMessageHandler.Dispose();
    }
}
