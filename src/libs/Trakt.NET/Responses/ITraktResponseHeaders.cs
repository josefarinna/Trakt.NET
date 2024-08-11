namespace TraktNET
{
    /// <summary>A collection of Trakt headers.</summary>
    public interface ITraktResponseHeaders
    {
        /// <summary>The Trakt "X-Sort-By" header.</summary>
        TraktSortBy? SortBy { get; }

        /// <summary>The Trakt "X-Sort-How" header.</summary>
        TraktSortHow? SortHow { get; }

        /// <summary>The Trakt "X-Applied-Sort-By" header.</summary>
        TraktSortBy? AppliedSortBy { get; }

        /// <summary>The Trakt "X-Applied-Sort-How" header.</summary>
        TraktSortHow? AppliedSortHow { get; }

        /// <summary>The Trakt "X-Start-Date" header.</summary>
        DateTime? StartDate { get; }

        /// <summary>The Trakt "X-End-Date" header.</summary>
        DateTime? EndDate { get; }

        /// <summary>The Trakt "X-Trending-User-Count" header.</summary>
        uint? TrendingUserCount { get; }

        /// <summary>The Trakt "X-Pagination-Page" header.</summary>
        uint? Page { get; }

        /// <summary>The Trakt "X-Pagination-Limit" header.</summary>
        uint? Limit { get; }

        /// <summary>The Trakt "X-Private-User" header.</summary>
        bool? IsPrivateUser { get; }

        /// <summary>The Trakt "X-Item-ID" header.</summary>
        uint? ItemID { get; }

        /// <summary>The Trakt "X-Item-Type" header.</summary>
        string? ItemType { get; }

        /// <summary>The Trakt "X-RateLimit" header.</summary>
        string? RateLimit { get; } // TODO: Use Json object

        /// <summary>The Trakt "Retry-After" header.</summary>
        uint? RetryAfter { get; }

        /// <summary>The Trakt "X-Upgrade-URL" header.</summary>
        string? UpgradeURL { get; }

        /// <summary>The Trakt "X-VIP-User" header.</summary>
        bool? IsVIPUser { get; }

        /// <summary>The Trakt "X-Account-Limit" header.</summary>
        uint? AccountLimit { get; }

        /// <summary>The Trakt "X-Account-Locked" header.</summary>
        bool? IsAccountLocked { get; }

        /// <summary>The Trakt "X-Account-Deactivated" header.</summary>
        bool? IsAccountDeactivated { get; }
    }
}
