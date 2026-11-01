using System.Net;
using System.Text;

#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET
{
    public sealed class RequestHandlerTests
    {
        private const string CheckinUri = "checkin";
        private const string GetFriendsUri = "users/sean/friends";
        private const string Username = "sean";
        private const string RateLimitHeader = "X-Ratelimit";
        private const string RateLimitJson = """{"name":"UNAUTHED_API_GET_LIMIT","period":300,"limit":1000,"remaining":0,"until":"2026-01-01T12:00:00Z"}""";
        private const string InvalidJson = "not valid json";

        private static readonly TraktMovieCheckin s_movieCheckin = new() { Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 28U } } };

        [Fact]
        public async Task TestCheckinConflictExceptionContainsExpiresAt()
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri,
                _ => CreateResponse(HttpStatusCode.Conflict, """{"expires_at":"2026-01-01T12:00:00Z"}"""));

            Func<Task<TraktResponse<TraktMovieCheckinResponse>>> act = () => client.Checkins.CheckIntoMovieAsync(s_movieCheckin, cancellationToken: TestContext.Current.CancellationToken);
            TraktApiCheckinException exception = await act.ShouldThrowAsync<TraktApiCheckinException>();

            exception.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-01-01T12:00:00Z"));
        }

        [Fact]
        public async Task TestCheckinConflictExceptionIgnoresInvalidContent()
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, _ => CreateResponse(HttpStatusCode.Conflict, InvalidJson));

            Func<Task<TraktResponse<TraktMovieCheckinResponse>>> act = () => client.Checkins.CheckIntoMovieAsync(s_movieCheckin, cancellationToken: TestContext.Current.CancellationToken);
            TraktApiCheckinException exception = await act.ShouldThrowAsync<TraktApiCheckinException>();

            exception.ExpiresAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestRateLimitExceptionContainsRateLimitInfo()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFriendsUri, _ =>
            {
                HttpResponseMessage response = CreateResponse((HttpStatusCode)429, RateLimitJson);
                response.Headers.Add("Retry-After", "30");
                return response;
            });

            Func<Task<TraktListResponse<TraktUserFriend>>> act = () => client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            TraktApiRateLimitException exception = await act.ShouldThrowAsync<TraktApiRateLimitException>();

            exception.RetryAfter.ShouldBe(30U);
            ValidateRateLimitInfo(exception.RateLimitInfo);
        }

        [Fact]
        public async Task TestRateLimitExceptionIgnoresInvalidContent()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFriendsUri, _ => CreateResponse((HttpStatusCode)429, InvalidJson));

            Func<Task<TraktListResponse<TraktUserFriend>>> act = () => client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            TraktApiRateLimitException exception = await act.ShouldThrowAsync<TraktApiRateLimitException>();

            exception.RetryAfter.ShouldBe(0U);
            exception.RateLimitInfo.ShouldBeNull();
        }

        [Fact]
        public async Task TestResponseContainsRateLimitHeader()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFriendsUri, _ =>
            {
                HttpResponseMessage response = CreateResponse(HttpStatusCode.OK, "[]");
                response.Headers.TryAddWithoutValidation(RateLimitHeader, RateLimitJson);
                return response;
            });

            TraktListResponse<TraktUserFriend> response = await client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            ValidateRateLimitInfo(response.RateLimit);
        }

        [Fact]
        public async Task TestResponseIgnoresInvalidRateLimitHeader()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFriendsUri, _ =>
            {
                HttpResponseMessage response = CreateResponse(HttpStatusCode.OK, "[]");
                response.Headers.TryAddWithoutValidation(RateLimitHeader, InvalidJson);
                return response;
            });

            TraktListResponse<TraktUserFriend> response = await client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.RateLimit.ShouldBeNull();
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public async Task TestOptionalOAuthAuthorizationHeader(bool ignoreOAuthIfOptional, bool expectAuthorizationHeader)
        {
            bool hasAuthorizationHeader = false;

            TraktClient client = ModuleTestUtility.GetClient(GetFriendsUri, request =>
            {
                hasAuthorizationHeader = request.Headers.Authorization != null;
                return CreateResponse(HttpStatusCode.OK, "[]");
            });

            client.Authorization = TestConstants.MockAuthorization;
            client.IgnoreOAuthIfOptional = ignoreOAuthIfOptional;

            TraktListResponse<TraktUserFriend> response = await client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            hasAuthorizationHeader.ShouldBe(expectAuthorizationHeader);
        }

        private static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, string content)
            => new()
            {
                StatusCode = statusCode,
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

        private static void ValidateRateLimitInfo(TraktRateLimitInfo? rateLimitInfo)
        {
            rateLimitInfo.ShouldNotBeNull();
            rateLimitInfo.Name.ShouldBe("UNAUTHED_API_GET_LIMIT");
            rateLimitInfo.Period.ShouldBe(300U);
            rateLimitInfo.Limit.ShouldBe(1000U);
            rateLimitInfo.Remaining.ShouldBe(0U);
            rateLimitInfo.Until.ShouldBe(TestUtility.ParseUTCDateTime("2026-01-01T12:00:00Z"));
        }
    }
}
