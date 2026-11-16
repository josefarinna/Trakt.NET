using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class RefreshServiceTests
    {
        private const string RefreshServiceUri = "younify/users/refresh";

        [Fact]
        public async Task TestRefreshService()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshServiceUri, HttpStatusCode.Created);

            var post = new TraktYounifyRefreshServicePost
            {
                ServiceId = "netflix",
                SkipSync = true
            };

            TraktResponse response = await client.Younify.RefreshServiceAsync(post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRefreshServiceThrowsValidationException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshServiceUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshServiceAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRefreshServiceThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var post = new TraktYounifyRefreshServicePost
            {
                ServiceId = "netflix",
                SkipSync = true
            };
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshServiceUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshServiceAsync(post, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
