using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowTests
    {
        private const string GetShowUri = $"shows/{TestConstants.Shows.ShowID}";
        private const string GetShowUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const TraktExtendedInfo ExtendedInfoImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;

        [Theory]
        [InlineData(null, GetShowUri, "Shows\\show_minimal.json")]
        [InlineData(ExtendedInfo, $"{GetShowUri}?extended=full", "Shows\\show_full.json")]
        [InlineData(ExtendedInfoImages, $"{GetShowUri}?extended=full,images", "Shows\\show_full_images.json")]
        public async Task TestGetShowWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShow> response = await client.Shows.GetShowAsync(TestConstants.Shows.ShowID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\show_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowUriWithSlug, responseContent);

            TraktResponse<TraktShow> response =
                await client.Shows.GetShowAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\show_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowUriWithSlug, responseContent);

            TraktResponse<TraktShow> response =
                await client.Shows.GetShowAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowUri, statusCode);

            Func<Task<TraktResponse<TraktShow>>> act = () => client.Shows.GetShowAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWithIDThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShow>>> act = () => client.Shows.GetShowAsync(default(TraktShowIDs)!);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowAsync(showIDs);
            await act.ShouldThrowAsync<ArgumentException>();

            showIDs = new TraktShowIDs { TVDB = 121361, TMDB = 1399 };
            act = () => client.Shows.GetShowAsync(showIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
