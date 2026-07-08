using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowCertificationsTests
    {
        private const string GetShowCertificationsUriPrefix = "shows";
        private const string GetShowCertificationsUriSuffix = "certifications";
        private static readonly string GetShowCertificationsUri = $"{GetShowCertificationsUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowCertificationsUriSuffix}";
        private static readonly string GetShowCertificationsUriWithSlug = $"{GetShowCertificationsUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowCertificationsUriSuffix}";

        [Fact]
        public async Task TestGetShowCertificationsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUri, responseContent);

            TraktListResponse<TraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowCertificationsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowCertificationsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktShowCertification> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(31);

            IReadOnlyList<TraktShowCertification> showCertifications = response.Content!;

            showCertifications[0].Certification.ShouldBe("16");
            showCertifications[0].Country.ShouldBe("at");

            showCertifications[1].Certification.ShouldBe("R18+");
            showCertifications[1].Country.ShouldBe("au");

            showCertifications[30].Certification.ShouldBe("TV-MA");
            showCertifications[30].Country.ShouldBe("us");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetShowCertificationsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUri, statusCode);

            try
            {
                await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowCertificationsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktShowCertification>>> act = () => client.Shows.GetShowCertificationsAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowCertificationsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
