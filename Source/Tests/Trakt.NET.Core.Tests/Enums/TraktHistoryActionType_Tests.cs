namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktHistoryActionType_Tests
    {
        [Fact]
        public void Test_TraktHistoryActionType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHistoryActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHistoryActionType>() { TraktHistoryActionType.Unspecified, TraktHistoryActionType.Scrobble,
                                                                            TraktHistoryActionType.Checkin, TraktHistoryActionType.Watch });
        }
    }
}
