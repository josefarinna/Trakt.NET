using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowRatingsTests
    {
        private const string GetShowRatingsUriPrefix = "shows";
        private const string GetShowRatingsUriSuffix = "ratings";
        private static readonly string GetShowRatingsUri = $"{GetShowRatingsUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowRatingsUriSuffix}";
        private static readonly string GetShowRatingsUriWithSlug = $"{GetShowRatingsUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowRatingsUriSuffix}";

        [Fact]
        public async Task TestGetShowRatingsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Shows.GetShowRatingsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowRatingsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUriWithSlug, responseContent);

            TraktResponse<TraktRating> response = await client.Shows.GetShowRatingsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowRatingsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUriWithSlug, responseContent);

            TraktResponse<TraktRating> response = await client.Shows.GetShowRatingsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

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

            TraktRating showRatings = response.Content!;

            showRatings.Rating.ShouldBe(8.8911f);
            showRatings.Votes.ShouldBe(145026U);

            showRatings.Distribution.ShouldNotBeNull();
            showRatings.Distribution.Count.ShouldBe(10);
            showRatings.Distribution["1"].ShouldBe(2488U);
            showRatings.Distribution["2"].ShouldBe(711U);
            showRatings.Distribution["3"].ShouldBe(737U);
            showRatings.Distribution["4"].ShouldBe(893U);
            showRatings.Distribution["5"].ShouldBe(2107U);
            showRatings.Distribution["6"].ShouldBe(3565U);
            showRatings.Distribution["7"].ShouldBe(8411U);
            showRatings.Distribution["8"].ShouldBe(19929U);
            showRatings.Distribution["9"].ShouldBe(32323U);
            showRatings.Distribution["10"].ShouldBe(73856U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUri, statusCode);

            try
            {
                await client.Shows.GetShowRatingsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowRatingsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRatingsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktRating>>> act = () => client.Shows.GetShowRatingsAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowRatingsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
