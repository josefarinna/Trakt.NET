#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>A Trakt response with no content.</summary>
    public partial class TraktResponse : ITraktResponseHeaders
    {
        /// <summary>A collection of already parsed Trakt headers from <see cref="Headers" />.</summary>
        public TraktResponseHeaders? TraktHeaders { get; internal set; }

        /// <summary>The headers of the response message.</summary>
        public HttpResponseHeaders? Headers { get; internal set; }

        /// <summary>The status code of the response message.</summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>Gets, whether the request for this response was successful.</summary>
#if NET6_0_OR_GREATER
        [MemberNotNullWhen(true, nameof(TraktHeaders))]
        [MemberNotNullWhen(true, nameof(Headers))]
#endif
        public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode <= 299;

        /// <summary>The Trakt "X-Sort-By" header.</summary>
        public TraktSortBy? SortBy => TraktHeaders?.SortBy;

        /// <summary>The Trakt "X-Sort-How" header.</summary>
        public TraktSortHow? SortHow => TraktHeaders?.SortHow;

        /// <summary>The Trakt "X-Applied-Sort-By" header.</summary>
        public TraktSortBy? AppliedSortBy => TraktHeaders?.AppliedSortBy;

        /// <summary>The Trakt "X-Applied-Sort-How" header.</summary>
        public TraktSortHow? AppliedSortHow => TraktHeaders?.AppliedSortHow;

        /// <summary>The Trakt "X-Start-Date" header.</summary>
        public DateTime? StartDate => TraktHeaders?.StartDate;

        /// <summary>The Trakt "X-End-Date" header.</summary>
        public DateTime? EndDate => TraktHeaders?.EndDate;

        /// <summary>The Trakt "X-Trending-User-Count" header.</summary>
        public uint? TrendingUserCount => TraktHeaders?.TrendingUserCount;

        /// <summary>The Trakt "X-Pagination-Page" header.</summary>
        public uint? Page => TraktHeaders?.Page;

        /// <summary>The Trakt "X-Pagination-Limit" header.</summary>
        public uint? Limit => TraktHeaders?.Limit;

        /// <summary>The Trakt "X-Private-User" header.</summary>
        public bool? IsPrivateUser => TraktHeaders?.IsPrivateUser;

        /// <summary>The Trakt "X-Item-ID" header.</summary>
        public uint? ItemID => TraktHeaders?.ItemID;

        /// <summary>The Trakt "X-Item-Type" header.</summary>
        public string? ItemType => TraktHeaders?.ItemType;

        /// <summary>The Trakt "X-RateLimit" header.</summary>
        public string? RateLimit => TraktHeaders?.RateLimit; // TODO: Use Json object

        /// <summary>The Trakt "Retry-After" header.</summary>
        public uint? RetryAfter => TraktHeaders?.RetryAfter;

        /// <summary>The Trakt "X-Upgrade-URL" header.</summary>
        public string? UpgradeURL => TraktHeaders?.UpgradeURL;

        /// <summary>The Trakt "X-VIP-User" header.</summary>
        public bool? IsVIPUser => TraktHeaders?.IsVIPUser;

        /// <summary>The Trakt "X-Account-Limit" header.</summary>
        public uint? AccountLimit => TraktHeaders?.AccountLimit;

        /// <summary>The Trakt "X-Account-Locked" header.</summary>
        public bool? IsAccountLocked => TraktHeaders?.IsAccountLocked;

        /// <summary>The Trakt "X-Account-Deactivated" header.</summary>
        public bool? IsAccountDeactivated => TraktHeaders?.IsAccountDeactivated;

        /// <summary>Implicit conversion to bool for this response.</summary>
        /// <param name="response">The <see cref="TraktResponse" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktResponse response) => response.IsSuccess;
    }

    /// <summary>A Trakt response with content of type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type.</typeparam>
    public partial class TraktResponse<TResponseContentType> : TraktResponse
    {
        /// <summary>Gets, whether this response has a content value set.</summary>
#if NET6_0_OR_GREATER
        [MemberNotNullWhen(true, nameof(Content))]
        [MemberNotNullWhen(true, nameof(ContentHeaders))]
#endif
        public bool HasValue => Content != null;

        /// <summary>The content of the response.</summary>
        public TResponseContentType? Content { get; internal set; }

        /// <summary>The headers of the response messsage content.</summary>
        public HttpContentHeaders? ContentHeaders { get; internal set; }

        /// <summary>Implicit conversion to bool for this response.</summary>
        /// <param name="response">The <see cref="TraktResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
