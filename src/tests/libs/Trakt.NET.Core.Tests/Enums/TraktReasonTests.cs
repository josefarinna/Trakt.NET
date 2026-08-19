using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktReasonTests
    {
        [Fact]
        public void TestTraktReasonToJson()
        {
            TraktReason.Unspecified.ToJson().ShouldBeNull();
            TraktReason.Spam.ToJson().ShouldBe("spam");
            TraktReason.Adult.ToJson().ShouldBe("adult");
            TraktReason.Language.ToJson().ShouldBe("language");
            TraktReason.Other.ToJson().ShouldBe("other");
            TraktReason.Duplicate.ToJson().ShouldBe("duplicate");
            TraktReason.Remove.ToJson().ShouldBe("remove");
            TraktReason.DataRefresh.ToJson().ShouldBe("data_refresh");
            TraktReason.Metadata.ToJson().ShouldBe("metadata");
            TraktReason.Runtime.ToJson().ShouldBe("runtime");
            TraktReason.TMDB.ToJson().ShouldBe("tmdb");
            TraktReason.Spoilers.ToJson().ShouldBe("spoilers");
            TraktReason.Abusive.ToJson().ShouldBe("abusive");
            TraktReason.Bigotry.ToJson().ShouldBe("bigotry");
            TraktReason.Political.ToJson().ShouldBe("political");
            TraktReason.Offtopic.ToJson().ShouldBe("offtopic");
            TraktReason.Support.ToJson().ShouldBe("support");
            TraktReason.TooShort.ToJson().ShouldBe("too_short");
            ((TraktReason)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktReasonFromJson()
        {
            "unspecified".ToTraktReason().ShouldBe(TraktReason.Unspecified);
            "spam".ToTraktReason().ShouldBe(TraktReason.Spam);
            "adult".ToTraktReason().ShouldBe(TraktReason.Adult);
            "language".ToTraktReason().ShouldBe(TraktReason.Language);
            "other".ToTraktReason().ShouldBe(TraktReason.Other);
            "duplicate".ToTraktReason().ShouldBe(TraktReason.Duplicate);
            "remove".ToTraktReason().ShouldBe(TraktReason.Remove);
            "data_refresh".ToTraktReason().ShouldBe(TraktReason.DataRefresh);
            "metadata".ToTraktReason().ShouldBe(TraktReason.Metadata);
            "runtime".ToTraktReason().ShouldBe(TraktReason.Runtime);
            "tmdb".ToTraktReason().ShouldBe(TraktReason.TMDB);
            "spoilers".ToTraktReason().ShouldBe(TraktReason.Spoilers);
            "abusive".ToTraktReason().ShouldBe(TraktReason.Abusive);
            "bigotry".ToTraktReason().ShouldBe(TraktReason.Bigotry);
            "political".ToTraktReason().ShouldBe(TraktReason.Political);
            "offtopic".ToTraktReason().ShouldBe(TraktReason.Offtopic);
            "support".ToTraktReason().ShouldBe(TraktReason.Support);
            "too_short".ToTraktReason().ShouldBe(TraktReason.TooShort);

            string? nullValue = null;
            nullValue.ToTraktReason().ShouldBe(TraktReason.Unspecified);
            "invalid".ToTraktReason().ShouldBe(TraktReason.Unspecified);
            "".ToTraktReason().ShouldBe(TraktReason.Unspecified);
        }

        [Fact]
        public void TestTraktReasonDisplayName()
        {
            TraktReason.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktReason.Spam.DisplayName().ShouldBe("Spam");
            TraktReason.Adult.DisplayName().ShouldBe("Adult");
            TraktReason.Language.DisplayName().ShouldBe("Language");
            TraktReason.Other.DisplayName().ShouldBe("Other");
            TraktReason.Duplicate.DisplayName().ShouldBe("Duplicate");
            TraktReason.Remove.DisplayName().ShouldBe("Remove");
            TraktReason.DataRefresh.DisplayName().ShouldBe("Data Refresh");
            TraktReason.Metadata.DisplayName().ShouldBe("Metadata");
            TraktReason.Runtime.DisplayName().ShouldBe("Runtime");
            TraktReason.TMDB.DisplayName().ShouldBe("TMDB");
            TraktReason.Spoilers.DisplayName().ShouldBe("Spoilers");
            TraktReason.Abusive.DisplayName().ShouldBe("Abusive");
            TraktReason.Bigotry.DisplayName().ShouldBe("Bigotry");
            TraktReason.Political.DisplayName().ShouldBe("Political");
            TraktReason.Offtopic.DisplayName().ShouldBe("Offtopic");
            TraktReason.Support.DisplayName().ShouldBe("Support");
            TraktReason.TooShort.DisplayName().ShouldBe("Too Short");
            ((TraktReason)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktReasonJsonConverter()
        {
            var converter = new TraktReasonJsonConverter();
            converter.CanConvert(typeof(TraktReason)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktReason.Spam, options).ShouldBe("\"spam\"");
            JsonSerializer.Deserialize<TraktReason>("\"spam\"", options).ShouldBe(TraktReason.Spam);
            JsonSerializer.Deserialize<TraktReason>("\"\"", options).ShouldBe(TraktReason.Unspecified);
        }
    }
}
