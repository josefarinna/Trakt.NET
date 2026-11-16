using System.Net;

namespace TraktNET.NetworksModule
{
    public sealed partial class GetNetworksTests
    {
        private const string GetNetworksUri = "networks";

        [Fact]
        public async Task TestGetNetworks()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Networks\\networks.json");

            TraktClient client = ModuleTestUtility.GetClient(GetNetworksUri, responseContent);
            TraktListResponse<TraktNetwork> response = await client.Networks.GetNetworksAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            response.Content.Count.ShouldBe(5303);

            List<TraktNetwork> networks = [.. response.Content];

            networks[0].ShouldNotBeNull();
            networks[0].Name.ShouldBe("");
            networks[0].Country.ShouldBeNull();
            networks[0].IDs.ShouldNotBeNull();
            networks[0].IDs!.Trakt.ShouldBe(869U);
            networks[0].IDs!.TMDB.ShouldBe(1446U);

            networks[2].ShouldNotBeNull();
            networks[2].Name.ShouldBe(" 10 Play");
            networks[2].Country.ShouldBe("au");
            networks[2].IDs.ShouldNotBeNull();
            networks[2].IDs!.Trakt.ShouldBe(1287U);
            networks[2].IDs!.TMDB.ShouldBe(3466U);

            networks[5302].ShouldNotBeNull();
            networks[5302].Name.ShouldBe("필콘미디어");
            networks[5302].Country.ShouldBeNull();
            networks[5302].IDs.ShouldNotBeNull();
            networks[5302].IDs!.Trakt.ShouldBe(4325U);
            networks[5302].IDs!.TMDB.ShouldBe(5460U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetNetworksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetNetworksUri, statusCode);

            Func<Task<TraktListResponse<TraktNetwork>>> act = () => client.Networks.GetNetworksAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
