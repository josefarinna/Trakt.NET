namespace TraktNET.Json.Countries
{
    public sealed class TraktCountryTests
    {
        [Fact]
        public void TestTraktCountryDefaultConstructor()
        {
            var country = new TraktCountry();

            country.Name.ShouldBeNull();
            country.Code.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCountryFromJson()
        {
            TraktCountry? country = await TestUtility.DeserializeJsonAsync<TraktCountry>("Countries\\country.json");

            country.ShouldNotBeNull();
            country.Name.ShouldBe("Australia");
            country.Code.ShouldBe("au");
        }
    }
}
