using System.Net.Http.Headers;

namespace TraktNET
{
    internal sealed partial class RequestHandler
    {
        private static TraktResponseHeaders ParseTraktResponseHeaders(HttpResponseHeaders responseHeaders)
        {
            const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
            const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
            const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
            const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
            const string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";
            const string HEADER_SORT_BY_KEY = "X-Sort-By";
            const string HEADER_SORT_HOW_KEY = "X-Sort-How";
            const string HEADER_APPLIED_SORT_BY = "X-Applied-Sort-By";
            const string HEADER_APPLIED_SORT_HOW = "X-Applied-Sort-How";
            const string HEADER_STARTDATE_KEY = "X-Start-Date";
            const string HEADER_ENDDATE_KEY = "X-End-Date";
            const string HEADER_PRIVATE_USER_KEY = "X-Private-User";
            const string HEADER_ITEM_ID = "X-Item-ID";
            const string HEADER_ITEM_TYPE = "X-Item-Type";
            const string HEADER_RATE_LIMIT = "X-RateLimit";
            const string HEADER_RETRY_AFTER = "Retry-After";
            const string HEADER_UPGRADE_URL = "X-Upgrade-URL";
            const string HEADER_VIP_USER = "X-VIP-User";
            const string HEADER_ACCOUNT_LIMIT = "X-Account-Limit";
            const string HEADER_ACCOUNT_LOCKED = "X-Account-Locked";
            const string HEADER_ACCOUNT_DEACTIVATED = "X-Account-Deactivated";

            var headers = new TraktResponseHeaders();

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_KEY, out IEnumerable<string>? values))
            {
                string pageValue = values.First();

                if (uint.TryParse(pageValue, out uint page))
                {
                    headers.Page = page;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_LIMIT_KEY, out values))
            {
                string limitValue = values.First();

                if (uint.TryParse(limitValue, out uint limit))
                {
                    headers.Limit = limit;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_COUNT_KEY, out values))
            {
                string pageCountValue = values.First();

                if (uint.TryParse(pageCountValue, out uint pageCount))
                {
                    headers.PageCount = pageCount;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_ITEM_COUNT_KEY, out values))
            {
                string itemCountValue = values.First();

                if (uint.TryParse(itemCountValue, out uint itemCount))
                {
                    headers.ItemCount = itemCount;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_TRENDING_USER_COUNT_KEY, out values))
            {
                string trendingUserCountValue = values.First();

                if (uint.TryParse(trendingUserCountValue, out uint trendingUserCount))
                {
                    headers.TrendingUserCount = trendingUserCount;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_SORT_BY_KEY, out values))
            {
                headers.SortBy = values.First().ToTraktSortBy();
            }

            if (responseHeaders.TryGetValues(HEADER_APPLIED_SORT_BY, out values))
            {
                headers.AppliedSortBy = values.First().ToTraktSortBy();
            }

            if (responseHeaders.TryGetValues(HEADER_SORT_HOW_KEY, out values))
            {
                headers.SortHow = values.First().ToTraktSortHow();
            }

            if (responseHeaders.TryGetValues(HEADER_APPLIED_SORT_HOW, out values))
            {
                headers.AppliedSortHow = values.First().ToTraktSortHow();
            }

            if (responseHeaders.TryGetValues(HEADER_STARTDATE_KEY, out values))
            {
                string startDateValue = values.First();

                if (DateTime.TryParse(startDateValue, out DateTime startDate))
                {
                    headers.StartDate = startDate.ToUniversalTime();
                }
            }

            if (responseHeaders.TryGetValues(HEADER_ENDDATE_KEY, out values))
            {
                string endDateValue = values.First();

                if (DateTime.TryParse(endDateValue, out DateTime endDate))
                {
                    headers.EndDate = endDate.ToUniversalTime();
                }
            }

            if (responseHeaders.TryGetValues(HEADER_PRIVATE_USER_KEY, out values))
            {
                string isPrivateUserValue = values.First();

                if (bool.TryParse(isPrivateUserValue, out bool isPrivateUser))
                {
                    headers.IsPrivateUser = isPrivateUser;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_ITEM_ID, out values))
            {
                string itemIdValue = values.First();

                if (uint.TryParse(itemIdValue, out uint itemId))
                {
                    headers.ItemID = itemId;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_ITEM_TYPE, out values))
            {
                headers.ItemType = values.First();
            }

            if (responseHeaders.TryGetValues(HEADER_RATE_LIMIT, out values))
            {
                headers.RateLimit = values.First();
            }

            if (responseHeaders.TryGetValues(HEADER_RETRY_AFTER, out values))
            {
                string retryAfterValue = values.First();

                if (uint.TryParse(retryAfterValue, out uint retryAfter))
                {
                    headers.RetryAfter = retryAfter;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_UPGRADE_URL, out values))
            {
                headers.UpgradeURL = values.First();
            }

            if (responseHeaders.TryGetValues(HEADER_VIP_USER, out values))
            {
                string isVIPUserValue = values.First();

                if (bool.TryParse(isVIPUserValue, out bool isVIPUser))
                {
                    headers.IsVIPUser = isVIPUser;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_ACCOUNT_LIMIT, out values))
            {
                string accountLimitValue = values.First();

                if (uint.TryParse(accountLimitValue, out uint accountLimit))
                {
                    headers.AccountLimit = accountLimit;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_ACCOUNT_LOCKED, out values))
            {
                string isAccountLockedValue = values.First();

                if (bool.TryParse(isAccountLockedValue, out bool isAccountLocked))
                {
                    headers.IsAccountLocked = isAccountLocked;
                }
            }

            if (responseHeaders.TryGetValues(HEADER_ACCOUNT_DEACTIVATED, out values))
            {
                string isAccountDeactivatedValue = values.First();

                if (bool.TryParse(isAccountDeactivatedValue, out bool isAccountDeactivated))
                {
                    headers.IsAccountDeactivated = isAccountDeactivated;
                }
            }

            return headers;
        }
    }
}
