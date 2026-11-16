#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace TraktNET.AuthModule
{
    public sealed class RevokeAuthorizationTests
    {
        private const string RevokeAuthorizationUri = "oauth/revoke";

        [Fact]
        public async Task TestRevokeAuthorization()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Fact]
        public async Task TestRevokeAuthorizationDoesNotSendEmptyBearerHeaderOnSubsequentRequest()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse revokeResponse = await client.Auth.RevokeAuthorizationAsync(TestContext.Current.CancellationToken);
            revokeResponse.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);

            string historyJson = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
            AuthenticationHeaderValue? capturedAuthHeader = null;

            ModuleTestUtility.SetClient(client, "users/sean/history", requestMessage =>
            {
                capturedAuthHeader = requestMessage.Headers.Authorization;
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(historyJson, Encoding.UTF8, "application/json")
                };
            });

            TraktPagedResponse<TraktHistoryItem> historyResponse = await client.Users.GetWatchedHistoryAsync("sean", cancellationToken: TestContext.Current.CancellationToken);
            historyResponse.IsSuccess.ShouldBeTrue();
            capturedAuthHeader.ShouldBeNull();
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithToken()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(
                TestConstants.MockAuthorization.AccessToken!,
                TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithTokenAndClientID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(
                TestConstants.MockAuthorization.AccessToken!,
                TestConstants.ClientID,
                TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(
                TestConstants.MockAuthorization.AccessToken!,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiAuthenticationException))]
        public async Task TestRevokeAuthorizationThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, statusCode, true);
            client.Authorization = TestConstants.MockAuthorization;

            Func<Task<TraktResponse>> act = () => client.Auth.RevokeAuthorizationAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithAuthorizationNullThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri);
            client.Authorization = null;

            Func<Task<TraktResponse>> act = () => client.Auth.RevokeAuthorizationAsync(TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        private static void ValidateRevokedState(TraktClient client)
        {
            client.Authorization.ShouldNotBeNull();
            client.Authorization.AccessToken.ShouldBeEmpty();
            client.Authorization.RefreshToken.ShouldBeEmpty();
            client.Authorization.Scope.ShouldBe(TraktAccessScope.Public);
            client.Authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            client.Authorization.IsExpired.ShouldBeTrue();
            client.Authorization.IsValid.ShouldBeFalse();
        }
    }
}
