using System.Net;

namespace TraktNET.AwardsModule
{
    public sealed class GetPersonAwardsTests
    {
        private const string GetPersonAwardsUriPrefix = "people";
        private const string GetPersonAwardsUriSuffix = "awards";
        private const uint PersonID = 297737U;
        private const string PersonSlug = "harrison-ford";
        private static readonly TraktPersonIDs PersonIDs = new()
        {
            Trakt = PersonID,
            Slug = PersonSlug
        };
        private static readonly string GetPersonAwardsUri = $"{GetPersonAwardsUriPrefix}/{PersonID}/{GetPersonAwardsUriSuffix}";
        private static readonly string GetPersonAwardsUriWithSlug = $"{GetPersonAwardsUriPrefix}/{PersonSlug}/{GetPersonAwardsUriSuffix}";

        [Fact]
        public async Task TestGetPersonAwardsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\person_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUri, responseContent);

            TraktListResponse<TraktPersonAward> response = await client.Awards.GetPersonAwardsAsync(PersonID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktPersonAward> personAwards = response.Content!;

            TraktPersonAward award = personAwards[0];
            award.Year.ShouldBe(2024U);
            award.Won.ShouldBe(true);
            award.Type.ShouldBe(TraktListItemType.Movie);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("best-performance-by-an-actor-in-a-leading-role");
            award.Ceremony.ShouldNotBeNull();
            award.Ceremony.Slug.ShouldBe("oscars");
            award.Movie.ShouldNotBeNull();
            award.Movie.Title.ShouldBe("Oppenheimer");

            award = personAwards[1];
            award.Year.ShouldBe(2024U);
            award.Won.ShouldBeNull();
            award.Type.ShouldBe(TraktListItemType.Show);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("outstanding-lead-actor-in-a-drama-series");
            award.Ceremony.ShouldNotBeNull();
            award.Ceremony.Slug.ShouldBe("emmys");
            award.Show.ShouldNotBeNull();
            award.Show.Title.ShouldBe("Succession");
        }

        [Fact]
        public async Task TestGetPersonAwardsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\person_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktPersonAward> response = await client.Awards.GetPersonAwardsAsync(PersonSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetPersonAwardsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\person_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktPersonAward> response = await client.Awards.GetPersonAwardsAsync(PersonIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetPersonAwardsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUri, statusCode);

            Func<Task<TraktListResponse<TraktPersonAward>>> act = () => client.Awards.GetPersonAwardsAsync(PersonID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetPersonAwardsWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUriWithSlug, statusCode);

            Func<Task<TraktListResponse<TraktPersonAward>>> act = () => client.Awards.GetPersonAwardsAsync(PersonSlug, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetPersonAwardsWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUriWithSlug, statusCode);

            Func<Task<TraktListResponse<TraktPersonAward>>> act = () => client.Awards.GetPersonAwardsAsync(PersonIDs, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonAwardsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\person_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktPersonAward>>> act = () => client.Awards.GetPersonAwardsAsync(default(TraktPersonIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var personIDs = new TraktPersonIDs();

            act = () => client.Awards.GetPersonAwardsAsync(personIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TestGetPersonAwardsThrowsRequestValidationException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\person_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetPersonAwardsUriWithSlug, responseContent);

            Func<Task<TraktListResponse<TraktPersonAward>>> act = () => client.Awards.GetPersonAwardsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Awards.GetPersonAwardsAsync("  ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Awards.GetPersonAwardsAsync("person id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
