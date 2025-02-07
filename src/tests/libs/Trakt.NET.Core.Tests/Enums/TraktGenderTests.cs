namespace TraktNET.Enums
{
    public sealed class TraktGenderTests
    {
        [Fact]
        public void TestTraktGenderToJson()
        {
            TraktGender.Unspecified.ToJson().ShouldBeNull();
            TraktGender.Male.ToJson().ShouldBe("male");
            TraktGender.Female.ToJson().ShouldBe("female");
            TraktGender.NonBinary.ToJson().ShouldBe("non_binary");
        }

        [Fact]
        public void TestTraktGenderFromJson()
        {
            "unspecified".ToTraktGender().ShouldBe(TraktGender.Unspecified);
            "male".ToTraktGender().ShouldBe(TraktGender.Male);
            "female".ToTraktGender().ShouldBe(TraktGender.Female);
            "non_binary".ToTraktGender().ShouldBe(TraktGender.NonBinary);

            string? nullValue = null;
            nullValue.ToTraktGender().ShouldBe(TraktGender.Unspecified);
        }

        [Fact]
        public void TestTraktGenderDisplayName()
        {
            TraktGender.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktGender.Male.DisplayName().ShouldBe("Male");
            TraktGender.Female.DisplayName().ShouldBe("Female");
            TraktGender.NonBinary.DisplayName().ShouldBe("Non Binary");
        }
    }
}
