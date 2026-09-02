using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonRatingsTests
    {
        private const string GetSeasonRatingsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/ratings";
        private const uint SeasonNr = 1U;

        [Theory]
        [InlineData(null, GetSeasonRatingsUri)]
        [InlineData(TraktExtendedInfo.None, GetSeasonRatingsUri)]
        [InlineData(TraktExtendedInfo.All, $"{GetSeasonRatingsUri}?extended=all")]
        public async Task TestGetSeasonRatings(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowID, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktRating responseValue = response.Content;

            responseValue.Rating.ShouldBe(8.8911f);
            responseValue.Votes.ShouldBe(145026U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  2488 }, { "2", 711 }, { "3", 737 }, { "4", 893 }, { "5", 2107 },
                { "6",  3565 }, { "7", 8411 }, { "8", 19929 }, { "9", 32323 }, { "10", 73856 }
            };

            responseValue.Distribution.ShouldNotBeNull();
            responseValue.Distribution.Count.ShouldBe(10);
            responseValue.Distribution.ShouldBeEquivalentTo(distribution);
        }

        [Theory]
        [InlineData(null, GetSeasonRatingsUri)]
        [InlineData(TraktExtendedInfo.None, GetSeasonRatingsUri)]
        [InlineData(TraktExtendedInfo.All, $"{GetSeasonRatingsUri}?extended=all")]
        public async Task TestGetSeasonRatingsWithTraktID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.TraktShowID, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, GetSeasonRatingsUri)]
        [InlineData(TraktExtendedInfo.None, GetSeasonRatingsUri)]
        [InlineData(TraktExtendedInfo.All, $"{GetSeasonRatingsUri}?extended=all")]
        public async Task TestGetSeasonRatingsWithShowIDsTraktID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(showIDs, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        [InlineData(TraktExtendedInfo.None, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        [InlineData(TraktExtendedInfo.All, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings?extended=all")]
        public async Task TestGetSeasonRatingsWithShowIDsSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(showIDs, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        [InlineData(TraktExtendedInfo.None, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        [InlineData(TraktExtendedInfo.All, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings?extended=all")]
        public async Task TestGetSeasonRatingsWithShowIDs(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowIDs, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        [InlineData(TraktExtendedInfo.None, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        [InlineData(TraktExtendedInfo.All, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings?extended=all")]
        public async Task TestGetSeasonRatingsWithShow(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(show, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestGetSeasonRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, statusCode);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(default(TraktShowIDs)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonRatingsAsync(default(TraktShow)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonRatingsAsync(new TraktShowIDs(), SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonRatingsAsync(0, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
