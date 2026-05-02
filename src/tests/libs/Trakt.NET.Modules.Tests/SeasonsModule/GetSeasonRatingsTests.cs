using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonRatingsTests
    {
        private static readonly string GetSeasonRatingsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/ratings";
        private const uint SeasonNr = 1U;

        [Fact]
        public async Task TestGetSeasonRatings()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync($"{TestConstants.Shows.ShowID}", SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktRating seasonRatings = response.Content!;

            seasonRatings.Rating.ShouldBe(8.8911f);
            seasonRatings.Votes.ShouldBe(145026U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  2488 }, { "2", 711 }, { "3", 737 }, { "4", 893 }, { "5", 2107 },
                { "6",  3565 }, { "7", 8411 }, { "8", 19929 }, { "9", 32323 }, { "10", 73856 }
            };

            seasonRatings.Distribution.ShouldNotBeNull();
            seasonRatings.Distribution.Count.ShouldBe(10);
            seasonRatings.Distribution.ShouldBeEquivalentTo(distribution);
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowID, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(showIDs, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/ratings", responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(showIDs, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithShowIDs()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/ratings", responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(showIDs, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/ratings", responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(show, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        private static void ValidateResponse(TraktResponse<TraktRating> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktRating seasonRatings = response.Content!;

            seasonRatings.Rating.ShouldBe(8.8911f);
            seasonRatings.Votes.ShouldBe(145026U);

            seasonRatings.Distribution.ShouldNotBeNull();
            seasonRatings.Distribution.Count.ShouldBe(10);
            seasonRatings.Distribution["1"].ShouldBe(2488U);
            seasonRatings.Distribution["2"].ShouldBe(711U);
            seasonRatings.Distribution["3"].ShouldBe(737U);
            seasonRatings.Distribution["4"].ShouldBe(893U);
            seasonRatings.Distribution["5"].ShouldBe(2107U);
            seasonRatings.Distribution["6"].ShouldBe(3565U);
            seasonRatings.Distribution["7"].ShouldBe(8411U);
            seasonRatings.Distribution["8"].ShouldBe(19929U);
            seasonRatings.Distribution["9"].ShouldBe(32323U);
            seasonRatings.Distribution["10"].ShouldBe(73856U);
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

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(default(TraktShowIDs)!, SeasonNr, TestContext.Current.CancellationToken);
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
