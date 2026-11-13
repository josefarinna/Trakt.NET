using System.Net;

namespace TraktNET.AwardsModule
{
    public sealed class GetCeremoniesTests
    {
        private const string GetCeremoniesUri = "awards/ceremonies";

        [Fact]
        public async Task TestGetCeremonies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\ceremonies.json");
            TraktClient client = ModuleTestUtility.GetClient(GetCeremoniesUri, responseContent);

            TraktListResponse<TraktUpcomingCeremony> response = await client.Awards.GetCeremoniesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktUpcomingCeremony> ceremonies = response.Content!;

            TraktUpcomingCeremony ceremony = ceremonies[0];
            ceremony.Slug.ShouldBe("oscars");
            ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            ceremony.Edition.ShouldBe(97U);
            ceremony.Year.ShouldBe(2025U);

#if NET7_0_OR_GREATER
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2025-01-23"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-03-02"));
#else
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-23T00:00:00.000Z"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-03-02T00:00:00.000Z"));
#endif

            ceremony = ceremonies[1];
            ceremony.Slug.ShouldBe("golden-globes");
            ceremony.Name.ShouldBe("Golden Globes");
            ceremony.Edition.ShouldBe(82U);
            ceremony.Year.ShouldBe(2025U);

#if NET7_0_OR_GREATER
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseDate("2024-12-09"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseDate("2025-01-05"));
#else
            ceremony.NominationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-12-09T00:00:00.000Z"));
            ceremony.HeldAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-05T00:00:00.000Z"));
#endif
        }

        [Fact]
        public async Task TestGetUpcomingCeremonies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\ceremonies.json");
            TraktClient client = ModuleTestUtility.GetClient(GetCeremoniesUri, responseContent);

            TraktListResponse<TraktUpcomingCeremony> response = await client.Awards.GetUpcomingCeremoniesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetCeremoniesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCeremoniesUri, statusCode);

            try
            {
                await client.Awards.GetCeremoniesAsync(TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
