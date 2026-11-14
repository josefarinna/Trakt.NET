using System.Net;

namespace TraktNET.AwardsModule
{
    public sealed class GetAwardCatalogTests
    {
        private const string GetAwardCatalogUri = "awards";

        [Fact]
        public async Task TestGetAwardCatalog()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\catalog.json");
            TraktClient client = ModuleTestUtility.GetClient(GetAwardCatalogUri, responseContent);

            TraktListResponse<TraktAwardCatalogCeremony> response = await client.Awards.GetAwardCatalogAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktAwardCatalogCeremony> ceremonies = response.Content!;

            TraktAwardCatalogCeremony ceremony = ceremonies[0];
            ceremony.Slug.ShouldBe("golden-globes");
            ceremony.Name.ShouldBe("Golden Globe Awards");
            ceremony.MediaTypes.ShouldNotBeNull();
            ceremony.MediaTypes.Count.ShouldBe(2);
            ceremony.MediaTypes[0].ShouldBe(TraktAwardMediaType.Movie);
            ceremony.MediaTypes[1].ShouldBe(TraktAwardMediaType.Show);

            ceremony.Awards.ShouldNotBeNull();
            ceremony.Awards.Count.ShouldBe(2);

            TraktAwardCatalogAward award = ceremony.Awards[0];
            award.Slug.ShouldBe("golden-globes-best-picture");
            award.Name.ShouldBe("Best Picture");
            award.Kind.ShouldBe(TraktAwardKind.Title);

            award = ceremony.Awards[1];
            award.Slug.ShouldBe("golden-globes-best-actor-drama");
            award.Name.ShouldBe("Best Actor");
            award.Kind.ShouldBe(TraktAwardKind.Person);

            ceremony = ceremonies[1];
            ceremony.Slug.ShouldBe("oscars");
            ceremony.Name.ShouldBe("Academy Awards (Oscars)");
            ceremony.MediaTypes.ShouldNotBeNull();
            ceremony.MediaTypes.Count.ShouldBe(1);
            ceremony.MediaTypes[0].ShouldBe(TraktAwardMediaType.Movie);

            ceremony.Awards.ShouldNotBeNull();
            ceremony.Awards.Count.ShouldBe(1);

            award = ceremony.Awards[0];
            award.Slug.ShouldBe("oscars-best-picture");
            award.Name.ShouldBe("Best Picture");
            award.Kind.ShouldBe(TraktAwardKind.Title);
        }

        [Fact]
        public async Task TestGetCatalog()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\catalog.json");
            TraktClient client = ModuleTestUtility.GetClient(GetAwardCatalogUri, responseContent);

            TraktListResponse<TraktAwardCatalogCeremony> response = await client.Awards.GetCatalogAsync(TestContext.Current.CancellationToken);

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
        public async Task TestGetAwardCatalogThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAwardCatalogUri, statusCode);

            Func<Task<TraktListResponse<TraktAwardCatalogCeremony>>> act = () => client.Awards.GetAwardCatalogAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
