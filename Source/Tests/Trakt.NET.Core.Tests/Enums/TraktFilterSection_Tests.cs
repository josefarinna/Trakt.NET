namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktFilterSection_Tests
    {
        [Fact]
        public void Test_TraktFilterSection_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktFilterSection>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktFilterSection>() { TraktFilterSection.Unspecified, TraktFilterSection.Movies,
                                                                        TraktFilterSection.Shows, TraktFilterSection.Calendars,
                                                                        TraktFilterSection.Search });
        }
    }
}
