using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class AddRatingsTests
    {
        private const string AddRatingsUri = "sync/ratings";

        [Fact]
        public async Task TestAddRatings()
        {
            var content = new TraktSyncRatingsPost
            {
                Movies = [new TraktSyncRatingsPostMovie { Rating = 1 }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratingspostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddRatingsUri, responseContent);
            TraktResponse<TraktSyncRatingsPostResponse> response = await client.Sync.AddRatingsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncRatingsPostResponse responseValue = response.Content;

            responseValue.Added.ShouldNotBeNull();
            responseValue.Added.Movies.ShouldBe(1U);
            responseValue.Added.Episodes.ShouldBe(4U);
            responseValue.Added.Shows.ShouldBe(2U);
            responseValue.Added.Seasons.ShouldBe(3U);

            responseValue.NotFound.ShouldNotBeNull();
            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktSyncRatingsPostResponseNotFoundMovie[] movies = [.. responseValue.NotFound.Movies!];

            movies[0].Rating.ShouldBe(10);
            movies[0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            movies[0].IDs.ShouldNotBeNull();
            movies[0].IDs!.Trakt.ShouldBeNull();
            movies[0].IDs!.Slug.ShouldBeNullOrEmpty();
            movies[0].IDs!.IMDB.ShouldBe("tt0000111");
            movies[0].IDs!.TMDB.ShouldBeNull();

            responseValue.NotFound.Shows.ShouldNotBeNull();
            responseValue.NotFound.Shows.Count.ShouldBe(1);

            TraktSyncRatingsPostResponseNotFoundShow[] shows = [.. responseValue.NotFound.Shows!];

            shows[0].Rating.ShouldBe(9);
            shows[0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            shows[0].IDs.ShouldNotBeNull();
            shows[0].IDs!.Trakt.ShouldBe(1U);
            shows[0].Seasons.ShouldNotBeNull();
            shows[0].Seasons!.Count.ShouldBe(1);

            shows[0].Seasons![0].Number.ShouldBe(1U);
            shows[0].Seasons![0].Rating.ShouldBe(8);
            shows[0].Seasons![0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            shows[0].Seasons![0].Episodes.ShouldNotBeNull();
            shows[0].Seasons![0].Episodes!.Count.ShouldBe(1);
            shows[0].Seasons![0].Episodes![0].Number.ShouldBe(1U);
            shows[0].Seasons![0].Episodes![0].Rating.ShouldBe(7);
            shows[0].Seasons![0].Episodes![0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));

            responseValue.NotFound.Seasons.ShouldNotBeNull();
            responseValue.NotFound.Seasons!.Count.ShouldBe(1);

            TraktSyncRatingsPostResponseNotFoundShow[] seasons = [.. responseValue.NotFound.Seasons!];

            seasons[0].Rating.ShouldBeNull();
            seasons[0].RatedAt.ShouldBeNull();
            seasons[0].IDs.ShouldNotBeNull();
            seasons[0].IDs!.Trakt.ShouldBe(2U);
            seasons[0].Seasons.ShouldNotBeNull();
            seasons[0].Seasons!.Count.ShouldBe(1);
            seasons[0].Seasons![0].Number.ShouldBe(2U);
            seasons[0].Seasons![0].Rating.ShouldBe(6);
            seasons[0].Seasons![0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));

            responseValue.NotFound.Episodes.ShouldNotBeNull();
            responseValue.NotFound.Episodes!.Count.ShouldBe(1);

            TraktSyncRatingsPostResponseNotFoundShow[] episodes = [.. responseValue.NotFound.Episodes!];

            episodes[0].Rating.ShouldBeNull();
            episodes[0].RatedAt.ShouldBeNull();
            episodes[0].IDs.ShouldNotBeNull();
            episodes[0].IDs!.Trakt.ShouldBe(3U);
            episodes[0].Seasons.ShouldNotBeNull();
            episodes[0].Seasons!.Count.ShouldBe(1);
            episodes[0].Seasons![0].Number.ShouldBe(1U);
            episodes[0].Seasons![0].Rating.ShouldBeNull();
            episodes[0].Seasons![0].Episodes.ShouldNotBeNull();
            episodes[0].Seasons![0].Episodes!.Count.ShouldBe(1);
            episodes[0].Seasons![0].Episodes![0].Number.ShouldBe(2U);
            episodes[0].Seasons![0].Episodes![0].Rating.ShouldBe(5);
            episodes[0].Seasons![0].Episodes![0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestAddRatingsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddRatingsUri, statusCode);

            var content = new TraktSyncRatingsPost
            {
                Movies = [new TraktSyncRatingsPostMovie { Rating = 1 }]
            };

            Func<Task<TraktResponse<TraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddRatingsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddRatingsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktSyncRatingsPost();
            act = () => client.Sync.AddRatingsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.AddRatingsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [ new TraktSyncRatingsPostMovie {
                Rating = 0
            } ];
            act = () => client.Sync.AddRatingsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
