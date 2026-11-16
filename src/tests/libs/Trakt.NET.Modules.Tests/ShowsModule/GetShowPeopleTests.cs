using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowPeopleTests
    {
        private const string GetShowPeopleUri = $"shows/{TestConstants.Shows.ShowID}/people";
        private const string GetShowPeopleUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/people";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetShowPeopleUri)]
        [InlineData(ExtendedInfo, $"{GetShowPeopleUri}?extended=full")]
        public async Task TestGetShowPeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showpeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowPeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowPeopleWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowPeopleUriWithSlug, "{}");

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowPeopleAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
