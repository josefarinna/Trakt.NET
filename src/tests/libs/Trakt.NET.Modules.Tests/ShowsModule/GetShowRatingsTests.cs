using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowRatingsTests
    {
        private const string GetShowRatingsUri = $"shows/{TestConstants.Shows.ShowID}/ratings";
        private const string GetShowRatingsUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/ratings";

        [Theory]
        [InlineData(null, GetShowRatingsUri)]
        [InlineData(TraktExtendedInfo.None, GetShowRatingsUri)]
        [InlineData(TraktExtendedInfo.All, $"{GetShowRatingsUri}?extended=all")]
        public async Task TestGetShowRatingsWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Shows.GetShowRatingsAsync(TestConstants.Shows.TraktShowID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, GetShowRatingsUriWithSlug)]
        public async Task TestGetShowRatingsWithSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Shows.GetShowRatingsAsync(TestConstants.Shows.ShowSlug, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, GetShowRatingsUriWithSlug)]
        public async Task TestGetShowRatingsWithIDs(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Shows.GetShowRatingsAsync(TestConstants.Shows.ShowIDs, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUri, statusCode);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Shows.GetShowRatingsAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowRatingsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Shows.GetShowRatingsAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowRatingsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
