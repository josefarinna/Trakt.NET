using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class AddCollectionItemsTests
    {
        private const string AddCollectionItemsUri = "sync/collection";

        [Fact]
        public async Task TestAddCollectionItems()
        {
            var content = new TraktSyncCollectionPost
            {
                Movies = [ new TraktSyncCollectionPostMovie { IDs = new TraktMovieIDs { Trakt = 1U } } ]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddCollectionItemsUri, responseContent, null, null, null, null);
            TraktResponse<TraktSyncCollectionPostResponse> response = await client.Sync.AddCollectionItemsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncCollectionPostResponse responseValue = response.Content;

            responseValue.Added.ShouldNotBeNull();
            responseValue.Added.Movies.ShouldBe(1U);
            responseValue.Added.Episodes.ShouldBe(12U);
            responseValue.Added.Shows.ShouldBeNull();
            responseValue.Added.Seasons.ShouldBeNull();

            responseValue.Updated.ShouldNotBeNull();
            responseValue.Updated.Movies.ShouldBe(3U);
            responseValue.Updated.Episodes.ShouldBe(1U);
            responseValue.Updated.Shows.ShouldBeNull();
            responseValue.Updated.Seasons.ShouldBeNull();

            responseValue.Existing.ShouldNotBeNull();
            responseValue.Existing.Movies.ShouldBe(2U);
            responseValue.Existing.Episodes.ShouldBe(0U);
            responseValue.Existing.Shows.ShouldBeNull();
            responseValue.Existing.Seasons.ShouldBeNull();

            responseValue.NotFound.ShouldNotBeNull();
            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktPostResponseNotFoundMovie[] movies = [.. responseValue.NotFound.Movies];

            movies[0].IDs.ShouldNotBeNull();
            movies[0].IDs!.Trakt.ShouldBeNull();
            movies[0].IDs!.Slug.ShouldBeNullOrEmpty();
            movies[0].IDs!.IMDB.ShouldBe("tt0000111");
            movies[0].IDs!.TMDB.ShouldBeNull();

            responseValue.NotFound.Shows.ShouldNotBeNull();
            responseValue.NotFound.Shows.Count.ShouldBe(0);
            responseValue.NotFound.Seasons.ShouldNotBeNull();
            responseValue.NotFound.Seasons.Count.ShouldBe(0);
            responseValue.NotFound.Episodes.ShouldNotBeNull();
            responseValue.NotFound.Episodes.Count.ShouldBe(0);
            responseValue.NotFound.People.ShouldNotBeNull();
            responseValue.NotFound.People.Count.ShouldBe(0);
            responseValue.NotFound.Users.ShouldNotBeNull();
            responseValue.NotFound.Users.Count.ShouldBe(0);
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
        public async Task TestAddCollectionItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddCollectionItemsUri, statusCode);

            var content = new TraktSyncCollectionPost
            {
                Movies = [ new TraktSyncCollectionPostMovie { IDs = new TraktMovieIDs { Trakt = 1U } } ]
            };

            Func<Task<TraktResponse<TraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddCollectionItemsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddCollectionItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktSyncCollectionPost();
            act = () => client.Sync.AddCollectionItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.AddCollectionItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
