using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonPeopleTests
    {
        private const string GetSeasonPeopleUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/people";
        private const uint SeasonNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetSeasonPeopleUri)]
        [InlineData(ExtendedInfo, $"{GetSeasonPeopleUri}?extended=full")]
        public async Task TestGetSeasonPeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.TraktShowID, SeasonNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            TraktCastAndCrew responseValue = response.Content;
            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(2);
            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production.Count.ShouldBe(1);
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art.Count.ShouldBe(1);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew.Count.ShouldBe(1);
            responseValue.Crew.CostumeAndMakeUp.ShouldNotBeNull();
            responseValue.Crew.CostumeAndMakeUp.Count.ShouldBe(1);
            responseValue.Crew.Directing.ShouldNotBeNull();
            responseValue.Crew.Directing.Count.ShouldBe(1);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing.Count.ShouldBe(1);
            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound.Count.ShouldBe(1);
            responseValue.Crew.Camera.ShouldNotBeNull();
            responseValue.Crew.Camera.Count.ShouldBe(1);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting.Count.ShouldBe(1);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects.Count.ShouldBe(1);
            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowSlug, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonPeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Seasons.GetSeasonPeopleAsync(default(TraktShowIDs)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonPeopleAsync(default(TraktShow)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonPeopleAsync(new TraktShowIDs(), SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonPeopleAsync(0, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
