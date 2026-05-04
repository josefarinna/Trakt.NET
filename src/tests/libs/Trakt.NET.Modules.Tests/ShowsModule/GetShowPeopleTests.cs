using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowPeopleTests
    {
        private const string GetShowPeopleUriPrefix = "shows";
        private const string GetShowPeopleUriSuffix = "people";
        private const string GetShowPeopleUriWithSlug = GetShowPeopleUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + GetShowPeopleUriSuffix;
        private static readonly string GetShowPeopleUri = $"{GetShowPeopleUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowPeopleUriSuffix}";

        [Theory]
        [InlineData(null, $"{GetShowPeopleUriPrefix}/1390/{GetShowPeopleUriSuffix}", "Shows\\showpeople.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetShowPeopleUriPrefix}/1390/{GetShowPeopleUriSuffix}", "Shows\\showpeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowPeopleUriPrefix}/1390/{GetShowPeopleUriSuffix}?extended=full", "Shows\\showpeople.json")]
        public async Task TestGetShowPeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowPeopleUriWithSlug, "Shows\\showpeople.json")]
        [InlineData(TraktExtendedInfo.None, GetShowPeopleUriWithSlug, "Shows\\showpeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowPeopleUriWithSlug}?extended=full", "Shows\\showpeople.json")]
        public async Task TestGetShowPeopleWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowSlug, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetShowPeopleUriWithSlug, "Shows\\showpeople.json")]
        [InlineData(TraktExtendedInfo.None, GetShowPeopleUriWithSlug, "Shows\\showpeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetShowPeopleUriWithSlug}?extended=full", "Shows\\showpeople.json")]
        public async Task TestGetShowPeopleWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowIDs, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
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
        public async Task TestGetShowPeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUri, statusCode);

            try
            {
                await client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Shows.GetShowPeopleAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        private static void ValidateResponse(TraktResponse<TraktCastAndCrew> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktCastAndCrew showPeople = response.Content!;

            showPeople.Cast.ShouldNotBeNull();
            showPeople.Cast![0].Person.ShouldNotBeNull();
            showPeople.Cast[0].Person!.Name.ShouldBe("Kit Harington");

            showPeople.Crew.ShouldNotBeNull();
            showPeople.Crew!.Writing.ShouldNotBeNull();
            showPeople.Crew.Writing![0].Person.ShouldNotBeNull();
            showPeople.Crew.Writing![0].Person!.Name.ShouldBe("George R. R. Martin");
        }
    }
}
