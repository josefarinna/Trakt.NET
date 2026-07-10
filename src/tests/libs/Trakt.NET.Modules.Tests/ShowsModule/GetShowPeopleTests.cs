using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowPeopleTests
    {
        private const string GetShowPeopleUri = $"shows/{TestConstants.Shows.ShowID}/people";
        private const string GetShowPeopleUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/people";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetShowPeopleWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowPeopleUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithSlugAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowPeopleUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowSlug, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDsAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowPeopleUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowIDs, ExtendedInfo, TestContext.Current.CancellationToken);

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
        public async Task TestGetShowPeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, "{}");

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowPeopleAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
