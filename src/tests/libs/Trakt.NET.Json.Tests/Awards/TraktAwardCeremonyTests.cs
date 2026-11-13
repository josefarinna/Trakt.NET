namespace TraktNET.Json.Awards
{
    public sealed class TraktAwardCeremonyTests
    {
        [Fact]
        public void TestTraktAwardCeremonyConstructor()
        {
            var ceremony = new TraktAwardCeremony();

            ceremony.Slug.ShouldBeNull();
            ceremony.Name.ShouldBeNull();
            ceremony.Edition.ShouldBeNull();
            ceremony.NominationsAt.ShouldBeNull();
            ceremony.HeldAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktAwardCeremonyFromJson()
        {
            TraktAwardCeremony? ceremony = await TestUtility.DeserializeJsonAsync<TraktAwardCeremony>("Awards\\ceremony.json");

            ceremony.ShouldNotBeNull();
            ceremony.Slug.ShouldBe("oscars");
            ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            ceremony.Edition.ShouldBe(97U);

#if NET7_0_OR_GREATER
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2025-01-23"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-03-02"));
#else
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-23T00:00:00.000Z"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-03-02T00:00:00.000Z"));
#endif
        }

        [Fact]
        public void TestTraktAwardCeremonyToJson()
        {
            var ceremony = new TraktAwardCeremony
            {
                Slug = "oscars",
                Name = "Academy Awards (Oscars)",
                Edition = 97U,
#if NET7_0_OR_GREATER
                NominationsAt = TestUtility.ParseDate("2025-01-23"),
                HeldAt = TestUtility.ParseDate("2025-03-02")
#else
                NominationsAt = TestUtility.ParseUTCDateTime("2025-01-23T00:00:00.000Z"),
                HeldAt = TestUtility.ParseUTCDateTime("2025-03-02T00:00:00.000Z")
#endif
            };

            string json = TestUtility.SerializeObject(ceremony);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"slug\":\"oscars\"");
            json.ShouldContain("\"name\":\"Academy Awards (Oscars)\"");
            json.ShouldContain("\"edition\":97");
            json.ShouldContain("\"nominations_at\":\"2025-01-23");
            json.ShouldContain("\"held_at\":\"2025-03-02");
        }
    }
}
