using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ConvertListToSmartListTests
    {
        private readonly string ConvertListToSmartListUri = $"users/{Username}/lists/{ListID}/smart-list-draft/convert";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const string SmartListName = "converted smart list";

        [Fact]
        public async Task TestConvertListToSmartListWithID()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, TraktListID, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.IDs.ShouldNotBeNull();
            response.Content.IDs.Trakt.ShouldBe(123U);
            response.Content.IDs.Slug.ShouldBe("abc");
        }

        [Fact]
        public async Task TestConvertListToSmartListWithSlug()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft/convert", responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, ListSlug, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithIDs()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft/convert", responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, listIds, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithList()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/smart-list-draft/convert", responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.ConvertListToSmartListAsync(Username, list, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestConvertListToSmartListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, statusCode);

            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.ConvertListToSmartListAsync(Username, TraktListID, smartListPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestConvertListToSmartListWithIDsThrowsArgumentException()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = SmartListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConvertListToSmartListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.ConvertListToSmartListAsync(null!, ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(string.Empty, ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync("username with spaces", ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, default(string)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, string.Empty, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, "list id with spaces", smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, ListID, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, default(TraktListIDs)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, default(TraktList)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, new TraktListIDs(), smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.ConvertListToSmartListAsync(Username, 0, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
