using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    public partial class TraktResponse
    {
        internal static TraktResponse Create(HttpStatusCode statusCode, TraktResponseHeaders? traktHeaders, HttpResponseHeaders? headers)
            => new()
            {
                TraktHeaders = traktHeaders,
                Headers = headers,
                StatusCode = statusCode
            };
    }

    public partial class TraktResponse<T>
    {
        internal static TraktResponse<T> Create(HttpStatusCode statusCode, T? content, TraktResponseHeaders? traktHeaders,
            HttpResponseHeaders? headers, HttpContentHeaders? contentHeaders)
            => new()
            {
                TraktHeaders = traktHeaders,
                Headers = headers,
                StatusCode = statusCode,
                Content = content,
                ContentHeaders = contentHeaders
            };
    }

    public partial class TraktListResponse<T>
    {
        internal static new TraktListResponse<T> Create(HttpStatusCode statusCode, IReadOnlyList<T>? content,
            TraktResponseHeaders? traktHeaders, HttpResponseHeaders? headers, HttpContentHeaders? contentHeaders)
            => new()
            {
                TraktHeaders = traktHeaders,
                Headers = headers,
                StatusCode = statusCode,
                Content = content,
                ContentHeaders = contentHeaders
            };
    }

    public partial class TraktPagedResponse<T>
    {
        internal static new TraktPagedResponse<T> Create(HttpStatusCode statusCode, IReadOnlyList<T>? content,
            TraktResponseHeaders? traktHeaders, HttpResponseHeaders? headers, HttpContentHeaders? contentHeaders)
            => new()
            {
                TraktHeaders = traktHeaders,
                Headers = headers,
                StatusCode = statusCode,
                Content = content,
                ContentHeaders = contentHeaders
            };
    }
}
