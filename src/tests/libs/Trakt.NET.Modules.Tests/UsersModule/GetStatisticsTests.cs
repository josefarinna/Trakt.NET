using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetStatisticsTests
    {
        private const string GetStatisticsUri = $"users/{Username}/stats";
        private const string Username = "sean";

        [Fact]
        public async Task TestGetStatistics()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userstatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetStatisticsUri, responseContent);
            
            TraktResponse<TraktUserStatistics> response = await client.Users.GetStatisticsAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserStatistics responseValue = response.Content;

            responseValue.Movies.ShouldNotBeNull();
            responseValue.Movies.Plays.ShouldBe(552U);
            responseValue.Movies.Watched.ShouldBe(534U);
            responseValue.Movies.Minutes.ShouldBe(17330U);
            responseValue.Movies.Collected.ShouldBe(117U);
            responseValue.Movies.Ratings.ShouldBe(64U);
            responseValue.Movies.Comments.ShouldBe(14U);

            responseValue.Shows.ShouldNotBeNull();
            responseValue.Shows.Watched.ShouldBe(534U);
            responseValue.Shows.Collected.ShouldBe(117U);
            responseValue.Shows.Ratings.ShouldBe(64U);
            responseValue.Shows.Comments.ShouldBe(14U);

            responseValue.Seasons.ShouldNotBeNull();
            responseValue.Seasons.Ratings.ShouldBe(6U);
            responseValue.Seasons.Comments.ShouldBe(1U);

            responseValue.Episodes.ShouldNotBeNull();
            responseValue.Episodes.Plays.ShouldBe(552U);
            responseValue.Episodes.Watched.ShouldBe(534U);
            responseValue.Episodes.Minutes.ShouldBe(17330U);
            responseValue.Episodes.Collected.ShouldBe(117U);
            responseValue.Episodes.Ratings.ShouldBe(64U);
            responseValue.Episodes.Comments.ShouldBe(14U);

            responseValue.Network.ShouldNotBeNull();
            responseValue.Network.Friends.ShouldBe(1U);
            responseValue.Network.Followers.ShouldBe(4U);
            responseValue.Network.Following.ShouldBe(11U);

            responseValue.Ratings.ShouldNotBeNull();
            responseValue.Ratings.Total.ShouldBe(9257U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  78 }, { "2", 45 }, { "3", 55 }, { "4", 96 }, { "5", 183 },
                { "6",  545 }, { "7", 1361 }, { "8", 2259 }, { "9", 1772 }, { "10", 2863 }
            };

            responseValue.Ratings.Distribution.ShouldNotBeNull();
            responseValue.Ratings.Distribution.Count.ShouldBe(10);
            responseValue.Ratings.Distribution.ShouldBe(distribution);

            responseValue.Progress.ShouldNotBeNull();
            responseValue.Progress.Started.ShouldBe(388U);
            responseValue.Progress.Finished.ShouldBe(276U);
            responseValue.Progress.Dropped.ShouldBe(22U);

            responseValue.Lists.ShouldBe(31U);
            responseValue.TotalMinutes.ShouldBe(618949U);
            responseValue.TotalPlays.ShouldBe(12473U);
        }

        [Fact]
        public async Task TestGetStatisticsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userstatistics.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetStatisticsUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktUserStatistics> response = await client.Users.GetStatisticsAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserStatistics responseValue = response.Content;

            responseValue.Movies.ShouldNotBeNull();
            responseValue.Movies.Plays.ShouldBe(552U);
            responseValue.Movies.Watched.ShouldBe(534U);
            responseValue.Movies.Minutes.ShouldBe(17330U);
            responseValue.Movies.Collected.ShouldBe(117U);
            responseValue.Movies.Ratings.ShouldBe(64U);
            responseValue.Movies.Comments.ShouldBe(14U);

            responseValue.Shows.ShouldNotBeNull();
            responseValue.Shows.Watched.ShouldBe(534U);
            responseValue.Shows.Collected.ShouldBe(117U);
            responseValue.Shows.Ratings.ShouldBe(64U);
            responseValue.Shows.Comments.ShouldBe(14U);

            responseValue.Seasons.ShouldNotBeNull();
            responseValue.Seasons.Ratings.ShouldBe(6U);
            responseValue.Seasons.Comments.ShouldBe(1U);

            responseValue.Episodes.ShouldNotBeNull();
            responseValue.Episodes.Plays.ShouldBe(552U);
            responseValue.Episodes.Watched.ShouldBe(534U);
            responseValue.Episodes.Minutes.ShouldBe(17330U);
            responseValue.Episodes.Collected.ShouldBe(117U);
            responseValue.Episodes.Ratings.ShouldBe(64U);
            responseValue.Episodes.Comments.ShouldBe(14U);

            responseValue.Network.ShouldNotBeNull();
            responseValue.Network.Friends.ShouldBe(1U);
            responseValue.Network.Followers.ShouldBe(4U);
            responseValue.Network.Following.ShouldBe(11U);

            responseValue.Ratings.ShouldNotBeNull();
            responseValue.Ratings.Total.ShouldBe(9257U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  78 }, { "2", 45 }, { "3", 55 }, { "4", 96 }, { "5", 183 },
                { "6",  545 }, { "7", 1361 }, { "8", 2259 }, { "9", 1772 }, { "10", 2863 }
            };

            responseValue.Ratings.Distribution.ShouldNotBeNull();
            responseValue.Ratings.Distribution.Count.ShouldBe(10);
            responseValue.Ratings.Distribution.ShouldBe(distribution);

            responseValue.Progress.ShouldNotBeNull();
            responseValue.Progress.Started.ShouldBe(388U);
            responseValue.Progress.Finished.ShouldBe(276U);
            responseValue.Progress.Dropped.ShouldBe(22U);

            responseValue.Lists.ShouldBe(31U);
            responseValue.TotalMinutes.ShouldBe(618949U);
            responseValue.TotalPlays.ShouldBe(12473U);
        }

        [Fact]
        public async Task TestGetStatisticsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userstatistics.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/stats", responseContent);
            
            TraktResponse<TraktUserStatistics> response = await client.Users.GetStatisticsAsync("me", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserStatistics responseValue = response.Content;

            responseValue.Movies.ShouldNotBeNull();
            responseValue.Movies.Plays.ShouldBe(552U);
            responseValue.Movies.Watched.ShouldBe(534U);
            responseValue.Movies.Minutes.ShouldBe(17330U);
            responseValue.Movies.Collected.ShouldBe(117U);
            responseValue.Movies.Ratings.ShouldBe(64U);
            responseValue.Movies.Comments.ShouldBe(14U);

            responseValue.Shows.ShouldNotBeNull();
            responseValue.Shows.Watched.ShouldBe(534U);
            responseValue.Shows.Collected.ShouldBe(117U);
            responseValue.Shows.Ratings.ShouldBe(64U);
            responseValue.Shows.Comments.ShouldBe(14U);

            responseValue.Seasons.ShouldNotBeNull();
            responseValue.Seasons.Ratings.ShouldBe(6U);
            responseValue.Seasons.Comments.ShouldBe(1U);

            responseValue.Episodes.ShouldNotBeNull();
            responseValue.Episodes.Plays.ShouldBe(552U);
            responseValue.Episodes.Watched.ShouldBe(534U);
            responseValue.Episodes.Minutes.ShouldBe(17330U);
            responseValue.Episodes.Collected.ShouldBe(117U);
            responseValue.Episodes.Ratings.ShouldBe(64U);
            responseValue.Episodes.Comments.ShouldBe(14U);

            responseValue.Network.ShouldNotBeNull();
            responseValue.Network.Friends.ShouldBe(1U);
            responseValue.Network.Followers.ShouldBe(4U);
            responseValue.Network.Following.ShouldBe(11U);

            responseValue.Ratings.ShouldNotBeNull();
            responseValue.Ratings.Total.ShouldBe(9257U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  78 }, { "2", 45 }, { "3", 55 }, { "4", 96 }, { "5", 183 },
                { "6",  545 }, { "7", 1361 }, { "8", 2259 }, { "9", 1772 }, { "10", 2863 }
            };

            responseValue.Ratings.Distribution.ShouldNotBeNull();
            responseValue.Ratings.Distribution.Count.ShouldBe(10);
            responseValue.Ratings.Distribution.ShouldBe(distribution);

            responseValue.Progress.ShouldNotBeNull();
            responseValue.Progress.Started.ShouldBe(388U);
            responseValue.Progress.Finished.ShouldBe(276U);
            responseValue.Progress.Dropped.ShouldBe(22U);

            responseValue.Lists.ShouldBe(31U);
            responseValue.TotalMinutes.ShouldBe(618949U);
            responseValue.TotalPlays.ShouldBe(12473U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestGetStatisticsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetStatisticsUri, statusCode);

            Func<Task<TraktResponse<TraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
