using System.Globalization;

namespace TraktNET.Json.People
{
    public sealed class TraktPersonTests
    {
        [Fact]
        public void TestTraktPersonConstructor()
        {
            var person = new TraktPerson();

            person.Name.ShouldBeNull();
            person.IDs.ShouldBeNull();
            person.SocialIDs.ShouldBeNull();
            person.Biography.ShouldBeNull();
            person.Birthday.ShouldBeNull();
            person.Death.ShouldBeNull();
            person.Age.ShouldBe(0);
            person.Birthplace.ShouldBeNull();
            person.Homepage.ShouldBeNull();
            person.KnownForDepartment.ShouldBeNull();
            person.Gender.ShouldBeNull();
            person.UpdatedAt.ShouldBeNull();
        }

        [Theory]
        [InlineData("1956-03-07", "2016-04-06", 60)]
        [InlineData("1956-03-07", "2016-03-07", 60)]
        [InlineData("1956-03-07", "2016-03-06", 59)]
        public void TestTraktPersonAgeWithDeath(string birthday, string death, int expectedAge)
        {
            var person = new TraktPerson
            {
                Birthday = ParseDate(birthday),
                Death = ParseDate(death)
            };

            person.Age.ShouldBe(expectedAge);
        }

        [Fact]
        public void TestTraktPersonAgeWithoutDeath()
        {
            DateTime today = DateTime.Today;
            var person = new TraktPerson { Birthday = ParseDate(today.AddYears(-30).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)) };
            person.Age.ShouldBe(30);

            person.Birthday = ParseDate(today.AddYears(-30).AddDays(1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            person.Age.ShouldBe(29);
        }

#if NET7_0_OR_GREATER
        private static DateOnly ParseDate(string date) => TestUtility.ParseDate(date);
#else
        private static DateTime ParseDate(string date) => DateTime.Parse(date, CultureInfo.InvariantCulture);
#endif

        [Fact]
        public async Task TestTraktPersonFromJsonMinimal()
        {
            TraktPersonMinimal? person = await TestUtility.DeserializeJsonAsync<TraktPersonMinimal>("People\\person_minimal.json");

            person.ShouldNotBeNull();

            person!.Name.ShouldBe("Bryan Cranston");

            person!.IDs.ShouldNotBeNull();
            person!.IDs!.Trakt.ShouldBe(297737U);
            person!.IDs!.Slug.ShouldBe("bryan-cranston");
            person!.IDs!.IMDB.ShouldBe("nm0186505");
            person!.IDs!.TMDB.ShouldBe(17419U);
            person!.IDs!.HasAnyID.ShouldBe(true);
            person!.IDs!.BestID.ShouldBe("bryan-cranston");
        }

        [Fact]
        public async Task TestTraktPersonFromJsonMinimalWithImages()
        {
            TraktPersonMinimal? person = await TestUtility.DeserializeJsonAsync<TraktPersonMinimal>("People\\person_minimal_images.json");

            person.ShouldNotBeNull();

            person!.Name.ShouldBe("Bryan Cranston");

            person!.IDs.ShouldNotBeNull();
            person!.IDs!.Trakt.ShouldBe(297737U);
            person!.IDs!.Slug.ShouldBe("bryan-cranston");
            person!.IDs!.IMDB.ShouldBe("nm0186505");
            person!.IDs!.TMDB.ShouldBe(17419U);
            person!.IDs!.HasAnyID.ShouldBe(true);
            person!.IDs!.BestID.ShouldBe("bryan-cranston");

            person!.Images.ShouldNotBeNull();

            person!.Images!.Headshot.ShouldNotBeNull();
            person!.Images!.Headshot!.Count.ShouldBe(1);
            person!.Images!.Headshot!.ShouldBe(["walter-r2.trakt.tv/images/people/000/297/737/headshots/thumb/ef96a1e565.jpg.webp"]);

            person!.Images!.Fanart.ShouldNotBeNull();
            person!.Images!.Fanart!.Count.ShouldBe(1);
            person!.Images!.Fanart!.ShouldBe(["walter-r2.trakt.tv/images/people/000/297/737/fanarts/medium/ec609f5bcc.jpg.webp"]);
        }

        [Fact]
        public async Task TestTraktPersonFromJsonFull()
        {
            TraktPerson? person = await TestUtility.DeserializeJsonAsync<TraktPerson>("People\\person_full.json");

            person.ShouldNotBeNull();

            person!.Name.ShouldBe("Bryan Cranston");

            person!.IDs.ShouldNotBeNull();
            person!.IDs!.Trakt.ShouldBe(297737U);
            person!.IDs!.Slug.ShouldBe("bryan-cranston");
            person!.IDs!.IMDB.ShouldBe("nm0186505");
            person!.IDs!.TMDB.ShouldBe(17419U);
            person!.IDs!.HasAnyID.ShouldBe(true);
            person!.IDs!.BestID.ShouldBe("bryan-cranston");

            person!.SocialIDs.ShouldNotBeNull();
            person!.SocialIDs!.Twitter.ShouldBe("BryanCranston");
            person!.SocialIDs!.Facebook.ShouldBe("thebryancranston");
            person!.SocialIDs!.Instagram.ShouldBe("bryancranston");
            person!.SocialIDs!.Wikipedia.ShouldBeNull();

            person!.Biography.ShouldBe("Bryan Lee Cranston (born March 7, 1956) is an American actor, director, and producer who "
                + "is mainly known for portraying Walter White in the AMC crime drama series Breaking Bad (2008–2013) and Hal in "
                + "the Fox sitcom Malcolm in the Middle (2000–2006).");

#if NET7_0_OR_GREATER
            person!.Birthday.ShouldBe(TestUtility.ParseDate("1956-03-07"));
#else

            person!.Birthday.ShouldBe(TestUtility.ParseUTCDateTime("1956-03-07T00:00:00.000Z"));
#endif
            person!.Death.ShouldBeNull();
            person!.Birthplace.ShouldBe("Hollywood, Los Angeles, California, USA");
            person!.Homepage.ShouldBe("http://www.bryancranston.com/");
            person!.KnownForDepartment.ShouldBe(TraktKnownForDepartment.Acting);
            person!.Gender.ShouldBe(TraktGender.Male);
            person!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-22T08:01:24.000Z"));
        }

        [Fact]
        public async Task TestTraktPersonFromJsonFullWithImages()
        {
            TraktPerson? person = await TestUtility.DeserializeJsonAsync<TraktPerson>("People\\person_full_images.json");

            person.ShouldNotBeNull();

            person!.Name.ShouldBe("Bryan Cranston");

            person!.IDs.ShouldNotBeNull();
            person!.IDs!.Trakt.ShouldBe(297737U);
            person!.IDs!.Slug.ShouldBe("bryan-cranston");
            person!.IDs!.IMDB.ShouldBe("nm0186505");
            person!.IDs!.TMDB.ShouldBe(17419U);
            person!.IDs!.HasAnyID.ShouldBe(true);
            person!.IDs!.BestID.ShouldBe("bryan-cranston");

            person!.SocialIDs.ShouldNotBeNull();
            person!.SocialIDs!.Twitter.ShouldBe("BryanCranston");
            person!.SocialIDs!.Facebook.ShouldBe("thebryancranston");
            person!.SocialIDs!.Instagram.ShouldBe("bryancranston");
            person!.SocialIDs!.Wikipedia.ShouldBeNull();

            person!.Biography.ShouldBe("Bryan Lee Cranston (born March 7, 1956) is an American actor, director, and producer who "
                + "is mainly known for portraying Walter White in the AMC crime drama series Breaking Bad (2008–2013) and Hal in "
                + "the Fox sitcom Malcolm in the Middle (2000–2006).");

#if NET7_0_OR_GREATER
            person!.Birthday.ShouldBe(TestUtility.ParseDate("1956-03-07"));
#else

            person!.Birthday.ShouldBe(TestUtility.ParseUTCDateTime("1956-03-07T00:00:00.000Z"));
#endif
            person!.Death.ShouldBeNull();
            person!.Birthplace.ShouldBe("Hollywood, Los Angeles, California, USA");
            person!.Homepage.ShouldBeNull();
            person!.KnownForDepartment.ShouldBe(TraktKnownForDepartment.Acting);
            person!.Gender.ShouldBe(TraktGender.Male);
            person!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-22T08:01:24.000Z"));

            person!.Images.ShouldNotBeNull();

            person!.Images!.Headshot.ShouldNotBeNull();
            person!.Images!.Headshot!.Count.ShouldBe(1);
            person!.Images!.Headshot!.ShouldBe(["walter-r2.trakt.tv/images/people/000/297/737/headshots/thumb/ef96a1e565.jpg.webp"]);

            person!.Images!.Fanart.ShouldNotBeNull();
            person!.Images!.Fanart!.Count.ShouldBe(1);
            person!.Images!.Fanart!.ShouldBe(["walter-r2.trakt.tv/images/people/000/297/737/fanarts/medium/ec609f5bcc.jpg.webp"]);
        }
    }
}
