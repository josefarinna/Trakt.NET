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

    public partial class TraktResponse<TResponseContentType>
    {
        internal static TraktResponse<TResponseContentType> Create(HttpStatusCode statusCode, TResponseContentType? content,
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

    public partial class TraktListResponse<TResponseContentType>
    {
        internal static new TraktListResponse<TResponseContentType> Create(HttpStatusCode statusCode, IReadOnlyList<TResponseContentType>? content,
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

    public partial class TraktPagedResponse<TResponseContentType>
    {
        internal TraktContext? Context { get; set; }

        internal Func<uint?, uint?, RequestBase>? RequestBuilder { get; set; }

        internal static new TraktPagedResponse<TResponseContentType> Create(HttpStatusCode statusCode, IReadOnlyList<TResponseContentType>? content,
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
