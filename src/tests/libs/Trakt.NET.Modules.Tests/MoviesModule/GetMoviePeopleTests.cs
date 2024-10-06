using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMoviePeopleTests
    {
        private const string GetMoviePeopleUriPrefix = "movies";
        private const string GetMoviePeopleUriSuffix = "people";
        private const string GetMoviePeopleUriWithSlug = GetMoviePeopleUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMoviePeopleUriSuffix;
        private static readonly string GetMoviePeopleUri = $"{GetMoviePeopleUriPrefix}/{TestConstants.Movies.MovieID}/{GetMoviePeopleUriSuffix}";

        [Theory]
        [InlineData(null, $"{GetMoviePeopleUriPrefix}/293990/{GetMoviePeopleUriSuffix}", "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetMoviePeopleUriPrefix}/293990/{GetMoviePeopleUriSuffix}", "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMoviePeopleUriPrefix}/293990/{GetMoviePeopleUriSuffix}?extended=full", "Movies\\moviepeople.json")]
        public async Task TestGetMoviePeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieID, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktCastAndCrew moviePeople = response.Content!;

            moviePeople.Cast.Should().NotBeNull();
            moviePeople.Cast![0].Person.Should().NotBeNull();
            moviePeople.Cast[0].Person!.Name.Should().Be("Chris Pratt");

            moviePeople.Crew.Should().NotBeNull();
            moviePeople.Crew!.Directing.Should().NotBeNull();
            moviePeople.Crew.Directing![0].Person.Should().NotBeNull();
            moviePeople.Crew.Directing![0].Person!.Name.Should().Be("Kera Dacy");
        }

        [Theory]
        [InlineData(null, GetMoviePeopleUriWithSlug, "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.None, GetMoviePeopleUriWithSlug, "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMoviePeopleUriWithSlug}?extended=full", "Movies\\moviepeople.json")]
        public async Task TestGetMoviePeopleWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieSlug, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktCastAndCrew moviePeople = response.Content!;

            moviePeople.Cast.Should().NotBeNull();
            moviePeople.Cast![0].Person.Should().NotBeNull();
            moviePeople.Cast[0].Person!.Name.Should().Be("Chris Pratt");

            moviePeople.Crew.Should().NotBeNull();
            moviePeople.Crew!.Directing.Should().NotBeNull();
            moviePeople.Crew.Directing![0].Person.Should().NotBeNull();
            moviePeople.Crew.Directing![0].Person!.Name.Should().Be("Kera Dacy");
        }

        [Theory]
        [InlineData(null, GetMoviePeopleUriWithSlug, "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.None, GetMoviePeopleUriWithSlug, "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMoviePeopleUriWithSlug}?extended=full", "Movies\\moviepeople.json")]
        public async Task TestGetMoviePeopleWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieIDs, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktCastAndCrew moviePeople = response.Content!;

            moviePeople.Cast.Should().NotBeNull();
            moviePeople.Cast![0].Person.Should().NotBeNull();
            moviePeople.Cast[0].Person!.Name.Should().Be("Chris Pratt");

            moviePeople.Crew.Should().NotBeNull();
            moviePeople.Crew!.Directing.Should().NotBeNull();
            moviePeople.Crew.Directing![0].Person.Should().NotBeNull();
            moviePeople.Crew.Directing![0].Person!.Name.Should().Be("Kera Dacy");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMoviePeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMoviePeopleUri, statusCode);

            try
            {
                await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMoviePeopleWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMoviePeopleUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieSlug);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMoviePeopleWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMoviePeopleUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieIDs);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task TestGetMoviePeopleWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviepeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMoviePeopleUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.Should().ThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMoviePeopleAsync(movieIDs);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
