namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktSyncItemType_Tests
    {
        [Fact]
        public void Test_TraktSyncItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncItemType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktSyncItemType>() { TraktSyncItemType.Unspecified, TraktSyncItemType.Movie,
                                                                       TraktSyncItemType.Show, TraktSyncItemType.Season,
                                                                       TraktSyncItemType.Episode });
        }
    }
}
