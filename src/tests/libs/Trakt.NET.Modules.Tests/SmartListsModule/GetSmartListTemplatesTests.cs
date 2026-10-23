using System.Net;

namespace TraktNET.SmartListsModule
{
    public sealed class GetSmartListTemplatesTests
    {
        private const string GetSmartListTemplatesUri = "smart-lists/templates";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetSmartListTemplatesWithoutExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_templates.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSmartListTemplatesUri, responseContent);

            TraktListResponse<TraktSmartListTemplate> response = await client.SmartLists.GetSmartListTemplatesAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);

            TraktSmartListTemplate template1 = response.Content[0];
            template1.ShouldNotBeNull();
            template1.Id.ShouldBe("hidden-gems");
            template1.Source.ShouldBe(TraktSmartListSource.Discover);
            template1.MediaType.ShouldBe(TraktSmartListMediaType.Movies);
            template1.Personal.ShouldBe(false);
            template1.Total.ShouldBe(315U);
            template1.Items.ShouldNotBeNull();
            template1.Items.Count.ShouldBe(1);

            TraktSmartListTemplate template2 = response.Content[1];
            template2.ShouldNotBeNull();
            template2.Id.ShouldBe("just-landed-services");
            template2.Source.ShouldBe(TraktSmartListSource.Discover);
            template2.MediaType.ShouldBe(TraktSmartListMediaType.Movies);
            template2.Personal.ShouldBe(true);
            template2.Total.ShouldBeNull();
            template2.Items.ShouldNotBeNull();
            template2.Items.Count.ShouldBe(0);
        }

        [Fact]
        public async Task TestGetSmartListTemplatesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_templates.json");

            string expectedUri = $"{GetSmartListTemplatesUri}?extended={ExtendedInfo.ToURI()}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent);

            TraktListResponse<TraktSmartListTemplate> response = await client.SmartLists.GetSmartListTemplatesAsync(
                ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetSmartListTemplatesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListTemplatesUri, statusCode);

            Func<Task<TraktListResponse<TraktSmartListTemplate>>> act = () => client.SmartLists.GetSmartListTemplatesAsync(
                cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
