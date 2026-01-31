namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktGenreType_Tests
    {
        [Fact]
        public void Test_TraktGenreType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktGenreType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktGenreType>() { TraktGenreType.Unspecified, TraktGenreType.Shows,
                                                                    TraktGenreType.Movies });
        }
    }
}
