namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktAccessTokenType_Tests
    {
        [Fact]
        public void Test_TraktAccessTokenType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessTokenType>();

            allValues.Should().NotBeNull().And.HaveCount(2);
            allValues.Should().Contain(new List<TraktAccessTokenType>() { TraktAccessTokenType.Unspecified, TraktAccessTokenType.Bearer });
        }
    }
}
