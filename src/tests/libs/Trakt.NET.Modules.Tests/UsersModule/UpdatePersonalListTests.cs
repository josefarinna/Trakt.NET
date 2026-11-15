using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdatePersonalListTests
    {
        private const string UpdatePersonalListUri = $"users/{Username}/lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const string NewListName = "new list name";
        private const string NewDescription = "new list description";
        private const TraktListPrivacy NewPrivacy = TraktListPrivacy.Private;
        private const bool NewDisplayNumbers = false;
        private const bool NewAllowComments = false;

        [Fact]
        public async Task TestUpdatePersonalListWithName()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

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
        public async Task TestUpdatePersonalListWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListSlug, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, listIds, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, list, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescription()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

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
        public async Task TestUpdatePersonalListWithPrivacy()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Privacy = NewPrivacy
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

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
        public async Task TestUpdatePersonalListWithDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

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
        public async Task TestUpdatePersonalListWithAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

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
        public async Task TestUpdatePersonalListComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                Privacy = NewPrivacy,
                DisplayNumbers = NewDisplayNumbers,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestUpdatePersonalListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithIDsThrowsArgumentException()
        {
            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.UpdatePersonalListAsync(Username, default(TraktListIDs)!, content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListAsync(Username, default(TraktList)!, content);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListAsync(Username, new TraktListIDs(), content);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdatePersonalListAsync(Username, 0, content);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
