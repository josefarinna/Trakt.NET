using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class AddPersonalListItemsTests
    {
        private const string AddPersonalListItemsUri = $"users/{Username}/lists/{ListID}/items";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestAddPersonalListItemsWithID()
        {
            var content = new TraktUserPersonalListItemsPost
            {
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 16 } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitempostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddPersonalListItemsUri, responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsPostResponse> response = await client.Users.AddPersonalListItemsAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserPersonalListItemsPostResponse responseValue = response.Content;

            responseValue.Added.ShouldNotBeNull();
            responseValue.Added.Movies.ShouldBe(1U);
            responseValue.Added.Shows.ShouldBe(1U);
            responseValue.Added.Seasons.ShouldBe(1U);
            responseValue.Added.Episodes.ShouldBe(2U);
            responseValue.Added.People.ShouldBe(1U);
            responseValue.Existing.ShouldNotBeNull();
            responseValue.Existing.Movies.ShouldBe(0U);
            responseValue.Existing.Shows.ShouldBe(0U);
            responseValue.Existing.Seasons.ShouldBe(0U);
            responseValue.Existing.Episodes.ShouldBe(0U);
            responseValue.Existing.People.ShouldBe(0U);

            responseValue.NotFound.ShouldNotBeNull();
            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktPostResponseNotFoundMovie[] movies = [.. responseValue.NotFound.Movies];

            movies[0].IDs.ShouldNotBeNull();
            movies[0].IDs!.Trakt.ShouldBeNull();
            movies[0].IDs!.Slug.ShouldBeNullOrEmpty();
            movies[0].IDs!.IMDB.ShouldBe("tt0000111");
            movies[0].IDs!.TMDB.ShouldBeNull();

            responseValue.NotFound.Shows.ShouldNotBeNull();
            responseValue.NotFound.Shows.Count.ShouldBe(0);
            responseValue.NotFound.Seasons.ShouldNotBeNull();
            responseValue.NotFound.Seasons.Count.ShouldBe(0);
            responseValue.NotFound.Episodes.ShouldNotBeNull();
            responseValue.NotFound.Episodes.Count.ShouldBe(0);
            responseValue.NotFound.People.ShouldNotBeNull();
            responseValue.NotFound.People.Count.ShouldBe(0);
        }

        [Fact]
        public async Task TestAddPersonalListItemsWithSlug()
        {
            var content = new TraktUserPersonalListItemsPost
            {
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 16 } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitempostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items", responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(Username, ListSlug, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddPersonalListItemsWithIDs()
        {
            var content = new TraktUserPersonalListItemsPost
            {
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 16 } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitempostresponse.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items", responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(Username, listIds, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddPersonalListItemsWithList()
        {
            var content = new TraktUserPersonalListItemsPost
            {
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 16 } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitempostresponse.json");

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items", responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(Username, list, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestAddPersonalListItemsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddPersonalListItemsUri, statusCode);

            var content = new TraktUserPersonalListItemsPost
            {
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 16 } }]
            };

            Func<Task<TraktResponse<TraktUserPersonalListItemsPostResponse>>> act = () => client.Users.AddPersonalListItemsAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddPersonalListItemsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddPersonalListItemsUri, HttpStatusCode.OK);

            var content = new TraktUserPersonalListItemsPost
            {
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 16 } }]
            };

            Func<Task<TraktResponse<TraktUserPersonalListItemsPostResponse>>> act =
                () => client.Users.AddPersonalListItemsAsync(Username, default(TraktListIDs)!, content, TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.AddPersonalListItemsAsync(Username, default(TraktList)!, content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.AddPersonalListItemsAsync(Username, new TraktListIDs(), content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.AddPersonalListItemsAsync(Username, 0, content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
