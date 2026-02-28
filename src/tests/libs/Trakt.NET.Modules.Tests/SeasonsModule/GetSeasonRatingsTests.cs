using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonRatingsTests
    {
        private const string GetSeasonRatingsUriPrefix = "shows";
        private const string GetSeasonRatingsUriSuffix = "ratings";
        private const uint SeasonNumber = 1U;
        private static readonly string GetSeasonRatingsUri = $"{GetSeasonRatingsUriPrefix}/{TestConstants.Shows.ShowID}/seasons/1/{GetSeasonRatingsUriSuffix}";
        private static readonly string GetSeasonRatingsUriWithSlug = $"{GetSeasonRatingsUriPrefix}/{TestConstants.Shows.ShowSlug}/seasons/1/{GetSeasonRatingsUriSuffix}";

        [Fact]
        public async Task TestGetSeasonRatingsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowID, SeasonNumber, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUriWithSlug, responseContent);

            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowSlug, SeasonNumber, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUriWithSlug, responseContent);

            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktRating> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

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
        public async Task TestGetSeasonRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, statusCode);

            try
            {
                await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowID, SeasonNumber, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetSeasonRatingsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(default(TraktShowIDs), SeasonNumber, TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonRatingsAsync(ShowIDs, SeasonNumber, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
