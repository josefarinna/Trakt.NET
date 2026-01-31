namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktWatchlistSortOrder_Tests
    {
        [Fact]
        public void Test_TraktWatchlistSortOrder_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktWatchlistSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktWatchlistSortOrder>() { TraktWatchlistSortOrder.Unspecified, TraktWatchlistSortOrder.Rank,
                                                                             TraktWatchlistSortOrder.Added, TraktWatchlistSortOrder.Released,
                                                                             TraktWatchlistSortOrder.Title });
        }
    }
}
