using System.Collections.Concurrent;
using System.Net.Http.Headers;

#if !NETSTANDARD2_0
using System.Net.Mime;
#endif

namespace TraktNET
{
    internal abstract class HttpClientProvider
    {
        internal abstract HttpClient GetHttpClient(TraktContext context);

        protected static HttpClient CreateHttpClient(TraktContext context)
        {
            var httpClient = new HttpClient { BaseAddress = context.BaseUri };

#if NETSTANDARD2_0
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaTypeNames.ApplicationJson));
#else
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
#endif

            return httpClient;
        }
    }

    internal sealed class DefaultHttpClientProvider : HttpClientProvider
    {
        private static readonly ConcurrentDictionary<string, HttpClient> s_httpClientCache = new();

        internal override HttpClient GetHttpClient(TraktContext context)
            => s_httpClientCache.GetOrAdd(context.ID, CreateHttpClient(context));
    }
}
