using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class DisconnectTests
    {
        private const string ServiceID = "netflix";
        private static readonly string DisconnectUri = $"younify/users/services/{ServiceID}";

        [Fact]
        public async Task TestDisconnect()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DisconnectUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Younify.DisconnectAsync(ServiceID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestDisconnectThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DisconnectUri, HttpStatusCode.OK);

            Func<Task<TraktResponse>> act = () => client.Younify.DisconnectAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Younify.DisconnectAsync("   ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestDisconnectThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DisconnectUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Younify.DisconnectAsync(ServiceID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
