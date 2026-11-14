namespace TraktNET.Json.Awards
{
    public sealed class TraktPersonAwardTests
    {
        [Fact]
        public void TestTraktPersonAwardConstructor()
        {
            var award = new TraktPersonAward();

            award.Award.ShouldBeNull();
            award.Ceremony.ShouldBeNull();
            award.Year.ShouldBeNull();
            award.Won.ShouldBeNull();
            award.Movie.ShouldBeNull();
            award.Show.ShouldBeNull();
            award.Type.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonAwardFromJson()
        {
            TraktPersonAward? personAward = await TestUtility.DeserializeJsonAsync<TraktPersonAward>("Awards\\person_award.json");

            personAward.ShouldNotBeNull();
            personAward.Year.ShouldBe(2024U);
            personAward.Won.ShouldBe(true);
            personAward.Type.ShouldBe(TraktListItemType.Movie);

            personAward.Award.ShouldNotBeNull();
            personAward.Award.Slug.ShouldBe("best-performance-by-an-actor-in-a-leading-role");
            personAward.Award.Name.ShouldBe("Best Performance by an Actor in a Leading Role");

            personAward.Ceremony.ShouldNotBeNull();
            personAward.Ceremony.Slug.ShouldBe("oscars");
            personAward.Ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            personAward.Ceremony.Edition.ShouldBe(96U);

#if NET7_0_OR_GREATER
            personAward.Ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2024-01-23"));
            personAward.Ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2024-03-10"));
#else
            personAward.Ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-01-23T00:00:00.000Z"));
            personAward.Ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-10T00:00:00.000Z"));
#endif

            personAward.Movie.ShouldNotBeNull();
            personAward.Movie.Title.ShouldBe("Oppenheimer");
            personAward.Movie.Year.ShouldBe(2023U);
            personAward.Movie.IDs.ShouldNotBeNull();
            personAward.Movie.IDs.Trakt.ShouldBe(1U);
            personAward.Movie.IDs.Slug.ShouldBe("oppenheimer-2023");

            personAward.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonAwardsFromJson()
        {
            IReadOnlyList<TraktPersonAward>? personAwards = await TestUtility.DeserializeJsonListAsync<TraktPersonAward>("Awards\\person_awards.json");

            personAwards.ShouldNotBeNull();
            personAwards.Count.ShouldBe(2);

            TraktPersonAward award1 = personAwards[0];
            award1.Year.ShouldBe(2024U);
            award1.Won.ShouldBe(true);
            award1.Type.ShouldBe(TraktListItemType.Movie);
            award1.Movie.ShouldNotBeNull();
            award1.Movie.Title.ShouldBe("Oppenheimer");
            award1.Show.ShouldBeNull();

            TraktPersonAward award2 = personAwards[1];
            award2.Year.ShouldBe(2024U);
            award2.Won.ShouldBeNull();
            award2.Type.ShouldBe(TraktListItemType.Show);
            award2.Movie.ShouldBeNull();
            award2.Show.ShouldNotBeNull();
            award2.Show.Title.ShouldBe("Succession");
        }

        [Fact]
        public void TestTraktPersonAwardToJson()
        {
            var personAward = new TraktPersonAward
            {
                Award = new TraktAward
                {
                    Slug = "best-performance-by-an-actor-in-a-leading-role",
                    Name = "Best Performance by an Actor in a Leading Role"
                },
                Ceremony = new TraktAwardCeremony
                {
                    Slug = "oscars",
                    Name = "Academy Awards (Oscars)",
                    Edition = 96U
                },
                Year = 2024U,
                Won = true,
                Type = TraktListItemType.Movie,
                Movie = new TraktMovie
                {
                    Title = "Oppenheimer",
                    Year = 2023U,
                    IDs = new TraktMovieIDs
                    {
                        Trakt = 1U,
                        Slug = "oppenheimer-2023"
                    }
                }
            };

            string json = TestUtility.SerializeObject(personAward);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"slug\":\"best-performance-by-an-actor-in-a-leading-role\"");
            json.ShouldContain("\"name\":\"Best Performance by an Actor in a Leading Role\"");
            json.ShouldContain("\"edition\":96");
            json.ShouldContain("\"year\":2024");
            json.ShouldContain("\"won\":true");
            json.ShouldContain("\"type\":\"movie\"");
            json.ShouldContain("\"title\":\"Oppenheimer\"");
        }
    }
}
