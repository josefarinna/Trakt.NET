using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowAwardsTests
    {
        private const string GetShowAwardsUriPrefix = "shows";
        private const string GetShowAwardsUriSuffix = "awards";
        private static readonly string GetShowAwardsUri = $"{GetShowAwardsUriPrefix}/{TestConstants.Shows.TraktShowID}/{GetShowAwardsUriSuffix}";
        private static readonly string GetShowAwardsUriWithSlug = $"{GetShowAwardsUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowAwardsUriSuffix}";

        [Fact]
        public async Task TestGetShowAwardsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUri, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Shows.GetShowAwardsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktTitleAward> showAwards = response.Content!;

            TraktTitleAward award = showAwards[0];
            award.Year.ShouldBe(2024U);
            award.Won.ShouldBe(true);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("outstanding-drama-series");
            award.Ceremony.ShouldNotBeNull();
            award.Ceremony.Slug.ShouldBe("emmys");
            award.Person.ShouldNotBeNull();
            award.Person.Name.ShouldBe("Jesse Armstrong");

            award = showAwards[1];
            award.Year.ShouldBe(2024U);
            award.Won.ShouldBe(true);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("outstanding-lead-actor-in-a-drama-series");
            award.Person.ShouldNotBeNull();
            award.Person.Name.ShouldBe("Kieran Culkin");
        }

        [Fact]
        public async Task TestGetAwardsAliasWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUri, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Shows.GetAwardsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetShowAwardsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Shows.GetShowAwardsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

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
        public async Task TestGetAwardsAliasWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Shows.GetAwardsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetShowAwardsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Shows.GetShowAwardsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

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
        public async Task TestGetAwardsAliasWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Shows.GetAwardsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetShowAwardsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUri, statusCode);

            try
            {
                await client.Shows.GetShowAwardsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetShowAwardsWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowAwardsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetShowAwardsWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowAwardsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetShowAwardsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Shows.GetShowAwardsAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Shows.GetShowAwardsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TestGetShowAwardsThrowsRequestValidationException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Shows.GetShowAwardsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.GetShowAwardsAsync("  ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.GetShowAwardsAsync("show id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
