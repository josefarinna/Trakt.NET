using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonPeopleTests
    {
        private const string GetSeasonPeopleUriPrefix = "shows";
        private const string GetSeasonPeopleUriSuffix = "people";
        private const uint SeasonNumber = 1U;
        private const string GetSeasonPeopleUriWithSlug = GetSeasonPeopleUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/seasons/1/" + GetSeasonPeopleUriSuffix;
        private static readonly string GetSeasonPeopleUri = $"{GetSeasonPeopleUriPrefix}/{TestConstants.Shows.ShowID}/seasons/1/{GetSeasonPeopleUriSuffix}";

        [Theory]
        [InlineData(null, $"{GetSeasonPeopleUriPrefix}/1390/seasons/1/{GetSeasonPeopleUriSuffix}", "Seasons\\seasonpeople.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetSeasonPeopleUriPrefix}/1390/seasons/1/{GetSeasonPeopleUriSuffix}", "Seasons\\seasonpeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonPeopleUriPrefix}/1390/seasons/1/{GetSeasonPeopleUriSuffix}?extended=full", "Seasons\\seasonpeople.json")]
        public async Task TestGetSeasonPeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowID, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetSeasonPeopleUriWithSlug, "Seasons\\seasonpeople.json")]
        [InlineData(TraktExtendedInfo.None, GetSeasonPeopleUriWithSlug, "Seasons\\seasonpeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonPeopleUriWithSlug}?extended=full", "Seasons\\seasonpeople.json")]
        public async Task TestGetSeasonPeopleWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowSlug, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetSeasonPeopleUriWithSlug, "Seasons\\seasonpeople.json")]
        [InlineData(TraktExtendedInfo.None, GetSeasonPeopleUriWithSlug, "Seasons\\seasonpeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonPeopleUriWithSlug}?extended=full", "Seasons\\seasonpeople.json")]
        public async Task TestGetSeasonPeopleWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowIDs, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
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
        public async Task TestGetSeasonPeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUri, statusCode);

            try
            {
                await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowID, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Seasons.GetSeasonPeopleAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();

            act = () => client.Seasons.GetSeasonPeopleAsync(ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
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

            TraktCastAndCrew seasonPeople = response.Content!;

            seasonPeople.Cast.ShouldNotBeNull();
            seasonPeople.Cast![0].Person.ShouldNotBeNull();
            seasonPeople.Cast[0].Person!.Name.ShouldBe("Kit Harington");

            seasonPeople.Crew.ShouldNotBeNull();
            seasonPeople.Crew!.Writing.ShouldNotBeNull();
            seasonPeople.Crew.Writing![0].Person.ShouldNotBeNull();
            seasonPeople.Crew.Writing![0].Person!.Name.ShouldBe("George R. R. Martin");
        }
    }
}
