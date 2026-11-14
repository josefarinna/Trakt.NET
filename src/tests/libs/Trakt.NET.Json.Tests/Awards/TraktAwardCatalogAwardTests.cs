namespace TraktNET.Json.Awards
{
    public sealed class TraktAwardCatalogAwardTests
    {
        [Fact]
        public void TestTraktAwardCatalogAwardConstructor()
        {
            var award = new TraktAwardCatalogAward();

            award.Slug.ShouldBeNull();
            award.Name.ShouldBeNull();
            award.Kind.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktAwardCatalogAwardFromJson()
        {
            TraktAwardCatalogAward? award = await TestUtility.DeserializeJsonAsync<TraktAwardCatalogAward>("Awards\\catalog_award.json");

            award.ShouldNotBeNull();
            award.Slug.ShouldBe("golden-globes-best-picture");
            award.Name.ShouldBe("Best Picture");
            award.Kind.ShouldBe(TraktAwardKind.Title);
        }

        [Fact]
        public void TestTraktAwardCatalogAwardToJson()
        {
            var award = new TraktAwardCatalogAward
            {
                Slug = "golden-globes-best-picture",
                Name = "Best Picture",
                Kind = TraktAwardKind.Title
            };

            string json = TestUtility.SerializeObject(award);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"slug\":\"golden-globes-best-picture\"");
            json.ShouldContain("\"name\":\"Best Picture\"");
            json.ShouldContain("\"kind\":\"title\"");
        }
    }
}
