using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class ResetShowWatchedProgressTests
    {
        private const string ResetShowWatchedProgressUriPrefix = "shows";
        private const string ResetShowWatchedProgressUriSuffix = "progress/watched/reset";

        private static readonly string ResetShowWatchedProgressUri = $"{ResetShowWatchedProgressUriPrefix}/{TestConstants.Shows.ShowID}/{ResetShowWatchedProgressUriSuffix}";
        private const string ResetShowWatchedProgressUriWithSlug = ResetShowWatchedProgressUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + ResetShowWatchedProgressUriSuffix;

        private static readonly DateTime ResetAt = new(2024, 9, 23, 19, 8, 15, DateTimeKind.Utc);
        private const string ResetAtValue = "2024-09-23T19:08:15.000Z";

        [Fact]
        public async Task TestResetShowWatchedProgressWithID()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUri, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithSlug()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithIDs()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithResetAt()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, ResetAt, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        public async Task TestResetShowWatchedProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, statusCode);

            try
            {
                await client.Shows.ResetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, "{}", null, null, null, null);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktShowResetWatchedProgress>>> act = () => client.Shows.ResetShowWatchedProgressAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.ResetShowWatchedProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        private static void ValidateResponse(TraktResponse<TraktShowResetWatchedProgress> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Content!.ResetAt.ShouldBe(ResetAt);
        }
    }
}
