namespace TraktNET.Json.People
{
    public sealed class TraktPersonSocialIDsTests
    {
        [Fact]
        public void TestTraktPersonSocialIDsConstructor()
        {
            var personSocialIDs = new TraktPersonSocialIDs();

            personSocialIDs.Twitter.ShouldBeNull();
            personSocialIDs.Facebook.ShouldBeNull();
            personSocialIDs.Instagram.ShouldBeNull();
            personSocialIDs.TikTok.ShouldBeNull();
            personSocialIDs.YouTube.ShouldBeNull();
            personSocialIDs.Wikidata.ShouldBeNull();
            personSocialIDs.Wikipedia.ShouldBeNull();
            personSocialIDs.WikipediaLanguage.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonSocialIDsFromJson()
        {
            TraktPersonSocialIDs? personSocialIDs = await TestUtility.DeserializeJsonAsync<TraktPersonSocialIDs>("People\\personsocialids.json");

            personSocialIDs.ShouldNotBeNull();

            personSocialIDs!.Twitter.ShouldBe("BryanCranston");
            personSocialIDs!.Facebook.ShouldBe("thebryancranston");
            personSocialIDs!.Instagram.ShouldBe("bryancranston");
            personSocialIDs!.TikTok.ShouldBe("bryancranston");
            personSocialIDs!.YouTube.ShouldBe("UC0000000000000000000000");
            personSocialIDs!.Wikidata.ShouldBe("Q43416");
            personSocialIDs!.Wikipedia.ShouldBe("test-data");
            personSocialIDs!.WikipediaLanguage.ShouldBe("de");
        }

        [Fact]
        public void TestTraktPersonSocialIDsToJson()
        {
            var personSocialIDs = new TraktPersonSocialIDs
            {
                Twitter = "BryanCranston",
                Facebook = "thebryancranston",
                Instagram = "bryancranston",
                TikTok = "bryancranston",
                YouTube = "UC0000000000000000000000",
                Wikidata = "Q43416",
                Wikipedia = "test-data",
                WikipediaLanguage = "de"
            };

            string json = TestUtility.SerializeObject(personSocialIDs);
            json.ShouldContain("\"twitter\":\"BryanCranston\"");
            json.ShouldContain("\"facebook\":\"thebryancranston\"");
            json.ShouldContain("\"instagram\":\"bryancranston\"");
            json.ShouldContain("\"tiktok\":\"bryancranston\"");
            json.ShouldContain("\"youtube\":\"UC0000000000000000000000\"");
            json.ShouldContain("\"wikidata\":\"Q43416\"");
            json.ShouldContain("\"wikipedia\":\"test-data\"");
            json.ShouldContain("\"wikipedia_language\":\"de\"");
        }
    }
}
