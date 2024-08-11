namespace TraktNET
{
    /// <summary>A collection of Trakt headers.</summary>
    public sealed class TraktResponseHeaders : ITraktResponseHeaders, ITraktPagedResponseHeaders
    {
        /// <summary>The Trakt "X-Sort-By" header.</summary>
        public TraktSortBy? SortBy { get; internal set; }

        /// <summary>The Trakt "X-Sort-How" header.</summary>
        public TraktSortHow? SortHow { get; internal set; }

        /// <summary>The Trakt "X-Applied-Sort-By" header.</summary>
        public TraktSortBy? AppliedSortBy { get; internal set; }

        /// <summary>The Trakt "X-Applied-Sort-How" header.</summary>
        public TraktSortHow? AppliedSortHow { get; internal set; }

        /// <summary>The Trakt "X-Start-Date" header.</summary>
        public DateTime? StartDate { get; internal set; }

        /// <summary>The Trakt "X-End-Date" header.</summary>
        public DateTime? EndDate { get; internal set; }

        /// <summary>The Trakt "X-Trending-User-Count" header.</summary>
        public uint? TrendingUserCount { get; internal set; }

        /// <summary>The Trakt "X-Pagination-Page" header.</summary>
        public uint? Page { get; internal set; }

        /// <summary>The Trakt "X-Pagination-Limit" header.</summary>
        public uint? Limit { get; internal set; }

        /// <summary>The Trakt "X-Pagination-Page-Count" header.</summary>
        public uint? PageCount { get; internal set; }

        /// <summary>The Trakt "X-Pagination-Item-Count" header.</summary>
        public uint? ItemCount { get; internal set; }

        /// <summary>The Trakt "X-Private-User" header.</summary>
        public bool? IsPrivateUser { get; internal set; }

        /// <summary>The Trakt "X-Item-ID" header.</summary>
        public uint? ItemID { get; internal set; }

        /// <summary>The Trakt "X-Item-Type" header.</summary>
        public string? ItemType { get; internal set; }

        /// <summary>The Trakt "X-RateLimit" header.</summary>
        public string? RateLimit { get; internal set; } // TODO: Use Json object

        /// <summary>The Trakt "Retry-After" header.</summary>
        public uint? RetryAfter { get; internal set; }

        /// <summary>The Trakt "X-Upgrade-URL" header.</summary>
        public string? UpgradeURL { get; internal set; }

        /// <summary>The Trakt "X-VIP-User" header.</summary>
        public bool? IsVIPUser { get; internal set; }

        /// <summary>The Trakt "X-Account-Limit" header.</summary>
        public uint? AccountLimit { get; internal set; }

        /// <summary>The Trakt "X-Account-Locked" header.</summary>
        public bool? IsAccountLocked { get; internal set; }

        /// <summary>The Trakt "X-Account-Deactivated" header.</summary>
        public bool? IsAccountDeactivated { get; internal set; }
    }
}
