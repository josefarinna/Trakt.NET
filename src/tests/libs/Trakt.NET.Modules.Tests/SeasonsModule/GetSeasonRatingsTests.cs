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
        public async Task TestGetSeasonRatingsWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.TraktShowID, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

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
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        public async Task TestGetSeasonRatingsWithSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonratings.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);
            
            TraktResponse<TraktRating> response = await client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.ShowSlug, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/ratings")]
        public async Task TestGetSeasonRatingsWithIDs(TraktExtendedInfo? extendedInfo, string requestUri)
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
        public async Task TestGetSeasonRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonRatingsUri, statusCode);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
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
