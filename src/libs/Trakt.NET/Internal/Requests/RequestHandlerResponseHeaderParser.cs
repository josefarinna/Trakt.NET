using System.Net.Http.Headers;

namespace TraktNET
{
    internal static partial class RequestHandler
    {
        private static TraktResponseHeaders ParseTraktResponseHeaders(HttpResponseHeaders responseHeaders)
        {
            var headers = new TraktResponseHeaders();

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_KEY, out IEnumerable<string>? values))
            {
                string pageValue = values.First();

                if (uint.TryParse(pageValue, out uint page))
                {
                    headers.Page = page;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_PAGINATION_LIMIT_KEY, out values))
            {
                string limitValue = values.First();

                if (uint.TryParse(limitValue, out uint limit))
                {
                    headers.Limit = limit;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_COUNT_KEY, out values))
            {
                string pageCountValue = values.First();

                if (uint.TryParse(pageCountValue, out uint pageCount))
                {
                    headers.PageCount = pageCount;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_PAGINATION_ITEM_COUNT_KEY, out values))
            {
                string itemCountValue = values.First();

                if (uint.TryParse(itemCountValue, out uint itemCount))
                {
                    headers.ItemCount = itemCount;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_TRENDING_USER_COUNT_KEY, out values))
            {
                string trendingUserCountValue = values.First();

                if (uint.TryParse(trendingUserCountValue, out uint trendingUserCount))
                {
                    headers.TrendingUserCount = trendingUserCount;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_SORT_BY_KEY, out values))
            {
                headers.SortBy = values.First().ToTraktSortBy();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_APPLIED_SORT_BY, out values))
            {
                headers.AppliedSortBy = values.First().ToTraktSortBy();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_SORT_HOW_KEY, out values))
            {
                headers.SortHow = values.First().ToTraktSortHow();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_APPLIED_SORT_HOW, out values))
            {
                headers.AppliedSortHow = values.First().ToTraktSortHow();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_STARTDATE_KEY, out values))
            {
                string startDateValue = values.First();

                if (DateTime.TryParse(startDateValue, out DateTime startDate))
                {
                    headers.StartDate = startDate.ToUniversalTime();
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_ENDDATE_KEY, out values))
            {
                string endDateValue = values.First();

                if (DateTime.TryParse(endDateValue, out DateTime endDate))
                {
                    headers.EndDate = endDate.ToUniversalTime();
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_PRIVATE_USER_KEY, out values))
            {
                string isPrivateUserValue = values.First();

                if (bool.TryParse(isPrivateUserValue, out bool isPrivateUser))
                {
                    headers.IsPrivateUser = isPrivateUser;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_ITEM_ID, out values))
            {
                string itemIdValue = values.First();

                if (uint.TryParse(itemIdValue, out uint itemId))
                {
                    headers.ItemID = itemId;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_ITEM_TYPE, out values))
            {
                headers.ItemType = values.First();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_RATE_LIMIT, out values))
            {
                headers.RateLimit = values.First();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_RETRY_AFTER, out values))
            {
                string retryAfterValue = values.First();

                if (uint.TryParse(retryAfterValue, out uint retryAfter))
                {
                    headers.RetryAfter = retryAfter;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_UPGRADE_URL, out values))
            {
                headers.UpgradeURL = values.First();
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_VIP_USER, out values))
            {
                string isVIPUserValue = values.First();

                if (bool.TryParse(isVIPUserValue, out bool isVIPUser))
                {
                    headers.IsVIPUser = isVIPUser;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_ACCOUNT_LIMIT, out values))
            {
                string accountLimitValue = values.First();

                if (uint.TryParse(accountLimitValue, out uint accountLimit))
                {
                    headers.AccountLimit = accountLimit;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_ACCOUNT_LOCKED, out values))
            {
                string isAccountLockedValue = values.First();

                if (bool.TryParse(isAccountLockedValue, out bool isAccountLocked))
                {
                    headers.IsAccountLocked = isAccountLocked;
                }
            }

            if (responseHeaders.TryGetValues(Constants.ResponseHeaders.HEADER_ACCOUNT_DEACTIVATED, out values))
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
