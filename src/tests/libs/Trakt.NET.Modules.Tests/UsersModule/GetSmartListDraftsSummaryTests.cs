using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSmartListDraftsSummaryTests
    {
        private const string GetSmartListDraftsSummaryUri = $"users/{Username}/smart-list-drafts";
        private const string Username = "sean";

        [Fact]
        public async Task TestGetSmartListDraftsSummary()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_drafts_summary.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListDraftsSummaryUri, responseContent);

            TraktResponse<TraktSmartListDraftsSummary> response = await client.Users.GetSmartListDraftsSummaryAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSmartListDraftsSummary responseValue = response.Content;

            responseValue.ConvertibleCount.ShouldBe(2U);
            responseValue.BestConfidence.ShouldBe(0.95f);

            responseValue.Lists.ShouldNotBeNull();
            responseValue.Lists.Count.ShouldBe(2);

            responseValue.Lists[0].ShouldNotBeNull();
            responseValue.Lists[0].IDs.ShouldNotBeNull();
            responseValue.Lists[0].IDs!.Trakt.ShouldBe(1248149U);
            responseValue.Lists[0].IDs!.Slug.ShouldBe("marvel-cinematic-universe");
            responseValue.Lists[0].Name.ShouldBe("Marvel Cinematic Universe");
            responseValue.Lists[0].ItemCount.ShouldBe(33U);
            responseValue.Lists[0].Confidence.ShouldBe(0.95f);

            responseValue.Lists[1].ShouldNotBeNull();
            responseValue.Lists[1].IDs.ShouldNotBeNull();
            responseValue.Lists[1].IDs!.Trakt.ShouldBe(987654U);
            responseValue.Lists[1].IDs!.Slug.ShouldBe("dc-extended-universe");
            responseValue.Lists[1].Name.ShouldBe("DC Extended Universe");
            responseValue.Lists[1].ItemCount.ShouldBe(15U);
            responseValue.Lists[1].Confidence.ShouldBe(0.8f);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetSmartListDraftsSummaryThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListDraftsSummaryUri, statusCode);
            Func<Task<TraktResponse<TraktSmartListDraftsSummary>>> act = () => client.Users.GetSmartListDraftsSummaryAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListDraftsSummaryArgumentExceptions()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            Func<Task<TraktResponse<TraktSmartListDraftsSummary>>> act = () => client.Users.GetSmartListDraftsSummaryAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftsSummaryAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListDraftsSummaryAsync("username with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
