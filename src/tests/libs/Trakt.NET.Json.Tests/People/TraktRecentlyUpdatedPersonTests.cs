using static TraktNET.TestConstants;

namespace TraktNET.Json.People
{
    public sealed class TraktRecentlyUpdatedPersonTests
    {
        [Fact]
        public void TestTraktRecentlyUpdatedPersonDefaultConstructor()
        {
            var recentlyUpdatedPerson = new TraktRecentlyUpdatedPerson();

            recentlyUpdatedPerson.RecentlyUpdatedAt.ShouldBeNull();
            recentlyUpdatedPerson.Person.ShouldBeNull();
            recentlyUpdatedPerson.Name.ShouldBeNull();
            recentlyUpdatedPerson.IDs.ShouldBeNull();
            recentlyUpdatedPerson.Biography.ShouldBeNull();
            recentlyUpdatedPerson.Birthday.ShouldBeNull();
            recentlyUpdatedPerson.Death.ShouldBeNull();
            recentlyUpdatedPerson.Age.ShouldBe(0);
            recentlyUpdatedPerson.Birthplace.ShouldBeNull();
            recentlyUpdatedPerson.Homepage.ShouldBeNull();
            recentlyUpdatedPerson.Gender.ShouldBeNull();
            recentlyUpdatedPerson.KnownForDepartment.ShouldBeNull();
            recentlyUpdatedPerson.SocialIds.ShouldBeNull();
            recentlyUpdatedPerson.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRecentlyUpdatedPersonFromJson()
        {
            var recentlyUpdatedPerson = await TestUtility.DeserializeJsonAsync<TraktRecentlyUpdatedPerson>("People\\personrecentlyupdated.json");

            recentlyUpdatedPerson.ShouldNotBeNull();
            recentlyUpdatedPerson.RecentlyUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-11-03T18:58:09.000Z"));
            recentlyUpdatedPerson.Person.ShouldNotBeNull();
            recentlyUpdatedPerson.Person.Name.ShouldBe("Bryan Cranston");
            recentlyUpdatedPerson.Person.IDs.ShouldNotBeNull();
            recentlyUpdatedPerson.Person.IDs.Trakt.ShouldBe(297737U);
            recentlyUpdatedPerson.Person.IDs.Slug.ShouldBe("bryan-cranston");
            recentlyUpdatedPerson.Person.IDs.IMDB.ShouldBe("nm0186505");
            recentlyUpdatedPerson.Person.IDs.TMDB.ShouldBe(17419U);
            recentlyUpdatedPerson.Person.Biography.ShouldBe("Bryan Lee Cranston(born March 7, 1956)...");
#if NET7_0_OR_GREATER
            recentlyUpdatedPerson.Person.Birthday.ShouldBe(TestUtility.ParseDate("1956-03-07"));
            recentlyUpdatedPerson.Person.Death.ShouldBe(TestUtility.ParseDate("2016-04-06"));
#else
            recentlyUpdatedPerson.Person.Birthday.ShouldBe(TestUtility.ParseUTCDateTime("1956-03-07T00:00:00Z"));
            recentlyUpdatedPerson.Person.Death.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T00:00:00Z"));
#endif
            recentlyUpdatedPerson.Person.Age.ShouldBe(60);
            recentlyUpdatedPerson.Person.Birthplace.ShouldBe("San Fernando Valley, California, USA");
            recentlyUpdatedPerson.Person.Homepage.ShouldBe("http://www.bryancranston.com/");
            recentlyUpdatedPerson.Person.Gender.ShouldBe(TraktGender.Male);
            recentlyUpdatedPerson.Person.KnownForDepartment.ShouldBe(TraktKnownForDepartment.Acting);
            recentlyUpdatedPerson.Person.SocialIDs.ShouldNotBeNull();
            recentlyUpdatedPerson.Person.SocialIDs.Twitter.ShouldBe("BryanCranston");
            recentlyUpdatedPerson.Person.SocialIDs.Facebook.ShouldBe("thebryancranston");
            recentlyUpdatedPerson.Person.SocialIDs.Instagram.ShouldBe("bryancranston");
            recentlyUpdatedPerson.Person.SocialIDs.Wikipedia.ShouldBe("Bryan_Cranston");
            recentlyUpdatedPerson.Person.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-11-03T18:58:09.000Z"));

            recentlyUpdatedPerson.Name.ShouldBe("Bryan Cranston");
            recentlyUpdatedPerson.IDs.ShouldNotBeNull();
            recentlyUpdatedPerson.IDs.Trakt.ShouldBe(297737U);
            recentlyUpdatedPerson.IDs.Slug.ShouldBe("bryan-cranston");
            recentlyUpdatedPerson.IDs.IMDB.ShouldBe("nm0186505");
            recentlyUpdatedPerson.IDs.TMDB.ShouldBe(17419U);
            recentlyUpdatedPerson.Biography.ShouldBe("Bryan Lee Cranston(born March 7, 1956)...");
#if NET7_0_OR_GREATER
            recentlyUpdatedPerson.Birthday.ShouldBe(TestUtility.ParseDate("1956-03-07"));
            recentlyUpdatedPerson.Death.ShouldBe(TestUtility.ParseDate("2016-04-06"));
#else
            recentlyUpdatedPerson.Birthday.ShouldBe(TestUtility.ParseUTCDateTime("1956-03-07T00:00:00Z"));
            recentlyUpdatedPerson.Death.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T00:00:00Z"));
#endif
            recentlyUpdatedPerson.Age.ShouldBe(60);
            recentlyUpdatedPerson.Birthplace.ShouldBe("San Fernando Valley, California, USA");
            recentlyUpdatedPerson.Homepage.ShouldBe("http://www.bryancranston.com/");
            recentlyUpdatedPerson.Gender.ShouldBe(TraktGender.Male);
            recentlyUpdatedPerson.KnownForDepartment.ShouldBe(TraktKnownForDepartment.Acting);
            recentlyUpdatedPerson.SocialIds.ShouldNotBeNull();
            recentlyUpdatedPerson.SocialIds.Twitter.ShouldBe("BryanCranston");
            recentlyUpdatedPerson.SocialIds.Facebook.ShouldBe("thebryancranston");
            recentlyUpdatedPerson.SocialIds.Instagram.ShouldBe("bryancranston");
            recentlyUpdatedPerson.SocialIds.Wikipedia.ShouldBe("Bryan_Cranston");
            recentlyUpdatedPerson.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-11-03T18:58:09.000Z"));
        }
    }
}
