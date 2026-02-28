using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonWatchingUsersTests
    {
        private const string GetSeasonWatchingUsersUriPrefix = "shows";
        private const string GetSeasonWatchingUsersUriSuffix = "watching";
        private const uint SeasonNumber = 1U;
        private const string GetSeasonWatchingUsersUriWithSlug = GetSeasonWatchingUsersUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/seasons/1/" + GetSeasonWatchingUsersUriSuffix;

        [Theory]
        [InlineData(null, $"{GetSeasonWatchingUsersUriPrefix}/1390/seasons/1/{GetSeasonWatchingUsersUriSuffix}", "Seasons\\seasonwatchingusers.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetSeasonWatchingUsersUriPrefix}/1390/seasons/1/{GetSeasonWatchingUsersUriSuffix}", "Seasons\\seasonwatchingusers.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonWatchingUsersUriPrefix}/1390/seasons/1/{GetSeasonWatchingUsersUriSuffix}?extended=full", "Seasons\\seasonwatchingusers.json")]
        public async Task TestGetSeasonWatchingUsersWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Seasons.GetSeasonWatchingUsersAsync(TestConstants.Shows.ShowID, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(null, GetSeasonWatchingUsersUriWithSlug, "Seasons\\seasonwatchingusers.json")]
        [InlineData(TraktExtendedInfo.None, GetSeasonWatchingUsersUriWithSlug, "Seasons\\seasonwatchingusers.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetSeasonWatchingUsersUriWithSlug}?extended=full", "Seasons\\seasonwatchingusers.json")]
        public async Task TestGetSeasonWatchingUsersWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Seasons.GetSeasonWatchingUsersAsync(TestConstants.Shows.ShowSlug, SeasonNumber, extendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonWatchingUsersWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonWatchingUsersUriWithSlug, responseContent);

            TraktListResponse<TraktUser> response = await client.Seasons.GetSeasonWatchingUsersAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktUser> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktUser> users = response.Content!;

            users[0].ShouldNotBeNull();
            users[0].Username.ShouldBe("user1");
            users[0].Name.ShouldBe("User Name 1");
            users[0].IDs.ShouldNotBeNull();
            users[0].IDs!.Slug.ShouldBe("user1");

            users[1].ShouldNotBeNull();
            users[1].Username.ShouldBe("user2");
            users[1].Name.ShouldBe("User Name 2");
            users[1].IDs.ShouldNotBeNull();
            users[1].IDs!.Slug.ShouldBe("user2");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonWatchingUsersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonWatchingUsersUriWithSlug, statusCode);

            try
            {
                await client.Seasons.GetSeasonWatchingUsersAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetSeasonWatchingUsersWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonWatchingUsersUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonWatchingUsersAsync(ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
