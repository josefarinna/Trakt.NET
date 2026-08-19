using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktKnownForDepartmentTests
    {
        [Fact]
        public void TestTraktKnownForDepartmentToJson()
        {
            TraktKnownForDepartment.Unspecified.ToJson().ShouldBeNull();
            TraktKnownForDepartment.Acting.ToJson().ShouldBe("acting");
            TraktKnownForDepartment.Directing.ToJson().ShouldBe("directing");
            TraktKnownForDepartment.Writing.ToJson().ShouldBe("writing");
            TraktKnownForDepartment.Production.ToJson().ShouldBe("production");
            TraktKnownForDepartment.VisualEffects.ToJson().ShouldBe("visual effects");
            TraktKnownForDepartment.CostumeMakeup.ToJson().ShouldBe("costume & make-up");
            TraktKnownForDepartment.Camera.ToJson().ShouldBe("camera");
            TraktKnownForDepartment.Sound.ToJson().ShouldBe("sound");
            TraktKnownForDepartment.Editing.ToJson().ShouldBe("editing");
            TraktKnownForDepartment.Art.ToJson().ShouldBe("art");
            TraktKnownForDepartment.Lighting.ToJson().ShouldBe("lighting");
            TraktKnownForDepartment.Crew.ToJson().ShouldBe("crew");
            ((TraktKnownForDepartment)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktKnownForDepartmentFromJson()
        {
            "unspecified".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Unspecified);
            "acting".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Acting);
            "directing".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Directing);
            "writing".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Writing);
            "production".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Production);
            "visual effects".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.VisualEffects);
            "costume & make-up".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.CostumeMakeup);
            "camera".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Camera);
            "sound".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Sound);
            "editing".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Editing);
            "art".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Art);
            "lighting".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Lighting);
            "crew".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Crew);

            string? nullValue = null;
            nullValue.ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Unspecified);
            "invalid".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Unspecified);
            "".ToTraktKnownForDepartment().ShouldBe(TraktKnownForDepartment.Unspecified);
        }

        [Fact]
        public void TestTraktKnownForDepartmentDisplayName()
        {
            TraktKnownForDepartment.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktKnownForDepartment.Acting.DisplayName().ShouldBe("Acting");
            TraktKnownForDepartment.Directing.DisplayName().ShouldBe("Directing");
            TraktKnownForDepartment.Writing.DisplayName().ShouldBe("Writing");
            TraktKnownForDepartment.Production.DisplayName().ShouldBe("Production");
            TraktKnownForDepartment.VisualEffects.DisplayName().ShouldBe("Visual Effects");
            TraktKnownForDepartment.CostumeMakeup.DisplayName().ShouldBe("Costume & Make-Up");
            TraktKnownForDepartment.Camera.DisplayName().ShouldBe("Camera");
            TraktKnownForDepartment.Sound.DisplayName().ShouldBe("Sound");
            TraktKnownForDepartment.Editing.DisplayName().ShouldBe("Editing");
            TraktKnownForDepartment.Art.DisplayName().ShouldBe("Art");
            TraktKnownForDepartment.Lighting.DisplayName().ShouldBe("Lighting");
            TraktKnownForDepartment.Crew.DisplayName().ShouldBe("Crew");
            ((TraktKnownForDepartment)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktKnownForDepartmentJsonConverter()
        {
            var converter = new TraktKnownForDepartmentJsonConverter();
            converter.CanConvert(typeof(TraktKnownForDepartment)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktKnownForDepartment.Acting, options).ShouldBe("\"acting\"");
            JsonSerializer.Deserialize<TraktKnownForDepartment>("\"acting\"", options).ShouldBe(TraktKnownForDepartment.Acting);
            JsonSerializer.Deserialize<TraktKnownForDepartment>("\"\"", options).ShouldBe(TraktKnownForDepartment.Unspecified);
        }
    }
}
