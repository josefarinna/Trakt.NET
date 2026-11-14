namespace TraktNET.Json.Awards
{
    public sealed class TraktTitleAwardTests
    {
        [Fact]
        public void TestTraktTitleAwardConstructor()
        {
            var award = new TraktTitleAward();

            award.Award.ShouldBeNull();
            award.Ceremony.ShouldBeNull();
            award.Year.ShouldBeNull();
            award.Won.ShouldBeNull();
            award.Person.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktTitleAwardMovieFromJson()
        {
            TraktTitleAward? titleAward = await TestUtility.DeserializeJsonAsync<TraktTitleAward>("Awards\\movie_award.json");

            titleAward.ShouldNotBeNull();
            titleAward.Year.ShouldBe(2025U);
            titleAward.Won.ShouldBe(true);

            titleAward.Award.ShouldNotBeNull();
            titleAward.Award.Slug.ShouldBe("best-motion-picture-of-the-year");
            titleAward.Award.Name.ShouldBe("Best Motion Picture of the Year");

            titleAward.Ceremony.ShouldNotBeNull();
            titleAward.Ceremony.Slug.ShouldBe("oscars");
            titleAward.Ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            titleAward.Ceremony.Edition.ShouldBe(97U);

#if NET7_0_OR_GREATER
            titleAward.Ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2025-01-23"));
            titleAward.Ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-03-02"));
#else
            titleAward.Ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-23T00:00:00.000Z"));
            titleAward.Ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-03-02T00:00:00.000Z"));
#endif

            titleAward.Person.ShouldNotBeNull();
            titleAward.Person.Name.ShouldBe("Christopher Nolan");
            titleAward.Person.IDs.ShouldNotBeNull();
            titleAward.Person.IDs.Trakt.ShouldBe(1U);
            titleAward.Person.IDs.Slug.ShouldBe("christopher-nolan");
        }

        [Fact]
        public async Task TestTraktTitleAwardMovieAwardsFromJson()
        {
            IReadOnlyList<TraktTitleAward>? titleAwards = await TestUtility.DeserializeJsonListAsync<TraktTitleAward>("Awards\\movie_awards.json");

            titleAwards.ShouldNotBeNull();
            titleAwards.Count.ShouldBe(2);

            TraktTitleAward award1 = titleAwards[0];
            award1.Year.ShouldBe(2025U);
            award1.Won.ShouldBe(true);
            award1.Award.ShouldNotBeNull();
            award1.Award.Slug.ShouldBe("best-motion-picture-of-the-year");
            award1.Person.ShouldNotBeNull();
            award1.Person.Name.ShouldBe("Christopher Nolan");

            TraktTitleAward award2 = titleAwards[1];
            award2.Year.ShouldBe(2025U);
            award2.Won.ShouldBe(false);
            award2.Award.ShouldNotBeNull();
            award2.Award.Slug.ShouldBe("best-achievement-in-directing");
            award2.Person.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktTitleAwardShowFromJson()
        {
            TraktTitleAward? titleAward = await TestUtility.DeserializeJsonAsync<TraktTitleAward>("Awards\\show_award.json");

            titleAward.ShouldNotBeNull();
            titleAward.Year.ShouldBe(2024U);
            titleAward.Won.ShouldBe(true);

            titleAward.Award.ShouldNotBeNull();
            titleAward.Award.Slug.ShouldBe("outstanding-drama-series");
            titleAward.Award.Name.ShouldBe("Outstanding Drama Series");

            titleAward.Ceremony.ShouldNotBeNull();
            titleAward.Ceremony.Slug.ShouldBe("emmys");
            titleAward.Ceremony.Name.ShouldBe("Primetime Emmy Awards");
            titleAward.Ceremony.Edition.ShouldBe(76U);

#if NET7_0_OR_GREATER
            titleAward.Ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2024-07-17"));
            titleAward.Ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2024-09-15"));
#else
            titleAward.Ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-17T00:00:00.000Z"));
            titleAward.Ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T00:00:00.000Z"));
#endif

            titleAward.Person.ShouldNotBeNull();
            titleAward.Person.Name.ShouldBe("Jesse Armstrong");
            titleAward.Person.IDs.ShouldNotBeNull();
            titleAward.Person.IDs.Trakt.ShouldBe(2U);
            titleAward.Person.IDs.Slug.ShouldBe("jesse-armstrong");
        }

        [Fact]
        public async Task TestTraktTitleAwardShowAwardsFromJson()
        {
            IReadOnlyList<TraktTitleAward>? titleAwards = await TestUtility.DeserializeJsonListAsync<TraktTitleAward>("Awards\\show_awards.json");

            titleAwards.ShouldNotBeNull();
            titleAwards.Count.ShouldBe(2);

            TraktTitleAward award1 = titleAwards[0];
            award1.Year.ShouldBe(2024U);
            award1.Won.ShouldBe(true);
            award1.Award.ShouldNotBeNull();
            award1.Award.Slug.ShouldBe("outstanding-drama-series");

            TraktTitleAward award2 = titleAwards[1];
            award2.Year.ShouldBe(2024U);
            award2.Won.ShouldBe(true);
            award2.Award.ShouldNotBeNull();
            award2.Award.Slug.ShouldBe("outstanding-lead-actor-in-a-drama-series");
            award2.Person.ShouldNotBeNull();
            award2.Person.Name.ShouldBe("Kieran Culkin");
        }

        [Fact]
        public void TestTraktTitleAwardToJson()
        {
            var titleAward = new TraktTitleAward
            {
                Award = new TraktAward
                {
                    Slug = "best-motion-picture-of-the-year",
                    Name = "Best Motion Picture of the Year"
                },
                Ceremony = new TraktAwardCeremony
                {
                    Slug = "oscars",
                    Name = "Academy Awards (Oscars)",
                    Edition = 97U
                },
                Year = 2025U,
                Won = true,
                Person = new TraktPerson
                {
                    Name = "Christopher Nolan",
                    IDs = new TraktPersonIDs
                    {
                        Trakt = 1U,
                        Slug = "christopher-nolan"
                    }
                }
            };

            string json = TestUtility.SerializeObject(titleAward);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"slug\":\"best-motion-picture-of-the-year\"");
            json.ShouldContain("\"name\":\"Best Motion Picture of the Year\"");
            json.ShouldContain("\"edition\":97");
            json.ShouldContain("\"year\":2025");
            json.ShouldContain("\"won\":true");
            json.ShouldContain("\"name\":\"Christopher Nolan\"");
            json.ShouldContain("\"trakt\":1");
        }
    }
}
