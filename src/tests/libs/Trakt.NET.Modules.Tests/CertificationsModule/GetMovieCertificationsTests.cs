using System.Net;

namespace TraktNET.CertificationsModule
{
    public sealed class GetMovieCertificationsTests
    {
        private const string GetMovieCertificationsUri = "certifications/movies";

        [Fact]
        public async Task TestGetMovieCertifications()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Certifications\\certifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCertificationsUri, responseContent);

            TraktResponse<TraktCertifications> response = await client.Certifications.GetMovieCertificationsAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktCertifications certifications = response.Content!;

            TraktCertification certification = certifications!.US![0];

            certification.ShouldNotBeNull();
            certification.Name.ShouldBe("G");

            certification = certifications!.US![1];

            certification.ShouldNotBeNull();
            certification.Name.ShouldBe("PG");
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetMovieCertificationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCertificationsUri, statusCode);

            Func<Task<TraktResponse<TraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
