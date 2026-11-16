using System.Net;

namespace TraktNET.AwardsModule
{
    public sealed class GetAwardCatalogTests
    {
        private const string GetAwardCatalogUri = "awards";

        [Fact]
        public async Task TestGetAwardCatalog()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\catalog.json");
            TraktClient client = ModuleTestUtility.GetClient(GetAwardCatalogUri, responseContent);

            TraktListResponse<TraktAwardCatalogCeremony> response = await client.Awards.GetAwardCatalogAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktAwardCatalogCeremony> ceremonies = response.Content;

            TraktAwardCatalogCeremony ceremony = ceremonies[0];
            ceremony.Slug.ShouldBe("golden-globes");
            ceremony.Name.ShouldBe("Golden Globe Awards");
            ceremony.MediaTypes.ShouldNotBeNull();
            ceremony.MediaTypes.Count.ShouldBe(2);
            ceremony.MediaTypes[0].ShouldBe(TraktAwardMediaType.Movie);
            ceremony.MediaTypes[1].ShouldBe(TraktAwardMediaType.Show);

            ceremony.Awards.ShouldNotBeNull();
            ceremony.Awards.Count.ShouldBe(2);

            TraktAwardCatalogAward award = ceremony.Awards[0];
            award.Slug.ShouldBe("golden-globes-best-picture");
            award.Name.ShouldBe("Best Picture");
            award.Kind.ShouldBe(TraktAwardKind.Title);

            award = ceremony.Awards[1];
            award.Slug.ShouldBe("golden-globes-best-actor-drama");
            award.Name.ShouldBe("Best Actor");
            award.Kind.ShouldBe(TraktAwardKind.Person);

            ceremony = ceremonies[1];
            ceremony.Slug.ShouldBe("oscars");
            ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            ceremony.MediaTypes.ShouldNotBeNull();
            ceremony.MediaTypes.Count.ShouldBe(1);
            ceremony.MediaTypes[0].ShouldBe(TraktAwardMediaType.Movie);

            ceremony.Awards.ShouldNotBeNull();
            ceremony.Awards.Count.ShouldBe(1);

            award = ceremony.Awards[0];
            award.Slug.ShouldBe("oscars-best-picture");
            award.Name.ShouldBe("Best Picture");
            award.Kind.ShouldBe(TraktAwardKind.Title);
        }

        [Fact]
        public async Task TestGetCatalog()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\catalog.json");
            TraktClient client = ModuleTestUtility.GetClient(GetAwardCatalogUri, responseContent);

            TraktListResponse<TraktAwardCatalogCeremony> response = await client.Awards.GetCatalogAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetAwardCatalogThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAwardCatalogUri, statusCode);

            Func<Task<TraktListResponse<TraktAwardCatalogCeremony>>> act = () => client.Awards.GetAwardCatalogAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
