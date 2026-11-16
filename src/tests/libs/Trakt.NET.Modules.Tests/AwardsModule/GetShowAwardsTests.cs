using System.Net;

namespace TraktNET.AwardsModule
{
    public sealed class GetShowAwardsTests
    {
        private const string GetShowAwardsUriPrefix = "shows";
        private const string GetShowAwardsUriSuffix = "awards";
        private static readonly string GetShowAwardsUri = $"{GetShowAwardsUriPrefix}/{TestConstants.Shows.TraktShowID}/{GetShowAwardsUriSuffix}";
        private static readonly string GetShowAwardsUriWithSlug = $"{GetShowAwardsUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowAwardsUriSuffix}";

        [Fact]
        public async Task TestGetShowAwardsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUri, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Awards.GetShowAwardsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktTitleAward> showAwards = response.Content!;

            TraktTitleAward award = showAwards[0];
            award.Year.ShouldBe(2024U);
            award.Won.ShouldBe(true);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("outstanding-drama-series");
            award.Ceremony.ShouldNotBeNull();
            award.Ceremony.Slug.ShouldBe("emmys");
            award.Person.ShouldNotBeNull();
            award.Person.Name.ShouldBe("Jesse Armstrong");

            award = showAwards[1];
            award.Year.ShouldBe(2024U);
            award.Won.ShouldBe(true);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("outstanding-lead-actor-in-a-drama-series");
            award.Person.ShouldNotBeNull();
            award.Person.Name.ShouldBe("Kieran Culkin");
        }

        [Fact]
        public async Task TestGetShowAwardsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Awards.GetShowAwardsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetShowAwardsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Awards.GetShowAwardsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowAwardsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUri, statusCode);

            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Awards.GetShowAwardsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowAwardsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Awards.GetShowAwardsAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Awards.GetShowAwardsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TestGetShowAwardsThrowsRequestValidationException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\show_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAwardsUriWithSlug, responseContent);

            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Awards.GetShowAwardsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Awards.GetShowAwardsAsync("  ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Awards.GetShowAwardsAsync("show id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
