using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSmartListSourceTests
    {
        [Fact]
        public void TestTraktSmartListSourceToJson()
        {
            TraktSmartListSource.Unspecified.ToJson().ShouldBeNull();
            TraktSmartListSource.Trending.ToJson().ShouldBe("trending");
            TraktSmartListSource.Popular.ToJson().ShouldBe("popular");
            TraktSmartListSource.Anticipated.ToJson().ShouldBe("anticipated");
            TraktSmartListSource.Recommendations.ToJson().ShouldBe("recommendations");
            TraktSmartListSource.Discover.ToJson().ShouldBe("discover");
            ((TraktSmartListSource)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListSourceFromJson()
        {
            "unspecified".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Unspecified);
            "trending".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Trending);
            "popular".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Popular);
            "anticipated".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Anticipated);
            "recommendations".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Recommendations);
            "discover".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Discover);

            string? nullValue = null;
            nullValue.ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Unspecified);
            "invalid".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Unspecified);
            "".ToTraktSmartListSource().ShouldBe(TraktSmartListSource.Unspecified);
        }

        [Fact]
        public void TestTraktSmartListSourceDisplayName()
        {
            TraktSmartListSource.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSmartListSource.Trending.DisplayName().ShouldBe("Trending");
            TraktSmartListSource.Popular.DisplayName().ShouldBe("Popular");
            TraktSmartListSource.Anticipated.DisplayName().ShouldBe("Anticipated");
            TraktSmartListSource.Recommendations.DisplayName().ShouldBe("Recommendations");
            TraktSmartListSource.Discover.DisplayName().ShouldBe("Discover");
            ((TraktSmartListSource)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSmartListSourceJsonConverter()
        {
            var converter = new TraktSmartListSourceJsonConverter();
            converter.CanConvert(typeof(TraktSmartListSource)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSmartListSource.Trending, options).ShouldBe("\"trending\"");
            JsonSerializer.Deserialize<TraktSmartListSource>("\"trending\"", options).ShouldBe(TraktSmartListSource.Trending);
            JsonSerializer.Deserialize<TraktSmartListSource>("\"\"", options).ShouldBe(TraktSmartListSource.Unspecified);
        }
    }
}
