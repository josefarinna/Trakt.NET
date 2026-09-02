using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class RefreshPersonTests
    {
        private const string RefreshPersonUriPrefix = "people";
        private const string RefreshPersonUriSuffix = "refresh";
        private const string RefreshPersonUriWithSlug = RefreshPersonUriPrefix + "/" + PersonSlug + "/" + RefreshPersonUriSuffix;
        private const string PersonSlug = "bryan-cranston";
        private const uint PersonID = 297737U;

        [Fact]
        public async Task TestRefreshPersonWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{RefreshPersonUriPrefix}/{PersonID}/{RefreshPersonUriSuffix}", HttpStatusCode.Created);

            TraktResponse response = await client.People.RefreshPersonAsync(PersonID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshPersonWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshPersonUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.People.RefreshPersonAsync(PersonSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshPersonWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshPersonUriWithSlug, HttpStatusCode.Created);

            var personIDs = new TraktPersonIDs
            {
                Trakt = PersonID,
                Slug = PersonSlug
            };

            TraktResponse response = await client.People.RefreshPersonAsync(personIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData(true, "?images=true")]
        [InlineData(false, "?images=false")]
        public async Task TestRefreshPersonWithImages(bool? images, string query)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{RefreshPersonUriWithSlug}{query}", HttpStatusCode.Created);

            TraktResponse response = await client.People.RefreshPersonAsync(PersonSlug, images, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiPersonNotFoundException))]
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
        public async Task TestRefreshPersonThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshPersonUriWithSlug, statusCode);

            Func<Task<TraktResponse>> act = () => client.People.RefreshPersonAsync(PersonSlug, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshPersonThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshPersonUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.People.RefreshPersonAsync(default(TraktPersonIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.RefreshPersonAsync(new TraktPersonIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.RefreshPersonAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
