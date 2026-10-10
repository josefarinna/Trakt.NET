using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktPeopleRoleTests
    {
        [Fact]
        public void TestTraktPeopleRoleToJson()
        {
            TraktPeopleRole.Unspecified.ToJson().ShouldBeNull();
            TraktPeopleRole.Any.ToJson().ShouldBe("any");
            TraktPeopleRole.Cast.ToJson().ShouldBe("cast");
            TraktPeopleRole.Directing.ToJson().ShouldBe("directing");
            TraktPeopleRole.Writing.ToJson().ShouldBe("writing");
            TraktPeopleRole.Producing.ToJson().ShouldBe("producing");
            ((TraktPeopleRole)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktPeopleRoleFromJson()
        {
            "unspecified".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Unspecified);
            "any".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Any);
            "cast".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Cast);
            "directing".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Directing);
            "writing".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Writing);
            "producing".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Producing);

            string? nullValue = null;
            nullValue.ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Unspecified);
            "invalid".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Unspecified);
            "".ToTraktPeopleRole().ShouldBe(TraktPeopleRole.Unspecified);
        }

        [Fact]
        public void TestTraktPeopleRoleDisplayName()
        {
            TraktPeopleRole.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktPeopleRole.Any.DisplayName().ShouldBe("Any");
            TraktPeopleRole.Cast.DisplayName().ShouldBe("Cast");
            TraktPeopleRole.Directing.DisplayName().ShouldBe("Directing");
            TraktPeopleRole.Writing.DisplayName().ShouldBe("Writing");
            TraktPeopleRole.Producing.DisplayName().ShouldBe("Producing");
            ((TraktPeopleRole)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktPeopleRoleJsonConverter()
        {
            var converter = new TraktPeopleRoleJsonConverter();
            converter.CanConvert(typeof(TraktPeopleRole)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktPeopleRole.Cast, options).ShouldBe("\"cast\"");
            JsonSerializer.Deserialize<TraktPeopleRole>("\"cast\"", options).ShouldBe(TraktPeopleRole.Cast);
            JsonSerializer.Deserialize<TraktPeopleRole>("\"\"", options).ShouldBe(TraktPeopleRole.Unspecified);
        }
    }
}
