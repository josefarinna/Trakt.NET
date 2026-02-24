namespace TraktNET.Json.Shows
{
    public sealed class TraktShowCertificationTests
    {
        [Fact]
        public void TestTraktShowCertificationConstructor()
        {
            var showCertification = new TraktShowCertification();

            showCertification.Certification.ShouldBeNull();
            showCertification.Country.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowCertificationFromJson()
        {
            TraktShowCertification? showCertification = await TestUtility.DeserializeJsonAsync<TraktShowCertification>("Shows\\showcertification.json");

            showCertification.ShouldNotBeNull();
            showCertification!.Certification.ShouldBe("18");
            showCertification!.Country.ShouldBe("es");
        }

        [Fact]
        public async Task TestTraktShowCertificationsFromJson()
        {
            IReadOnlyList<TraktShowCertification>? showCertifications = await TestUtility.DeserializeJsonListAsync<TraktShowCertification>("Shows\\showcertifications.json");

            showCertifications.ShouldNotBeNull();
            showCertifications!.Count.ShouldBe(31);

            TraktShowCertification certification = showCertifications![0];
            certification.ShouldNotBeNull();
            certification.Certification.ShouldBe("16");
            certification.Country.ShouldBe("at");

            certification = showCertifications![9];
            certification.ShouldNotBeNull();
            certification.Certification.ShouldBe("18");
            certification.Country.ShouldBe("es");

            certification = showCertifications![30];
            certification.ShouldNotBeNull();
            certification.Certification.ShouldBe("TV-MA");
            certification.Country.ShouldBe("us");
        }
    }
}
