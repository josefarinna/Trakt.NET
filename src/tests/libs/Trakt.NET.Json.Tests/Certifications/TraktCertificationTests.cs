namespace TraktNET.Json.Certifications
{
    public sealed class TraktCertificationTests
    {
        [Fact]
        public void TestTraktCertificationConstructor()
        {
            var certification = new TraktCertification();

            certification.Name.Should().BeNull();
            certification.Slug.Should().BeNull();
            certification.Description.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCertificationFromJson()
        {
            TraktCertification? certification = await TestUtility.DeserializeJsonAsync<TraktCertification>("Certifications\\certification.json");

            certification.Should().NotBeNull();

            certification!.Name.Should().Be("G");
            certification!.Slug.Should().Be("g");
            certification!.Description.Should().Be("All Ages");
        }
    }
}
