using System.Net;

namespace TraktNET.CheckinModule
{
    public sealed class DeleteAnyActiveCheckinsTests
    {
        private const string CheckinUri = "checkin";

        [Fact]
        public async Task TestDeleteAnyActiveCheckins()
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Checkins.DeleteAnyActiveCheckinsAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiCheckinException))]
        public async Task TestDeleteAnyActiveCheckinsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
