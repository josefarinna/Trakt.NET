using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ReportUserTests
    {
        private const string ReportUserUri = $"users/{Username}/report";
        private const string Username = "sean";
        private const TraktReason Reason = TraktReason.Spam;
        private const string Message = "Inappropriate behavior";

        [Fact]
        public async Task TestReportUser()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportUserUri, HttpStatusCode.NoContent);
            
            TraktResponse response = await client.Users.ReportUserAsync(Username, Reason, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestReportUserWithMessage()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportUserUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.ReportUserAsync(Username, Reason, Message, TestContext.Current.CancellationToken);
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestReportUserThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportUserUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.ReportUserAsync(Username, Reason, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
