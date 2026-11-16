using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class RefreshAllTests
    {
        private const string ServiceID = "netflix";
        private static readonly string RefreshAllTrueUri = $"younify/users/refresh/{ServiceID}/true";
        private static readonly string RefreshAllFalseUri = $"younify/users/refresh/{ServiceID}/false";

        [Fact]
        public async Task TestRefreshAll()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAllTrueUri, HttpStatusCode.Created);
            TraktResponse response = await client.Younify.RefreshAllAsync(ServiceID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRefreshAllWithIncrementalAndPost()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAllFalseUri, HttpStatusCode.Created);
            var post = new TraktYounifyRefreshPost { SkipSync = true };
            TraktResponse response = await client.Younify.RefreshAllAsync(ServiceID, false, post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRefreshAllThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAllTrueUri, HttpStatusCode.OK);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshAllAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Younify.RefreshAllAsync("   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRefreshAllThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAllTrueUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshAllAsync(ServiceID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
