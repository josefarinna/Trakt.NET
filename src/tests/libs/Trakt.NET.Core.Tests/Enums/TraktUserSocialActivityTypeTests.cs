using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktUserSocialActivityTypeTests
    {
        [Fact]
        public void TestTraktUserSocialActivityTypeToJson()
        {
            TraktUserSocialActivityType.Unspecified.ToJson().ShouldBeNull();
            TraktUserSocialActivityType.Friends.ToJson().ShouldBe("friends");
            TraktUserSocialActivityType.Followers.ToJson().ShouldBe("followers");
            TraktUserSocialActivityType.Following.ToJson().ShouldBe("following");
            ((TraktUserSocialActivityType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktUserSocialActivityTypeFromJson()
        {
            "unspecified".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Unspecified);
            "friends".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Friends);
            "followers".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Followers);
            "following".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Following);

            string? nullValue = null;
            nullValue.ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Unspecified);
            "invalid".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Unspecified);
            "".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Unspecified);
        }

        [Fact]
        public void TestTraktUserSocialActivityTypeDisplayName()
        {
            TraktUserSocialActivityType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserSocialActivityType.Friends.DisplayName().ShouldBe("Friends");
            TraktUserSocialActivityType.Followers.DisplayName().ShouldBe("Followers");
            TraktUserSocialActivityType.Following.DisplayName().ShouldBe("Following");
            ((TraktUserSocialActivityType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktUserSocialActivityTypeJsonConverter()
        {
            var converter = new TraktUserSocialActivityTypeJsonConverter();
            converter.CanConvert(typeof(TraktUserSocialActivityType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktUserSocialActivityType.Friends, options).ShouldBe("\"friends\"");
            JsonSerializer.Deserialize<TraktUserSocialActivityType>("\"friends\"", options).ShouldBe(TraktUserSocialActivityType.Friends);
            JsonSerializer.Deserialize<TraktUserSocialActivityType>("\"\"", options).ShouldBe(TraktUserSocialActivityType.Unspecified);
        }
    }
}
