namespace TraktNet.Requests.Tests.Certifications
{
    using FluentAssertions;

    using TraktNet.Requests.Certifications;
    using Xunit;

    [Trait("Category", "Requests.Certifications")]
    public class ShowCertificationsRequest_Tests
    {
        [Fact]
        public void Test_ShowCertificationsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowCertificationsRequest();
            request.UriTemplate.Should().Be("certifications/shows");
        }
    }
}
