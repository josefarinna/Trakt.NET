using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchedProgressTests
    {
        private const string GetShowWatchedProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/watched";
        private const string GetShowWatchedProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/watched";

        [Fact]
        public async Task TestGetShowWatchedProgress()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithHidden()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchedProgressUriWithSlug}?hidden=true", responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, hidden: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchedProgressUriWithSlug}?specials=true", responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, specials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithCountSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchedProgressUriWithSlug}?count_specials=true", responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, countSpecials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchedProgressUriWithSlug}?hidden=true&specials=true&count_specials=true", responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, hidden: true, specials: true, countSpecials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUri, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowWatchedProgress> response = await client.Shows.GetShowWatchedProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetShowWatchedProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, statusCode);

            Func<Task<TraktResponse<TraktShowWatchedProgress>>> act = () => client.Shows.GetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchedProgressUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShowWatchedProgress>>> act = () => client.Shows.GetShowWatchedProgressAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowWatchedProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
