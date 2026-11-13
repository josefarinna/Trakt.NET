namespace TraktNET.Json.Awards
{
    public sealed class TraktAwardTests
    {
        [Fact]
        public void TestTraktAwardConstructor()
        {
            var award = new TraktAward();

            award.Slug.ShouldBeNull();
            award.Name.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktAwardFromJson()
        {
            TraktAward? award = await TestUtility.DeserializeJsonAsync<TraktAward>("Awards\\award.json");

            award.ShouldNotBeNull();
            award.Slug.ShouldBe("best-motion-picture-of-the-year");
            award.Name.ShouldBe("Best Motion Picture of the Year");
        }

        [Fact]
        public void TestTraktAwardToJson()
        {
            var award = new TraktAward
            {
                Slug = "best-motion-picture-of-the-year",
                Name = "Best Motion Picture of the Year"
            };

            string json = TestUtility.SerializeObject(award);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"slug\":\"best-motion-picture-of-the-year\"");
            json.ShouldContain("\"name\":\"Best Motion Picture of the Year\"");
        }
    }
}
