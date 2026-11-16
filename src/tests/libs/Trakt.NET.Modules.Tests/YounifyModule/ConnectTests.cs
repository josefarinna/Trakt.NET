using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class ConnectTests
    {
        private const string ConnectUri = "younify/connect";

        [Fact]
        public async Task TestConnect()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Younify\\connect.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectUri, responseContent);

            var post = new TraktYounifyConnectPost
            {
                ServiceID = "netflix",
                ReturnUrl = "https://trakt.tv/return"
            };

            TraktResponse<TraktYounifyConnectResponse> response =
                await client.Younify.ConnectAsync(post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Url.ShouldBe("https://younify.trakt.tv/connect/netflix?token=abcdef");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestConnectThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var post = new TraktYounifyConnectPost
            {
                ServiceID = "netflix",
                ReturnUrl = "https://trakt.tv/return"
            };
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectUri, statusCode);

            Func<Task<TraktResponse<TraktYounifyConnectResponse>>> act = () => client.Younify.ConnectAsync(post, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConnectThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktYounifyConnectResponse>>> act = () => client.Younify.ConnectAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
