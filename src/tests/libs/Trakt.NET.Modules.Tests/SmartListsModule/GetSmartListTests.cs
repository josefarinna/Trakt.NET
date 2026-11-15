using System.Net;

namespace TraktNET.SmartListsModule
{
    public sealed class GetSmartListTests
    {
        private readonly string GetSmartListUri = $"smart-lists/{ListID}";
        private const string ListSlug = "sci-fi-movies";
        private const uint ListID = 123456U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetSmartListWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListID}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = ListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithList()
        {
            var list = new TraktSmartList
            {
                IDs = new TraktListIDs
                {
                    Trakt = ListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(list, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"smart-lists/{ListID}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktSmartList> response = await client.SmartLists.GetSmartListAsync(ListID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSmartList responseValue = response.Content;

            responseValue.ShouldNotBeNull();
            responseValue.Name.ShouldBe("Sci-Fi Movies");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.Source.ShouldBe(TraktSmartListSource.Popular);
            responseValue.MediaType.ShouldBe(TraktSmartListMediaType.Movies);

            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(123456U);
            responseValue.IDs.Slug.ShouldBe("sci-fi-movies");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestGetSmartListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, statusCode);

            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.SmartLists.GetSmartListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.SmartLists.GetSmartListAsync(default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.SmartLists.GetSmartListAsync(default(TraktSmartList)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.SmartLists.GetSmartListAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.SmartLists.GetSmartListAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
