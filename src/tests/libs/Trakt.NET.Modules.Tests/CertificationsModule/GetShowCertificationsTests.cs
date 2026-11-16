using System.Net;

namespace TraktNET.CertificationsModule
{
    public sealed class GetShowCertificationsTests
    {
        private const string GetShowCertificationsUri = "certifications/shows";

        [Fact]
        public async Task TestGetShowCertifications()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Certifications\\certifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUri, responseContent);

            TraktResponse<TraktCertifications> response = await client.Certifications.GetShowCertificationsAsync(TestContext.Current.CancellationToken);

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
        public async Task TestGetShowCertificationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUri, statusCode);

            Func<Task<TraktResponse<TraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
