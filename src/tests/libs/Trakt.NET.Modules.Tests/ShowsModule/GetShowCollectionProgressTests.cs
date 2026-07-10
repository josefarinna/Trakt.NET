using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowCollectionProgressTests
    {
        private const string GetShowCollectionProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/collection";
        private const string GetShowCollectionProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/collection";

        [Fact]
        public async Task TestGetShowCollectionProgress()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithHidden()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUriWithSlug}?hidden=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, hidden: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUriWithSlug}?specials=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, specials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithCountSpecials()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUriWithSlug}?count_specials=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, countSpecials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowCollectionProgressUriWithSlug}?hidden=true&specials=true&count_specials=true", responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.ShowSlug, hidden: true, specials: true, countSpecials: true, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUri, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
                TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcollectionprogress.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, responseContent);

            TraktResponse<TraktShowCollectionProgress> response = await client.Shows.GetShowCollectionProgressAsync(
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
        public async Task TestGetShowCollectionProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, statusCode);

            Func<Task<TraktResponse<TraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowCollectionProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCollectionProgressUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowCollectionProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
