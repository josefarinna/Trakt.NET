using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowSentimentsTests
    {
        private const string GetShowSentimentsUri = $"shows/{TestConstants.Shows.ShowID}/sentiments";
        private const string GetShowSentimentsUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/sentiments";

        [Fact]
        public async Task TestGetShowSentimentsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showsentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowSentimentsUri, responseContent);

            TraktResponse<TraktSentiments> response = await client.Shows.GetShowSentimentsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktSentiments showSentiments = response.Content;

            showSentiments.Good.ShouldNotBeNull();
            showSentiments.Good.Count.ShouldBe(1);
            showSentiments.Good[0].Sentiment.ShouldBe("funny");
            showSentiments.Bad.ShouldNotBeNull();
            showSentiments.Bad.Count.ShouldBe(1);
            showSentiments.Bad[0].Sentiment.ShouldBe("boring");
            showSentiments.CommentCount.ShouldBe(100U);
        }

        [Fact]
        public async Task TestGetShowSentimentsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showsentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowSentimentsUriWithSlug, responseContent);

            TraktResponse<TraktSentiments> response = await client.Shows.GetShowSentimentsAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSentiments showSentiments = response.Content;

            showSentiments.Good.ShouldNotBeNull();
            showSentiments.Good.Count.ShouldBe(1);
            showSentiments.Good[0].Sentiment.ShouldBe("funny");
            showSentiments.Bad.ShouldNotBeNull();
            showSentiments.Bad.Count.ShouldBe(1);
            showSentiments.Bad[0].Sentiment.ShouldBe("boring");
            showSentiments.CommentCount.ShouldBe(100U);
        }

        [Fact]
        public async Task TestGetShowSentimentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showsentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowSentimentsUriWithSlug, responseContent);

            TraktResponse<TraktSentiments> response = await client.Shows.GetShowSentimentsAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSentiments showSentiments = response.Content;

            showSentiments.Good.ShouldNotBeNull();
            showSentiments.Good.Count.ShouldBe(1);
            showSentiments.Good[0].Sentiment.ShouldBe("funny");
            showSentiments.Bad.ShouldNotBeNull();
            showSentiments.Bad.Count.ShouldBe(1);
            showSentiments.Bad[0].Sentiment.ShouldBe("boring");
            showSentiments.CommentCount.ShouldBe(100U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowSentimentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowSentimentsUri, statusCode);

            Func<Task<TraktResponse<TraktSentiments>>> act = () => client.Shows.GetShowSentimentsAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetShowSentimentsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showsentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowSentimentsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktSentiments>>> act = () => client.Shows.GetShowSentimentsAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Shows.GetShowSentimentsAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
