namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using Xunit;

    [Trait("Category", "Enums")]
    public class TraktAccessTokenGrantType_Tests
    {
        [Fact]
        public void Test_TraktAccessTokenGrantType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessTokenGrantType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktAccessTokenGrantType>() { TraktAccessTokenGrantType.Unspecified,
                                                                               TraktAccessTokenGrantType.AuthorizationCode,
                                                                               TraktAccessTokenGrantType.RefreshToken });
        }
    }
}
