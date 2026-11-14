namespace TraktNET.Json.Awards
{
    public sealed class TraktUpcomingCeremonyTests
    {
        [Fact]
        public void TestTraktUpcomingCeremonyConstructor()
        {
            var ceremony = new TraktUpcomingCeremony();

            ceremony.Slug.ShouldBeNull();
            ceremony.Name.ShouldBeNull();
            ceremony.Edition.ShouldBeNull();
            ceremony.Year.ShouldBeNull();
            ceremony.NominationsAt.ShouldBeNull();
            ceremony.HeldAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUpcomingCeremonyFromJson()
        {
            TraktUpcomingCeremony? ceremony = await TestUtility.DeserializeJsonAsync<TraktUpcomingCeremony>("Awards\\upcoming_ceremony.json");

            ceremony.ShouldNotBeNull();
            ceremony.Slug.ShouldBe("oscars");
            ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            ceremony.Edition.ShouldBe(97U);
            ceremony.Year.ShouldBe(2025U);

#if NET7_0_OR_GREATER
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2025-01-23"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-03-02"));
#else
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-23T00:00:00.000Z"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-03-02T00:00:00.000Z"));
#endif
        }

        [Fact]
        public async Task TestTraktUpcomingCeremoniesFromJson()
        {
            IReadOnlyList<TraktUpcomingCeremony>? ceremonies = await TestUtility.DeserializeJsonListAsync<TraktUpcomingCeremony>("Awards\\ceremonies.json");

            ceremonies.ShouldNotBeNull();
            ceremonies.Count.ShouldBe(2);

            TraktUpcomingCeremony ceremony = ceremonies[0];
            ceremony.Slug.ShouldBe("oscars");
            ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            ceremony.Edition.ShouldBe(97U);
            ceremony.Year.ShouldBe(2025U);

#if NET7_0_OR_GREATER
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2025-01-23"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-03-02"));
#else
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-23T00:00:00.000Z"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-03-02T00:00:00.000Z"));
#endif

            ceremony = ceremonies[1];
            ceremony.Slug.ShouldBe("golden-globes");
            ceremony.Name.ShouldBe("Golden Globes");
            ceremony.Edition.ShouldBe(82U);
            ceremony.Year.ShouldBe(2025U);

#if NET7_0_OR_GREATER
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2024-12-09"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-01-05"));
#else
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-12-09T00:00:00.000Z"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-05T00:00:00.000Z"));
#endif
        }

        [Fact]
        public void TestTraktUpcomingCeremonyToJson()
        {
            var ceremony = new TraktUpcomingCeremony
            {
                Slug = "oscars",
                Name = "Academy Awards (Oscars)",
                Edition = 97U,
                Year = 2025U,
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
            json.ShouldContain("\"year\":2025");
            json.ShouldContain("\"nominations_at\":\"2025-01-23");
            json.ShouldContain("\"held_at\":\"2025-03-02");
        }
    }
}
