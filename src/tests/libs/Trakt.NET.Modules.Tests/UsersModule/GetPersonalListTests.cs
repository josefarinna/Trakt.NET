using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPersonalListTests
    {
        private const string GetPersonalListUri = $"users/{Username}/lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestGetPersonalListWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListUri, responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, ListSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPersonalListUri, responseContent, null, null, null, null);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/lists/{ListID}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync("me", TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiUserNotFoundException))]
        public async Task TestGetPersonalListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.GetPersonalListAsync(Username, TraktListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.GetPersonalListAsync(Username, default(TraktListIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListAsync(Username, new TraktListIDs());
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListAsync(Username, 0);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
