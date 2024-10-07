namespace TraktNET.Json.Certifications
{
    public sealed class TraktCertificationsTests
    {
        [Fact]
        public void TestTraktCertificationsConstructor()
        {
            var certifications = new TraktCertifications();

            certifications.US.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCertificationsFromJson()
        {
            TraktCertifications? certifications = await TestUtility.DeserializeJsonAsync<TraktCertifications>("Certifications\\certifications.json");

            certifications.Should().NotBeNull();

            certifications!.US.Should().NotBeNull().And.HaveCount(2);

            TraktCertification certification = certifications!.US![0];

            certification.Should().NotBeNull();
            certification.Name.Should().Be("G");
            certification.Slug.Should().Be("g");
            certification.Description.Should().Be("All Ages");

            certification = certifications!.US![1];

            certification.Should().NotBeNull();
            certification.Name.Should().Be("PG");
            certification.Slug.Should().Be("pg");
            certification.Description.Should().Be("Parental Guidance Suggested");
        }
    }
}
