namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktMediaHDR_Tests
    {
        [Fact]
        public void Test_TraktMediaHDR_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaHDR>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktMediaHDR>() { TraktMediaHDR.Unspecified, TraktMediaHDR.DolbyVision,
                                                                   TraktMediaHDR.HDR_10, TraktMediaHDR.HDR_10_Plus,
                                                                   TraktMediaHDR.HLG });
        }
    }
}
