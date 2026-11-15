using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class CreateSmartListTests
    {
        private const string CreateSmartListUri = $"users/{Username}/smart-lists";
        private const string Username = "sean";
        private const string ListName = "new smart list";

        [Fact]
        public async Task TestCreateSmartList()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.CreateSmartListAsync(Username, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestCreateSmartListWithFiltersAndPrivacy()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies,
                Privacy = TraktListPrivacy.Public,
                Filters = new TraktSmartListFilters
                {
                    Genres = ["action"]
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.CreateSmartListAsync(Username, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestCreateSmartListThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, statusCode);
            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.CreateSmartListAsync(Username, smartListPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestCreateSmartListArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, HttpStatusCode.Created);

            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.CreateSmartListAsync(null!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreateSmartListAsync(string.Empty, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreateSmartListAsync("username with spaces", smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreateSmartListAsync(Username, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
