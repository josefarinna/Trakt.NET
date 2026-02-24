using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class UndoResetShowWatchedProgressTests
    {
        private const string UndoResetShowWatchedProgressUriPrefix = "shows";
        private const string UndoResetShowWatchedProgressUriSuffix = "progress/watched/reset";

        private static readonly string UndoResetShowWatchedProgressUri = $"{UndoResetShowWatchedProgressUriPrefix}/{TestConstants.Shows.ShowID}/{UndoResetShowWatchedProgressUriSuffix}";
        private const string UndoResetShowWatchedProgressUriWithSlug = UndoResetShowWatchedProgressUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + UndoResetShowWatchedProgressUriSuffix;

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
        }

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, HttpStatusCode.NoContent);

            TraktResponse response = await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
        }

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, HttpStatusCode.NoContent);

            TraktResponse response = await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        public async Task TestUndoResetShowWatchedProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, statusCode);

            try
            {
                await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, HttpStatusCode.NoContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse>> act = () => client.Shows.UndoResetShowWatchedProgressAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.UndoResetShowWatchedProgressAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
