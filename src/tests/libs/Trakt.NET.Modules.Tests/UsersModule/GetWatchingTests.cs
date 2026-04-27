using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchingTests
    {
        private const string GetWatchingUri = $"users/{Username}/watching";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetWatching()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchingitem_movie.json");

            TraktClient client = ModuleTestUtility.GetClient(GetWatchingUri, responseContent);
            
            TraktResponse<TraktUserWatchingItem> response = await client.Users.GetWatchingAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserWatchingItem responseValue = response.Content;

            responseValue.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            responseValue.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            responseValue.Action.ShouldBe(TraktHistoryActionType.Checkin);
            responseValue.Type.ShouldBe(TraktSyncType.Movie);
            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Super 8");
            responseValue.Movie.Year.ShouldBe(2011U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs.Trakt.ShouldBe(2U);
            responseValue.Movie.IDs.Slug.ShouldBe("super-8-2011");
            responseValue.Movie.IDs.IMDB.ShouldBe("tt1650062");
            responseValue.Movie.IDs.TMDB.ShouldBe(37686U);
            responseValue.Show.ShouldBeNull();
            responseValue.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchingWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchingitem_movie.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchingUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktUserWatchingItem> response = await client.Users.GetWatchingAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserWatchingItem responseValue = response.Content;

            responseValue.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            responseValue.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            responseValue.Action.ShouldBe(TraktHistoryActionType.Checkin);
            responseValue.Type.ShouldBe(TraktSyncType.Movie);
            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Super 8");
            responseValue.Movie.Year.ShouldBe(2011U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs.Trakt.ShouldBe(2U);
            responseValue.Movie.IDs.Slug.ShouldBe("super-8-2011");
            responseValue.Movie.IDs.IMDB.ShouldBe("tt1650062");
            responseValue.Movie.IDs.TMDB.ShouldBe(37686U);
            responseValue.Show.ShouldBeNull();
            responseValue.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchingWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchingitem_movie.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/watching", responseContent);
            TraktResponse<TraktUserWatchingItem> response = await client.Users.GetWatchingAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserWatchingItem responseValue = response.Content;

            responseValue.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            responseValue.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            responseValue.Action.ShouldBe(TraktHistoryActionType.Checkin);
            responseValue.Type.ShouldBe(TraktSyncType.Movie);
            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Super 8");
            responseValue.Movie.Year.ShouldBe(2011U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs.Trakt.ShouldBe(2U);
            responseValue.Movie.IDs.Slug.ShouldBe("super-8-2011");
            responseValue.Movie.IDs.IMDB.ShouldBe("tt1650062");
            responseValue.Movie.IDs.TMDB.ShouldBe(37686U);
            responseValue.Show.ShouldBeNull();
            responseValue.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchingComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchingitem_movie.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchingUri}?extended={ExtendedInfo.ToURI()}",
                responseContent);

            TraktResponse<TraktUserWatchingItem> response = await client.Users.GetWatchingAsync(Username, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserWatchingItem responseValue = response.Content;

            responseValue.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            responseValue.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            responseValue.Action.ShouldBe(TraktHistoryActionType.Checkin);
            responseValue.Type.ShouldBe(TraktSyncType.Movie);
            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Super 8");
            responseValue.Movie.Year.ShouldBe(2011U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs.Trakt.ShouldBe(2U);
            responseValue.Movie.IDs.Slug.ShouldBe("super-8-2011");
            responseValue.Movie.IDs.IMDB.ShouldBe("tt1650062");
            responseValue.Movie.IDs.TMDB.ShouldBe(37686U);
            responseValue.Show.ShouldBeNull();
            responseValue.Episode.ShouldBeNull();
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
        public async Task TestGetWatchingThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchingUri, statusCode);

            Func<Task<TraktResponse<TraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
