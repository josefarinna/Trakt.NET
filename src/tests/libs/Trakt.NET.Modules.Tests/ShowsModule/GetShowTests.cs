using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowTests
    {
        private const string GetShowUri = "shows";
        private const string GetShowUriWithSlug = GetShowUri + "/" + TestConstants.Shows.ShowSlug;

        [Theory]
        [InlineData(null, $"{GetShowUri}/1390", "Shows\\show_minimal.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetShowUri}/1390", "Shows\\show_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowUri}/1390?extended=full", "Shows\\show_full.json")]
        [InlineData(TraktExtendedInfo.Full | TraktExtendedInfo.Images, $"{GetShowUri}/1390?extended=full,images", "Shows\\show_full_images.json")]
        public async Task TestGetShowWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShow> response =
                await client.Shows.GetShowAsync(TestConstants.Shows.ShowID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktShow show = response.Content!;

            show.Title.ShouldBe("Game of Thrones");
            show.Year.ShouldBe(2011U);
            show.IDs!.Slug.ShouldBe("game-of-thrones");
        }

        [Theory]
        [InlineData(null, GetShowUriWithSlug, "Shows\\show_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetShowUriWithSlug, "Shows\\show_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowUriWithSlug}?extended=full", "Shows\\show_full.json")]
        [InlineData(TraktExtendedInfo.Full | TraktExtendedInfo.Images, $"{GetShowUriWithSlug}?extended=full,images", "Shows\\show_full_images.json")]
        public async Task TestGetShowWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShow> response =
                await client.Shows.GetShowAsync(TestConstants.Shows.ShowSlug, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktShow show = response.Content!;

            show.Title.ShouldBe("Game of Thrones");
            show.Year.ShouldBe(2011U);
            show.IDs!.Slug.ShouldBe("game-of-thrones");
        }

        [Theory]
        [InlineData(null, GetShowUriWithSlug, "Shows\\show_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetShowUriWithSlug, "Shows\\show_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowUriWithSlug}?extended=full", "Shows\\show_full.json")]
        [InlineData(TraktExtendedInfo.Full | TraktExtendedInfo.Images, $"{GetShowUriWithSlug}?extended=full,images", "Shows\\show_full_images.json")]
        public async Task TestGetShowWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktShow> response =
                await client.Shows.GetShowAsync(TestConstants.Shows.ShowIDs, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktShow show = response.Content!;

            show.Title.ShouldBe("Game of Thrones");
            show.Year.ShouldBe(2011U);
            show.IDs!.Slug.ShouldBe("game-of-thrones");
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
        public async Task TestGetShowWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowUri}/1390", statusCode);

            try
            {
                await client.Shows.GetShowAsync(TestConstants.Shows.ShowID,
                                                cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetShowWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\show_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktShow>>> act =
                () => client.Shows.GetShowAsync(default(TraktShowIDs));
#pragma warning restore CS8625

            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Shows.GetShowAsync(showIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
