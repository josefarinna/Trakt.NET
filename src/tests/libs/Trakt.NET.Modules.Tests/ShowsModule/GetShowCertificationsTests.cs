using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowCertificationsTests
    {
        private const string GetShowCertificationsUri = $"shows/{TestConstants.Shows.ShowID}/certifications";
        private const string GetShowCertificationsUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/certifications";
        private const int ListItemCount = 31;

        [Fact]
        public async Task TestGetShowCertificationsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUri, responseContent);

            TraktListResponse<TraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowCertificationsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowCertificationsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcertifications.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowCertificationsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUri, statusCode);

            Func<Task<TraktListResponse<TraktShowCertification>>> act = () => client.Shows.GetShowCertificationsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCertificationsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCertificationsUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktShowCertification>>> act = () => client.Shows.GetShowCertificationsAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowCertificationsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
