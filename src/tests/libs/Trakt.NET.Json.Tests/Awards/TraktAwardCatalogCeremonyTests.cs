namespace TraktNET.Json.Awards
{
    public sealed class TraktAwardCatalogCeremonyTests
    {
        [Fact]
        public void TestTraktAwardCatalogCeremonyConstructor()
        {
            var ceremony = new TraktAwardCatalogCeremony();

            ceremony.Slug.ShouldBeNull();
            ceremony.Name.ShouldBeNull();
            ceremony.MediaTypes.ShouldBeNull();
            ceremony.Awards.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktAwardCatalogCeremonyFromJson()
        {
            TraktAwardCatalogCeremony? ceremony = await TestUtility.DeserializeJsonAsync<TraktAwardCatalogCeremony>("Awards\\catalog_ceremony.json");

            ceremony.ShouldNotBeNull();
            ceremony.Slug.ShouldBe("golden-globes");
            ceremony.Name.ShouldBe("Golden Globe Awards");
            ceremony.MediaTypes.ShouldNotBeNull();
            ceremony.MediaTypes.Count.ShouldBe(2);
            ceremony.MediaTypes[0].ShouldBe(TraktAwardMediaType.Movie);
            ceremony.MediaTypes[1].ShouldBe(TraktAwardMediaType.Show);

            ceremony.Awards.ShouldNotBeNull();
            ceremony.Awards.Count.ShouldBe(2);

            TraktAwardCatalogAward award1 = ceremony.Awards[0];
            award1.Slug.ShouldBe("golden-globes-best-picture");
            award1.Name.ShouldBe("Best Picture");
            award1.Kind.ShouldBe(TraktAwardKind.Title);

            TraktAwardCatalogAward award2 = ceremony.Awards[1];
            award2.Slug.ShouldBe("golden-globes-best-actor-drama");
            award2.Name.ShouldBe("Best Actor");
            award2.Kind.ShouldBe(TraktAwardKind.Person);
        }

        [Fact]
        public void TestTraktAwardCatalogCeremonyToJson()
        {
            var ceremony = new TraktAwardCatalogCeremony
            {
                Slug = "golden-globes",
                Name = "Golden Globe Awards",
                MediaTypes = [TraktAwardMediaType.Movie, TraktAwardMediaType.Show],
                Awards =
                [
                    new TraktAwardCatalogAward
                    {
                        Slug = "golden-globes-best-picture",
                        Name = "Best Picture",
                        Kind = TraktAwardKind.Title
                    },
                    new TraktAwardCatalogAward
                    {
                        Slug = "golden-globes-best-actor-drama",
                        Name = "Best Actor",
                        Kind = TraktAwardKind.Person
                    }
                ]
            };

            string json = TestUtility.SerializeObject(ceremony);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"slug\":\"golden-globes\"");
            json.ShouldContain("\"name\":\"Golden Globe Awards\"");
            json.ShouldContain("\"media_types\":[\"movie\",\"show\"]");
            json.ShouldContain("\"awards\":[");
            json.ShouldContain("\"kind\":\"title\"");
            json.ShouldContain("\"kind\":\"person\"");
        }
    }
}
