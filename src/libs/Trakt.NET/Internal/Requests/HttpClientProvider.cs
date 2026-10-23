using System.Net.Http.Headers;

#if !NETSTANDARD2_0
using System.Net.Mime;
#endif

namespace TraktNET
{
    internal abstract class HttpClientProvider
    {
        internal abstract HttpClient GetHttpClient(TraktContext context, bool baseAuthRequest);

        protected static HttpClient CreateHttpClient(HttpMessageHandler handler, TraktContext context, bool baseAuthRequest)
        {
            var httpClient = new HttpClient(handler, disposeHandler: false)
            {
                BaseAddress = !baseAuthRequest ? context.BaseUri : context.BaseAuthorizationUri
            };

#if NETSTANDARD2_0
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaTypeNames.ApplicationJson));
#else
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
#endif

            return httpClient;
        }
    }

    /// <summary>
    /// Default provider, owned by a single <see cref="TraktContext" />.
    /// <para>
    /// All instances share one static <see cref="HttpMessageHandler" />, which holds the connection pool, so sockets are reused
    /// across clients. The <see cref="HttpClient" /> instances themselves are cached per provider instance and are collected
    /// together with their context.
    /// </para>
    /// </summary>
    internal sealed class DefaultHttpClientProvider : HttpClientProvider
    {
#if NET5_0_OR_GREATER
        // Recycle pooled connections periodically, so DNS changes are picked up by the long-lived shared handler.
        private static readonly SocketsHttpHandler s_sharedHandler = new() { PooledConnectionLifetime = TimeSpan.FromMinutes(2) };
#else
        private static readonly HttpClientHandler s_sharedHandler = new();
#endif

        private HttpClient? _httpClient;
        private HttpClient? _authorizationHttpClient;

        internal override HttpClient GetHttpClient(TraktContext context, bool baseAuthRequest)
            => baseAuthRequest
                ? LazyInitializer.EnsureInitialized(ref _authorizationHttpClient, () => CreateHttpClient(s_sharedHandler, context, true))!
                : LazyInitializer.EnsureInitialized(ref _httpClient, () => CreateHttpClient(s_sharedHandler, context, false))!;
    }
}
