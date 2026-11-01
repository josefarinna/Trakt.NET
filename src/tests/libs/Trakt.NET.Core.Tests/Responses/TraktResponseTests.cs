using System.Collections;
using System.Net;

namespace TraktNET.Responses
{
    public sealed class TraktResponseTests
    {
        private static readonly DateTime s_startDate = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime s_endDate = new(2026, 1, 31, 0, 0, 0, DateTimeKind.Utc);
        private static readonly TraktRateLimitInfo s_rateLimit = new() { Name = "UNAUTHED_API_GET_LIMIT", Period = 300, Limit = 1000, Remaining = 0 };

        [Fact]
        public void TestTraktResponseHeaderPropertiesWithoutHeaders()
        {
            var response = TraktResponse.Create(HttpStatusCode.OK, null, null);

            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.AppliedSortBy.ShouldBeNull();
            response.AppliedSortHow.ShouldBeNull();
            response.StartDate.ShouldBeNull();
            response.EndDate.ShouldBeNull();
            response.TrendingUserCount.ShouldBeNull();
            response.Page.ShouldBeNull();
            response.Limit.ShouldBeNull();
            response.IsPrivateUser.ShouldBeNull();
            response.ItemID.ShouldBeNull();
            response.ItemType.ShouldBeNull();
            response.RateLimit.ShouldBeNull();
            response.RetryAfter.ShouldBeNull();
            response.UpgradeURL.ShouldBeNull();
            response.IsVIPUser.ShouldBeNull();
            response.AccountLimit.ShouldBeNull();
            response.IsAccountLocked.ShouldBeNull();
            response.IsAccountDeactivated.ShouldBeNull();
        }

        [Fact]
        public void TestTraktResponseHeaderPropertiesWithHeaders()
        {
            var response = TraktResponse.Create(HttpStatusCode.OK, CreateHeaders(), null);

            response.SortBy.ShouldBe(TraktSortBy.Rank);
            response.SortHow.ShouldBe(TraktSortHow.Ascending);
            response.AppliedSortBy.ShouldBe(TraktSortBy.Added);
            response.AppliedSortHow.ShouldBe(TraktSortHow.Descending);
            response.StartDate.ShouldBe(s_startDate);
            response.EndDate.ShouldBe(s_endDate);
            response.TrendingUserCount.ShouldBe(42U);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.IsPrivateUser.ShouldBe(false);
            response.ItemID.ShouldBe(123U);
            response.ItemType.ShouldBe("movie");
            response.RateLimit.ShouldBe(s_rateLimit);
            response.RetryAfter.ShouldBe(30U);
            response.UpgradeURL.ShouldBe("https://trakt.tv/vip");
            response.IsVIPUser.ShouldBe(true);
            response.AccountLimit.ShouldBe(100U);
            response.IsAccountLocked.ShouldBe(false);
            response.IsAccountDeactivated.ShouldBe(false);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, true)]
        [InlineData(HttpStatusCode.NoContent, true)]
        [InlineData(HttpStatusCode.NotFound, false)]
        public void TestTraktResponseImplicitBoolConversion(HttpStatusCode statusCode, bool expected)
        {
            bool result = TraktResponse.Create(statusCode, null, null);
            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, "content", true)]
        [InlineData(HttpStatusCode.OK, null, false)]
        [InlineData(HttpStatusCode.NotFound, "content", false)]
        public void TestTraktResponseWithContentImplicitBoolConversion(HttpStatusCode statusCode, string? content, bool expected)
        {
            bool result = TraktResponse<string>.Create(statusCode, content, null, null, null);
            result.ShouldBe(expected);
        }

        [Fact]
        public void TestTraktListResponseWithContent()
        {
            var response = TraktListResponse<string>.Create(HttpStatusCode.OK, ["first", "second"], null, null, null);

            response.Count.ShouldBe(2);
            response[0].ShouldBe("first");
            response[1].ShouldBe("second");

            var items = new List<string>();

            foreach (string item in response)
                items.Add(item);

            items.ShouldBe(["first", "second"]);

            IEnumerator enumerator = ((IEnumerable)response).GetEnumerator();
            enumerator.MoveNext().ShouldBeTrue();
            enumerator.Current.ShouldBe("first");

            bool result = response;
            result.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktListResponseWithoutContent()
        {
            var response = TraktListResponse<string>.Create(HttpStatusCode.OK, null, null, null, null);

            response.Count.ShouldBe(0);
            Should.Throw<InvalidOperationException>(() => response[0]);
            Should.Throw<InvalidOperationException>(() => response.GetEnumerator());

            bool result = response;
            result.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktPagedResponseHeaderProperties()
        {
            TraktPagedResponse<string> response = CreatePagedResponse(page: 2, pageCount: 3);

            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(30U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();

            bool result = response;
            result.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktPagedResponseWithoutContentImplicitBoolConversion()
        {
            var response = TraktPagedResponse<string>.Create(HttpStatusCode.OK, null, null, null, null);

            bool result = response;
            result.ShouldBeFalse();
        }

        [Fact]
        public async Task TestTraktPagedResponseReturnsItselfIfThereIsNoOtherPage()
        {
            TraktPagedResponse<string> response = CreatePagedResponse(page: 1, pageCount: 1);

            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();

            (await response.GetPreviousPageAsync(TestContext.Current.CancellationToken)).ShouldBeSameAs(response);
            (await response.GetNextPageAsync(TestContext.Current.CancellationToken)).ShouldBeSameAs(response);
        }

        [Fact]
        public async Task TestTraktPagedResponseThrowsWithoutRequestContext()
        {
            TraktPagedResponse<string> response = CreatePagedResponse(page: 2, pageCount: 3);

            await Should.ThrowAsync<InvalidOperationException>(() => response.GetPreviousPageAsync(TestContext.Current.CancellationToken));
            await Should.ThrowAsync<InvalidOperationException>(() => response.GetNextPageAsync(TestContext.Current.CancellationToken));
        }

        private static TraktPagedResponse<string> CreatePagedResponse(uint page, uint pageCount)
        {
            var headers = new TraktResponseHeaders
            {
                Page = page,
                PageCount = pageCount,
                Limit = 10,
                ItemCount = 30
            };

            return TraktPagedResponse<string>.Create(HttpStatusCode.OK, ["item"], headers, null, null);
        }

        private static TraktResponseHeaders CreateHeaders()
            => new()
            {
                SortBy = TraktSortBy.Rank,
                SortHow = TraktSortHow.Ascending,
                AppliedSortBy = TraktSortBy.Added,
                AppliedSortHow = TraktSortHow.Descending,
                StartDate = s_startDate,
                EndDate = s_endDate,
                TrendingUserCount = 42,
                Page = 2,
                Limit = 10,
                IsPrivateUser = false,
                ItemID = 123,
                ItemType = "movie",
                RateLimit = s_rateLimit,
                RetryAfter = 30,
                UpgradeURL = "https://trakt.tv/vip",
                IsVIPUser = true,
                AccountLimit = 100,
                IsAccountLocked = false,
                IsAccountDeactivated = false
            };
    }
}
