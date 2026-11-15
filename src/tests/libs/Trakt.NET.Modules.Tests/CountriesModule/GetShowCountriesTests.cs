using System.Net;

namespace TraktNET.CountriesModule
{
    public sealed partial class GetShowCountriesTests
    {
        private const string ShowCountriesUri = "countries/shows";

        [Fact]
        public async Task TestGetShowCountries()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Countries\\countriesshows.json");

            TraktClient client = ModuleTestUtility.GetClient(ShowCountriesUri, responseContent);
            TraktListResponse<TraktCountry> response = await client.Countries.GetShowCountriesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(153);

            List<TraktCountry> countries = [.. response.Content];

            countries[0].Name.ShouldBe("Afghanistan");
            countries[0].Code.ShouldBe("af");

            countries[7].Name.ShouldBe("Australia");
            countries[7].Code.ShouldBe("au");

            countries[152].Name.ShouldBe("Zimbabwe");
            countries[152].Code.ShouldBe("zw");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetShowCountriesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(ShowCountriesUri, statusCode);

            Func<Task<TraktListResponse<TraktCountry>>> act = () => client.Countries.GetShowCountriesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
