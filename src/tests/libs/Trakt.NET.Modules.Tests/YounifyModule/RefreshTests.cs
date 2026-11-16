using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class RefreshTests
    {
        private const string ServiceID = "netflix";
        private static readonly string RefreshUri = $"younify/users/refresh/{ServiceID}";

        [Fact]
        public async Task TestRefresh()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshUri, HttpStatusCode.Created);
            TraktResponse response = await client.Younify.RefreshAsync(ServiceID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRefreshWithPost()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshUri, HttpStatusCode.Created);
            var post = new TraktYounifyRefreshPost { SkipSync = true };
            TraktResponse response = await client.Younify.RefreshAsync(ServiceID, post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRefreshThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshUri, HttpStatusCode.OK);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Younify.RefreshAsync("   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRefreshThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshAsync(ServiceID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
