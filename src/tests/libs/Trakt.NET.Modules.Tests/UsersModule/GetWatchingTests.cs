using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchingTests
    {
        private const string GetWatchingUri = $"users/{Username}/watching";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetWatchingUri)]
        [InlineData(ExtendedInfo, $"{GetWatchingUri}?extended=full")]
        public async Task TestGetWatching(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchingitem_movie.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktUserWatchingItem> response = await client.Users.GetWatchingAsync(Username, extendedInfo, TestContext.Current.CancellationToken);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetWatchingThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchingUri, statusCode);

            Func<Task<TraktResponse<TraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
