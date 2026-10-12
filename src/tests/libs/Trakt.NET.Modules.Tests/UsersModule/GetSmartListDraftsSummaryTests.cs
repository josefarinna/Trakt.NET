using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSmartListDraftsSummaryTests
    {
        private const string GetSmartListDraftsSummaryUri = $"users/{Username}/smart-list-drafts";
        private const string Username = "sean";

        [Fact]
        public async Task TestGetSmartListDraftsSummary()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_drafts_summary.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListDraftsSummaryUri, responseContent);

            TraktResponse<TraktSmartListDraftsSummary> response = await client.Users.GetSmartListDraftsSummaryAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSmartListDraftsSummary responseValue = response.Content;

            responseValue.ConvertibleCount.ShouldBe(2U);
            responseValue.BestConfidence.ShouldBe(0.95f);

            responseValue.Lists.ShouldNotBeNull();
            responseValue.Lists.Count.ShouldBe(2);

            responseValue.Lists[0].ShouldNotBeNull();
            responseValue.Lists[0].IDs.ShouldNotBeNull();
            responseValue.Lists[0].IDs!.Trakt.ShouldBe(1248149U);
            responseValue.Lists[0].IDs!.Slug.ShouldBe("marvel-cinematic-universe");
            responseValue.Lists[0].Name.ShouldBe("Marvel Cinematic Universe");
            responseValue.Lists[0].ItemCount.ShouldBe(33U);
            responseValue.Lists[0].Confidence.ShouldBe(0.95f);

            responseValue.Lists[1].ShouldNotBeNull();
            responseValue.Lists[1].IDs.ShouldNotBeNull();
            responseValue.Lists[1].IDs!.Trakt.ShouldBe(987654U);
            responseValue.Lists[1].IDs!.Slug.ShouldBe("dc-extended-universe");
            responseValue.Lists[1].Name.ShouldBe("DC Extended Universe");
            responseValue.Lists[1].ItemCount.ShouldBe(15U);
            responseValue.Lists[1].Confidence.ShouldBe(0.8f);
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
        public async Task TestGetSmartListDraftsSummaryThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListDraftsSummaryUri, statusCode);
            Func<Task<TraktResponse<TraktSmartListDraftsSummary>>> act = () => client.Users.GetSmartListDraftsSummaryAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListDraftsSummaryArgumentExceptions()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            Func<Task<TraktResponse<TraktSmartListDraftsSummary>>> act = () => client.Users.GetSmartListDraftsSummaryAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftsSummaryAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftsSummaryAsync("username with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
